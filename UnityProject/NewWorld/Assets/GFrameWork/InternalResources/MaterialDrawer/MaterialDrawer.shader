
Shader "XHH/MaterialDrawer"
{
    Properties
    {
        _MainTex ("MainTex", 2D) = "White" { }
        [NoScaleOffset] _NoSTMainTex ("MainTex", 2D) = "White" { }
        [NORMAL] _NormalTex ("MainTex", 2D) = "bump" { }
        [Vector2]_Vector2 ("Vector2", vector) = (1, 1, 1, 1)
        [Vector3]_Vector3 ("Vector3", vector) = (1, 1, 1, 1)
        [Vector2Int]_Vector2Int ("Vector2Int", vector) = (1, 1, 1, 1)
        [Vector3Int]_Vector3Int ("Vector3Int", vector) = (1, 1, 1, 1)
        _Color ("Color", Color) = (1, 1, 1, 1)
        [HDR]_HDRColor ("Color", Color) = (1, 1, 1, 1)
        _Alpha ("Alpha", Range(0, 255)) = 100//虽然直接拖也是int，但是可以输入float
        [IntRange] _AlphaInt ("Alpha", Range(0, 255)) = 100
        [Enum(UnityEngine.Rendering.BlendMode)] _Blend ("Blend mode", Float) = 1
        [Enum(One, 1, SrcAlpha, 5)] _Blend2 ("Blend mode subset", Float) = 1
        [Toggle(ENABLE_TOGGLE)] _Toggle ("Toggle?", Float) = 0
    }
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }

        Pass
        {
            Tags { "LightMode" = "UniversalForward" }
            
            Cull Back
            
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag


            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            
            CBUFFER_START(UnityPerMaterial)


            CBUFFER_END

            TEXTURE2D(_MainTex);SAMPLER(sampler_MainTex);
            
            struct Attributes
            {
                float4 positionOS: POSITION;
                float2 uv: TEXCOORD0;
                float3 normalOS: NORMAL;
            };


            struct Varyings
            {
                float4 positionCS: SV_POSITION;
                float2 uv: TEXCOORD0;
                float3 normalWS: NORMAL;
            };


            
            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS, true);
                output.uv = input.uv;


                return output;
            }


            float4 frag(Varyings input): SV_Target
            {
                half4 var_MainTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                return var_MainTex;
            }
            
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}
