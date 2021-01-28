Shader "XHH/Post/Scan"
{
    Properties
    {
        [HideInInspector]_MainTex ("Base (RGB)", 2D) = "white" { }
        _ScanRange ("Scan Depth", Range(0, 100)) = 0
        _MaxRange ("Max Depth", float) = 200
        _ScanWidth ("Scan Width", float) = 1
        _ScanCenter ("ScanCenter", vector) = (0, 0, 0, 0)
        _Temp1 ("Temp1", float) = 100
        _Temp2 ("Temp2", Range(-0.5, 5)) = 100
        _StepFogTex ("StepFogTex", 2D) = "white" { }
        _LineColor ("LineColor", Color) = (1, 1, 1, 1)


        [Header(Kernel)]//卷积核
        _Slope1 ("Slope 1", vector) = (0, 0, 0, 0)
        _Slope2 ("Slope 2", vector) = (0, 0, 0, 0)
        _Slope3 ("Slope 3", vector) = (0, 0, 0, 0)
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
            #include "../CustomHlsl/CustomHlsl.hlsl"

            CBUFFER_START(UnityPerMaterial)
            float _ScanRange, _MaxRange, _ScanWidth;
            float3 _ScanCenter;
            float4x4 _FarClipRay;
            float4x4 _CameraToWorld;
            float _Temp1, _Temp2;
            float4 _LineColor;

            float3 _Slope1, _Slope2, _Slope3;
            float4 _MainTex_TexelSize;
            CBUFFER_END
            TEXTURE2D(_MainTex);SAMPLER(sampler_MainTex);
            TEXTURE2D(_CameraDepthTexture); SAMPLER(sampler_CameraDepthTexture);
            TEXTURE2D(_CameraDepthNormalsTexture);
            TEXTURE2D(_StepFogTex);

            

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

            half Edge(Texture2D tex, SamplerState sampleState, float2 uv, float2 texelSize)
            {
                const half Gx[9] = {
                    - 1, 0, 1,
                    - 2, 0, 2,
                    - 1, 0, 1
                };

                const half Gy[9] = {
                    - 1, -2, -1,
                    0, 0, 0,
                    1, 2, 1
                };

                half edgeX, edgeY;
                for (int x = -1; x < 2; x ++)
                {
                    for (int y = -1; y < 2; y ++)
                    {
                        half dx = texelSize.x * x;
                        half dy = texelSize.y * y;
                        half color = SAMPLE_TEXTURE2D(tex, sampleState, uv + half2(dx, dy));
                        color = Grey(color);
                        edgeX += Gx[(x + 1) * 3 + y + 1] * color;
                        edgeY += Gy[(x + 1) * 3 + y + 1] * color;
                    }
                }
                

                return(abs(edgeX) + abs(edgeY));
            }


            half edge2(half2 uv, float2 xy)
            {
                half offset = 0;
                half center = Linear01Depth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, uv), _ZBufferParams);
                for (int i = -1; i < 2; i ++)
                {
                    for (int j = -1; j < 2; j ++)
                    {
                        offset += center - Linear01Depth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, uv +
                        half2(i * xy.x, j * xy.y)), _ZBufferParams);
                    }
                }
                return abs(offset) * 10000;
            }

            float4 frag(Varyings input): SV_Target
            {
                float4 var_Screen = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, input.uv);
                
                float linearDepth = Linear01Depth(depth, _ZBufferParams);
                float3 pixelWorldPos = _WorldSpaceCameraPos + linearDepth * input.interpolatedRay;

                pixelWorldPos.y = _ScanCenter.y;//向上全部归内
                float pixelDistance = distance(pixelWorldPos, _ScanCenter);
                
                float edge = saturate(edge2(input.uv, _MainTex_TexelSize));
                float edgeCircleMask = 1 - saturate(round(sin(pixelDistance * _Temp1) + _Temp2)) + edge;
                float centerCircleMask = saturate(pow(pixelDistance / 20, 2));//中间透明区
                // return centerCircleMask;
                float4 var_Scan = (edgeCircleMask) * _LineColor + var_Screen;

                if (_ScanRange - pixelDistance > 0 && linearDepth < 1)
                {
                    real scanPercent = 1 - (_ScanRange - pixelDistance) / _ScanWidth;
                    real maxPercent = 1 - (_MaxRange - pixelDistance) / _ScanWidth;
                    real percent = lerp(1, 0, saturate(scanPercent / maxPercent));
                    
                    return pow(percent, 10) * _LineColor * (1 + 2 * edgeCircleMask) + var_Screen;

                    // return pow(percent, 20) * _LineColor * centerCircleMask + percent * edgeCircleMask * centerCircleMask * _LineColor * 2 + var_Screen;
                }

                
                return var_Screen;
            }
            
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}