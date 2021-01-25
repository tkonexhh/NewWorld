#ifndef CUSTOM_COMMON_INCLUDED
    #define CUSTOM_COMMON_INCLUDED

    float remap(float target, float oldMin, float oldMax, float newMin, float newMax)
    {
        return(target - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;
    }

    float2 remap(float2 target, float oldMin, float oldMax, float newMin, float newMax)
    {
        target.x = remap(target.x, oldMin, oldMax, newMin, newMax);
        target.y = remap(target.y, oldMin, oldMax, newMin, newMax);
        return target;//(target-oldMin)/(oldMax-oldMin)*(newMax-newMin)+newMin;
    }

    float Grey(float4 color)
    {
        return dot(color.rgb, float3(0.299, 0.587, 0.114));
    }

    float3 DecodeViewNormalStereo(float4 enc4)
    {
        float kScale = 1.7777;
        float3 nn = enc4.xyz * float3(2 * kScale, 2 * kScale, 0) + float3(-kScale, -kScale, 1);
        float g = 2.0 / dot(nn.xyz, nn.xyz);
        float3 n;
        n.xy = g * nn.xy;
        n.z = g - 1;
        return n;
    }

#endif