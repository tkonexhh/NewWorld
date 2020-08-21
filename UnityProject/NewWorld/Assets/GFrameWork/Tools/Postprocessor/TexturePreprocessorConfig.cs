using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.AssetPreprocessor
{
    [System.Serializable]
    public class TexturePreprocessorConfig : BasePreprocessorConfig<TexturePreprocessorConfig>
    {

        [Header("Default Texture Settings")]
        [SerializeField] private int MaxTextureSize = 4096;
        [SerializeField] private bool EnableReadWrite = false;
        [SerializeField] private bool EnableMipmap = false;
        [SerializeField] private bool EnableMipMapStreaming = false;
        [SerializeField] private TextureImporterAlphaSource AlphaSource = TextureImporterAlphaSource.None;

        [Tooltip("By default each texture's max size will be based upon the texture's native size. Sometimes you might want to use a multiplier (such as 0.5) of that native size.")]
        [SerializeField] private float NativeTextureSizeMultiplier = 1f;

        [Header("Filtering Settings")]
        [SerializeField] private bool ForceFilterMode;
        [SerializeField] private FilterMode FilterMode = FilterMode.Bilinear;
        [SerializeField] private int AnisoLevel = 1;

        [Header("Compression Settings")]
        [SerializeField] private TextureStandalonePreprocessorConfig StandaloneConfig;
        [SerializeField] private TextureAndroidPreprocessorConfig AndroidConfig;
        [SerializeField] private TextureIOSPreprocessorConfig IOSConfig;

        public static int maxTextureSize => S.MaxTextureSize;
        public static bool enableReadWirte => S.EnableReadWrite;
        public static bool enableMipmap => S.EnableMipmap;
        public static bool enableMipmapStreaming => S.EnableMipMapStreaming;
        public static TextureImporterAlphaSource alphaSource => S.AlphaSource;
        public static float nativeTextureSizeMultiplier => S.NativeTextureSizeMultiplier;

        public static bool forceFilterMode => S.ForceFilterMode;
        public static FilterMode filterMode => S.FilterMode;
        public static int anisoLevel => S.AnisoLevel;

        public static TextureStandalonePreprocessorConfig standaloneConfig => S.StandaloneConfig;
        public static TextureAndroidPreprocessorConfig androidConfig => S.AndroidConfig;
        public static TextureIOSPreprocessorConfig iosConfig => S.IOSConfig;

    }

    [System.Serializable]
    public class TexturePlatformPreprocessorConfig
    {

        [SerializeField] public TextureCompressionQuality TextureCompressionQuality = TextureCompressionQuality.Normal;
    }

    [System.Serializable]
    public class TextureStandalonePreprocessorConfig : TexturePlatformPreprocessorConfig
    {
        [Tooltip("Format used if the texture does NOT have an alpha channel.")]
        [SerializeField] public TextureImporterFormat RGBFormat = TextureImporterFormat.Automatic;
        [Tooltip("Format used if the texture has an alpha channel.")]
        [SerializeField] public TextureImporterFormat RGBAFormat = TextureImporterFormat.Automatic;
    }

    [System.Serializable]
    public class TextureAndroidPreprocessorConfig : TexturePlatformPreprocessorConfig
    {
        [Tooltip("Format used if the texture does NOT have an alpha channel.")]
        [SerializeField] public TextureImporterFormat RGBFormat = TextureImporterFormat.ETC_RGB4;
        [Tooltip("Format used if the texture has an alpha channel.")]
        [SerializeField] public TextureImporterFormat RGBAFormat = TextureImporterFormat.ETC2_RGBA8;
    }

    [System.Serializable]
    public class TextureIOSPreprocessorConfig : TexturePlatformPreprocessorConfig
    {
        [Tooltip("Format used if the texture does NOT have an alpha channel.")]
        [SerializeField] public TextureImporterFormat RGBFormat = TextureImporterFormat.ASTC_6x6;
        [Tooltip("Format used if the texture has an alpha channel.")]
        [SerializeField] public TextureImporterFormat RGBAFormat = TextureImporterFormat.ASTC_6x6;
    }

}
