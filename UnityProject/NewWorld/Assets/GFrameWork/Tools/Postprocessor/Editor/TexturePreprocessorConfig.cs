using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.AssetPreprocessor.Editor
{
    [CreateAssetMenu(menuName = "GFrame/AssetPreprocessor/TexturePreprocessorConfig")]

    public class TexturePreprocessorConfig : BasePreprocessorConfig
    {
        [Header("Platforms")]
        public List<string> PlatformsRegexList = new List<string>
        {
            "Android",
            "iOS",
            "Standalone",
        };


        [Header("Texture Settings")]
        public int MaxTextureSize = 4096;
        public bool EnableReadWrite = false;
        public bool GenerateMipMaps = false;


        [Header("Compression Settings")]
        [Tooltip("Format used if the texture does NOT have an alpha channel.")]
        public TextureImporterFormat RGBFormat = TextureImporterFormat.Automatic;
        [Tooltip("Format used if the texture has an alpha channel.")]
        public TextureImporterFormat RGBAFormat = TextureImporterFormat.Automatic;
        public TextureCompressionQuality TextureCompressionQuality = TextureCompressionQuality.Normal;
    }
}
