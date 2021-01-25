Shader "XHH/RendererFecture/Outline"
{
    Properties
    {
        _Color ("Outline Color", color) = (1, 1, 1, 1)
        _Width ("Outline Widht", Range(0, 1)) = 0.2
    }
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }

        

        Pass
        {
            Cull front
            ZTest off
            ZWrite Off
            Stencil
            {
                Ref 1
                Comp NotEqual
                Pass keep
            }
            
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag


            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            
            CBUFFER_START(UnityPerMaterial)
            float _Width;
            float4 _Color;
            CBUFFER_END
            
            struct Attributes
            {
                float4 positionOS: POSITION;
                float3 normalOS: NORMAL;
            };


            struct Varyings
            {
                float4 positionCS: SV_POSITION;
                float3 normalWS: NORMAL;
            };


            
            Varyings vert(Attributes input)
            {
                Varyings output;
                input.positionOS.xyz += normalize(input.normalOS) * _Width;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS, true);
                
                return output;
            }


            float4 frag(Varyings input): SV_Target
            {
                
                return _Color;
            }
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}
