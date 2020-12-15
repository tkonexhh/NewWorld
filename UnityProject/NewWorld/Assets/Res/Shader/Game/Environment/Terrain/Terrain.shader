Shader "XHH/Terrain"
{
    Properties
    {
        

        [Toggle(_ANTI_REPEAT)]
        _AntiRepeat ("Enable Anti-Pereat", Float) = 1.0

        [ToggleOff(_RECEIVE_SHADOWS_OFF)]
        _ReceiveShadows ("Receive Shadows", Float) = 1.0

        [Toggle(_NORMALMAP)]
        _ApplyNormal ("Enable Normal Maps", Float) = 1.0

        [Space(10)]
        [NoScaleOffset]_SplatMap ("Splat Map", 2D) = "" { }
        [NoScaleOffset]_Splat0 ("Layer 0 (R)", 2D) = "white" { }
        [NoScaleOffset]_Normal0 ("Normal 0", 2D) = "white" { }
        [NoScaleOffset]_Splat1 ("Layer 1 (G)", 2D) = "white" { }
        [NoScaleOffset]_Normal1 ("Normal 1", 2D) = "white" { }
        [NoScaleOffset]_Splat2 ("Layer 2 (B)", 2D) = "white" { }
        [NoScaleOffset]_Normal2 ("Normal 2", 2D) = "white" { }
        [NoScaleOffset]_Splat3 ("Layer 3 (A)", 2D) = "white" { }
        [NoScaleOffset]_Normal3 ("Normal 3", 2D) = "white" { }


        _SplatTiling ("Detail Tiling (UV)", int) = 16
        [Space(5)]
        _Scale ("scale", Range(0, 1)) = 1
        _Blend ("Blend", Range(0, 1)) = 0.4
    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode" = "UniversalForward" }
            
            // Blend One Zero
            Cull Back
            // ZWrite On
            // ZTest LEqual
            
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            // -------------------------------------
            // Unity defined keywords
            #pragma shader_feature _ANTI_REPEAT
            #pragma shader_feature _NORMALMAP
            #pragma shader_feature _RECEIVE_SHADOWS_OFF

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            // #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"

            float _SplatTiling;
            float _Blend;
            float _Scale;

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
                float3 normalOS: NORMAL;
                float4 tangentOS: TANGENT;
            };

            struct Varyings
            {
                float4 vertex: SV_POSITION;
                float2 uv: TEXCOORD0;
                float3 normalWS: NORMAL;
                float3 normal: TEXCOORD1;
            };

            #ifdef _ANTI_REPEAT
                float2 hash22(float2 p)
                {
                    float3 p3 = frac(float3(p.xyx) * float3(.1031, .1030, .0973));
                    p3 += dot(p3, p3.yzx + 33.33);
                    return frac((p3.xx + p3.yz) * p3.zy);
                }

                float4 hash4(float2 p)
                {
                    return frac(sin(float4(1.0 + dot(p, float2(37.0, 17.0)),
                    2.0 + dot(p, float2(11.0, 47.0)),
                    3.0 + dot(p, float2(41.0, 29.0)),
                    4.0 + dot(p, float2(23.0, 31.0)))) * 103.0);
                }

                float2 texRandomTile(float2 uv)
                {
                    float2 iuv = floor(uv);//floor 向下取整
                    float2 fuv = frac(uv);//frac 取得小数部分

                    float4 ofa = hash4(iuv + float2(0, 0));
                    ofa.zw = sign(ofa.zw - 0.5);
                    float2 uva = uv * ofa.zw + ofa.xy;
                    return uva;

                    float2 uvScaled = uv * 3.464 * 0.7;
                    const float2x2 gridToSkewedGrid = float2x2(1.0, 0.0, -0.57735027, 1.15470054);
                }
                
                void StochasticSampleSimple_half(
                    SamplerState samplerTex,
                    //  Base inputs
                    half Blend,
                    float2 uv,
                    float stochasticScale,
                    //  Albedo
                    Texture2D textureAlbedo, Texture2D textureNormal,
                    // half normalScale,
                    // //  MetallicSpecular
                    // Texture2D textureMetallicSpec,
                    // //  MaskMap
                    // Texture2D textureMask,
                    //  Output
                    out half3 FinalAlbedo, out half3 FinalNormal//,
                    // out half FinalAlpha,
                    // out half4 FinalMetallicSpecular,
                    // out half4 FinalMask
                )
                {
                    float2 uvScaled = uv * 3.464 * stochasticScale; // 2 * sqrt(3)
                    const float2x2 gridToSkewedGrid = float2x2(1.0, 0.0, -0.57735027, 1.15470054);
                    float2 skewedCoord = mul(gridToSkewedGrid, uvScaled);
                    int2 baseId = int2(floor(skewedCoord));
                    float3 temp = float3(frac(skewedCoord), 0);
                    temp.z = 1.0 - temp.x - temp.y;
                    half w1, w2, w3;
                    int2 vertex1, vertex2, vertex3;
                    if (temp.z > 0.0)
                    {
                        w1 = temp.z;
                        w2 = temp.y;
                        w3 = temp.x;
                        vertex1 = baseId;
                        vertex2 = baseId + int2(0, 1);
                        vertex3 = baseId + int2(1, 0);
                    }
                    else
                    {
                        w1 = -temp.z;
                        w2 = 1.0 - temp.y;
                        w3 = 1.0 - temp.x;
                        vertex1 = baseId + int2(1, 1);
                        vertex2 = baseId + int2(1, 0);
                        vertex3 = baseId + int2(0, 1);
                    }

                    const float2x2 hashMatrix = float2x2(127.1, 311.7, 269.5, 183.3);
                    const float hashFactor = 3758.5453;
                    float2 uv1 = uv + frac(sin(mul(hashMatrix, (float2)vertex1)) * hashFactor);
                    float2 uv2 = uv + frac(sin(mul(hashMatrix, (float2)vertex2)) * hashFactor);
                    float2 uv3 = uv + frac(sin(mul(hashMatrix, (float2)vertex3)) * hashFactor);

                    //  Use a hash function which does not include sin
                    //  Adds a little bit visible tiling...
                    // float2 uv1 = uv + hash22((float2)vertex1);
                    // float2 uv2 = uv + hash22((float2)vertex2);
                    // float2 uv3 = uv + hash22((float2)vertex3);

                    float2 duvdx = ddx(uv);
                    float2 duvdy = ddy(uv);

                    //  Here we have to sample first as we want to calculate the wights based on luminance
                    //  Albedo – Sample Gaussion values from transformed input
                    half4 G1 = SAMPLE_TEXTURE2D_GRAD(textureAlbedo, samplerTex, uv1, duvdx, duvdy);
                    half4 G2 = SAMPLE_TEXTURE2D_GRAD(textureAlbedo, samplerTex, uv2, duvdx, duvdy);
                    half4 G3 = SAMPLE_TEXTURE2D_GRAD(textureAlbedo, samplerTex, uv3, duvdx, duvdy);

                    w1 *= Luminance(G1.rgb);
                    w2 *= Luminance(G2.rgb);
                    w3 *= Luminance(G3.rgb);
                    
                    //  Get weights
                    half exponent = 1.0h + Blend * 15.0h;
                    w1 = pow(w1, exponent);
                    w2 = pow(w2, exponent);
                    w3 = pow(w3, exponent);

                    //  Lets help the compiler here:
                    half sum = 1.0h / (w1 + w2 + w3);
                    w1 = w1 * sum;
                    w2 = w2 * sum;
                    w3 = w3 * sum;
                    
                    //  Albedo
                    half4 G = w1 * G1 + w2 * G2 + w3 * G3;
                    FinalAlbedo = G.rgb;
                    // FinalAlpha = G.a;

                    //  Normal
                    half4 N1 = SAMPLE_TEXTURE2D_GRAD(textureNormal, samplerTex, uv1, duvdx, duvdy);
                    half4 N2 = SAMPLE_TEXTURE2D_GRAD(textureNormal, samplerTex, uv2, duvdx, duvdy);
                    half4 N3 = SAMPLE_TEXTURE2D_GRAD(textureNormal, samplerTex, uv3, duvdx, duvdy);
                    half4 N = w1 * N1 + w2 * N2 + w3 * N3;
                    
                    FinalNormal = UnpackNormalmapRGorAG(N, 1);
                }
            #endif

            Varyings vert(Attributes input)
            {
                Varyings output;

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                output.vertex = vertexInput.positionCS;
                VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);
                output.normalWS = normalInput.normalWS;
                output.uv = input.uv;

                return output;
            }

            float4 frag(Varyings input): SV_Target
            {
                half4 splatControl = 0;
                splatControl.rgb = SAMPLE_TEXTURE2D(_SplatMap, sampler_SplatMap, input.uv);
                splatControl.a = 1.0 - splatControl.r - splatControl.g - splatControl.b;
                
                float2 detailUV = input.uv * (_SplatTiling, _SplatTiling);
                
                // #ifdef _ANTI_REPEAT
                //     detailUV = texRandomTile(detailUV);
                // #endif
                // half4 albedoAlpha = 0;
                // albedoAlpha = SAMPLE_TEXTURE2D(_Splat0, sampler_Splat0, detailUV) * splatControl.r;
                // albedoAlpha += SAMPLE_TEXTURE2D(_Splat1, sampler_Splat1, detailUV) * splatControl.g;
                // albedoAlpha += SAMPLE_TEXTURE2D(_Splat2, sampler_Splat2, detailUV) * splatControl.b;
                // albedoAlpha += SAMPLE_TEXTURE2D(_Splat3, sampler_Splat3, detailUV) * splatControl.a;

                
                Light mlight = GetMainLight();
                half4 finalColor = half4(mlight.color, 1) * 2;

                #ifdef _NORMALMAP
                    // half4 nrm = 0;
                    // nrm = SAMPLE_TEXTURE2D(_Normal0, sampler_Normal0, detailUV) * splatControl.r;
                    // nrm += SAMPLE_TEXTURE2D(_Normal1, sampler_Normal0, detailUV) * splatControl.g;
                    // nrm += SAMPLE_TEXTURE2D(_Normal2, sampler_Normal0, detailUV) * splatControl.b;
                    // nrm += SAMPLE_TEXTURE2D(_Normal3, sampler_Normal0, detailUV) * splatControl.a;
                    // half3 normalTS = UnpackNormal(nrm);
                    
                    half3 normalTS = 0;
                    #ifdef _ANTI_REPEAT
                        half3 lastcolor = 0;
                        half3 colorSplat = 0;
                        half3 norl = 0;
                        half3 normalSplat = 0;
                        StochasticSampleSimple_half(sampler_Splat0, _Blend, detailUV, _Scale, _Splat0, _Normal0, colorSplat, normalSplat);
                        lastcolor += colorSplat * splatControl.r;
                        norl += normalSplat * splatControl.r;
                        StochasticSampleSimple_half(sampler_Splat1, _Blend, detailUV, _Scale, _Splat1, _Normal1, colorSplat, normalSplat);
                        lastcolor += colorSplat * splatControl.g;
                        norl += normalSplat * splatControl.g;
                        StochasticSampleSimple_half(sampler_Splat2, _Blend, detailUV, _Scale, _Splat2, _Normal2, colorSplat, normalSplat);
                        lastcolor += colorSplat * splatControl.b;
                        norl += normalSplat * splatControl.b;
                        StochasticSampleSimple_half(sampler_Splat3, _Blend, detailUV, _Scale, _Splat3, _Normal3, colorSplat, normalSplat);
                        lastcolor += colorSplat * splatControl.a;
                        norl += normalSplat * splatControl.a;
                        finalColor.xyz *= lastcolor.xyz;
                        normalTS = norl;
                        // return half4(normalTS, 1);
                    #else
                        half4 nrm = 0;
                        nrm = SAMPLE_TEXTURE2D(_Normal0, sampler_Normal0, detailUV) * splatControl.r;
                        nrm += SAMPLE_TEXTURE2D(_Normal1, sampler_Normal0, detailUV) * splatControl.g;
                        nrm += SAMPLE_TEXTURE2D(_Normal2, sampler_Normal0, detailUV) * splatControl.b;
                        nrm += SAMPLE_TEXTURE2D(_Normal3, sampler_Normal0, detailUV) * splatControl.a;
                        normalTS = UnpackNormal(nrm);
                    #endif
                    // normalTS = normalize(normalTS);
                    half4 diffuseNormal = saturate(dot(_MainLightPosition, normalTS));
                    finalColor *= diffuseNormal;
                    // return diffuseNormal;
                #endif
                
                half4 diffuse = saturate(dot(_MainLightPosition, input.normalWS));
                finalColor *= diffuse ;
                return finalColor ;
            }
            
            ENDHLSL
            
        }
    }
    FallBack "Diffuse"
}