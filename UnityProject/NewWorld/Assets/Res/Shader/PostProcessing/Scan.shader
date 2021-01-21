Shader "XHH/Post/Scan"
{
    Properties
    {
        [HideInInspector]_MainTex ("Base (RGB)", 2D) = "white" { }
        _ScanDepth ("Scan Depth", Range(0, 1)) = 0
        _ScanWidth ("Scan Width", float) = 1
        _ScanCenter ("ScanCenter", vector) = (0, 0, 0, 0)
    }
    SubShader
    {
        Pass
        {
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"


            CBUFFER_START(UnityPerMaterial)
            float _ScanDepth, _ScanWidth;
            float3 _ScanCenter;
            float4x4 _FarClipRay;
            CBUFFER_END
            TEXTURE2D(_MainTex);SAMPLER(sampler_MainTex);
            TEXTURE2D(_CameraDepthTexture); SAMPLER(sampler_CameraDepthTexture);

            struct Attributes
            {
                float4 positionOS: POSITION;
                float2 uv: TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS: SV_POSITION;
                float2 uv: TEXCOORD0;
                float4 interpolatedRay: TEXCOORD2;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                
                output.uv = input.uv;


                int index = 0;//屏幕相当于Quad 就只有四个顶点
                if (input.uv.x < 0.5 && input.uv.y < 0.5)//左下角
                {
                    index = 0;
                }
                else if (input.uv.x > 0.5 && input.uv.y < 0.5)//右下角
                {
                    index = 1;
                }
                else if (input.uv.x > 0.5 && input.uv.y > 0.5)//右上角
                {
                    index = 2;
                }
                else//左上角
                {
                    index = 3;
                }
                //四个点确定了，在像素阶段，所有点都会差值
                //_FarClipRay里面记录了像素到四个角相对相机的坐标，那么对于屏幕中的任何一个点而言，这个interpolatedRay 就是相机点到这个像素点的坐标
                //坐标有了在乘以深度信息 就有了这个点相对于相机的坐标 ，在加上相机的世界坐标就得到了像素点的世界坐标
                
                output.interpolatedRay = _FarClipRay[index];

                return output;
            }

            float4 frag(Varyings input): SV_Target
            {
                float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, input.uv);
                float linearDepth = Linear01Depth(depth, _ZBufferParams);
                // return linearDepth;
                float3 pixelWorldPos = _WorldSpaceCameraPos + linearDepth * input.interpolatedRay;
                float pixelDistance = distance(pixelWorldPos, _ScanCenter);
                // return float4(_ScanCenter, 1);
                return pixelDistance < _ScanWidth?0: color;
                
                return float4(pixelWorldPos, 1);
                

                //通过像素深度是否在扫描的一定范围
                if (linearDepth < _ScanDepth && linearDepth > _ScanDepth - _ScanWidth && linearDepth < 1)
                {
                    float diff = 1 - (_ScanDepth - linearDepth) / (_ScanWidth);
                    // _ScanColor *= diff;
                    return lerp(color, float4(1, 0, 0, 1), diff);
                }
                return color ;
            }
            
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}