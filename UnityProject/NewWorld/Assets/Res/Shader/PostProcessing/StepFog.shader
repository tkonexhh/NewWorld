Shader "XHH/StepFog"
{
    Properties
    {
        [HideInInspector]_MainTex ("Base (RGB)", 2D) = "white" { }
        _FogColor ("Fog Color", Color) = (1, 1, 1, 1)
        _FogStength ("Fog Strength", Range(0, 1)) = 1
    }
    SubShader
    {
        Pass
        {
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            TEXTURE2D(_CameraDepthTexture);
            SAMPLER(sampler_CameraDepthTexture);
            float4 _CameraDepthTexture_TexelSize;

            float4 _FogColor;
            float _FogStength;

            struct Attributes
            {
                float4 positionOS: POSITION;
                float2 uv: TEXCOORD0;
            };

            struct Varyings
            {
                float4 vertex: SV_POSITION;
                float2 uv: TEXCOORD0;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.vertex = vertexInput.positionCS;
                output.uv = input.uv;

                return output;
            }

            inline float GetOrthoDepthFromZBuffer(float rawDepth)
            {
                #if defined(UNITY_REVERSED_Z)
                    #if UNITY_REVERSED_Z == 1
                        rawDepth = 1.0f - rawDepth;
                    #endif
                #endif
                
                return lerp(_ProjectionParams.y, _ProjectionParams.z, rawDepth);
            }

            float4 frag(Varyings input): SV_Target
            {
                float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                // SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, input.uv[i]);
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, input.uv);
                // depth = 1 - depth;
                float linearDepth = LinearEyeDepth(depth, _ZBufferParams);
                // float linearDepth = lerp(_ProjectionParams.y, _ProjectionParams.z, depth);
                // depth *= 100;
                float4 finalColor = color ;
                return(1 - linearDepth / 500 * _FogStength) * _FogColor * color;
                // return color;
            }
            
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}