Shader "XHH/Terrain"
{
    Properties
    {
        [NoScaleOffset]_SplatMap ("Splat Map", 2D) = "" { }
        [NoScaleOffset]_Splat0 ("Layer 0 (R)", 2D) = "white" { }
        [NoScaleOffset]_Normal0 ("Normal 0", 2D) = "white" { }
        [NoScaleOffset]_Splat1 ("Layer 1 (G)", 2D) = "white" { }
        [NoScaleOffset]_Normal1 ("Normal 1", 2D) = "white" { }
        [NoScaleOffset]_Splat2 ("Layer 2 (B)", 2D) = "white" { }
        [NoScaleOffset]_Normal2 ("Normal 2", 2D) = "white" { }
        [NoScaleOffset]_Splat3 ("Layer 3 (A)", 2D) = "white" { }
        [NoScaleOffset]_Normal3 ("Normal 3", 2D) = "white" { }

        _SplatTiling ("Detail Tiling (UV)", Vector) = (1, 1, 0, 0)
    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode" = "UniversalForward" }
            
            Cull Back
            ZWrite On
            ZTest LEqual
            
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            // #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"

            float2 _SplatTiling;

            TEXTURE2D(_SplatMap); SAMPLER(sampler_SplatMap);

            TEXTURE2D(_Splat0); SAMPLER(sampler_Splat0);
            TEXTURE2D(_Normal0); SAMPLER(sampler_Normal0);
            TEXTURE2D(_Splat1); SAMPLER(sampler_Splat1);
            TEXTURE2D(_Normal1); SAMPLER(sampler_Normal1);
            TEXTURE2D(_Splat2); SAMPLER(sampler_Splat2);
            TEXTURE2D(_Normal2); SAMPLER(sampler_Normal2);
            TEXTURE2D(_Splat3); SAMPLER(sampler_Splat3);
            TEXTURE2D(_Normal3); SAMPLER(sampler_Normal3);

            
            
            struct Attributes
            {
                float4 positionOS: POSITION;
                float2 uv: TEXCOORD0;
            };

            struct Varyings
            {
                float4 vertex: SV_POSITION;
                float2 uv: TEXCOORD0;
                float3 normal: TEXCOORD1;
            };



            Varyings vert(Attributes input)
            {
                Varyings output;

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.vertex = vertexInput.positionCS;
                output.uv = input.uv;

                return output;
            }

            float4 frag(Varyings input): SV_Target
            {
                half4 splatControl = 0;
                splatControl.rgb = SAMPLE_TEXTURE2D(_SplatMap, sampler_SplatMap, input.uv);
                splatControl.a = 1.0 - splatControl.r - splatControl.g - splatControl.b;
                
                float2 detailUV = input.uv * _SplatTiling;

                half4 albedoAlpha = 0;
                albedoAlpha = SAMPLE_TEXTURE2D(_Splat0, sampler_Splat0, detailUV) * splatControl.r;
                albedoAlpha += SAMPLE_TEXTURE2D(_Splat1, sampler_Splat1, detailUV) * splatControl.g;
                albedoAlpha += SAMPLE_TEXTURE2D(_Splat2, sampler_Splat2, detailUV) * splatControl.b;
                albedoAlpha += SAMPLE_TEXTURE2D(_Splat3, sampler_Splat3, detailUV) * splatControl.a;
                
                half4 nrm = 0;
                nrm = SAMPLE_TEXTURE2D(_Normal0, sampler_Normal0, detailUV) * splatControl.r;
                nrm += SAMPLE_TEXTURE2D(_Normal1, sampler_Normal0, detailUV) * splatControl.g;
                nrm += SAMPLE_TEXTURE2D(_Normal2, sampler_Normal0, detailUV) * splatControl.b;
                nrm += SAMPLE_TEXTURE2D(_Normal3, sampler_Normal0, detailUV) * splatControl.a;

                half3 normalTS = UnpackNormal(nrm);
                Light mlight = GetMainLight();
                half4 s = saturate(dot(_MainLightPosition, normalTS));
                
                return s * albedoAlpha * half4(mlight.color, 1);
            }
            
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}