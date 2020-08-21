/************************
	FileName:/GFrameWork/Tools/AssetPostprocessor/TexturePostprocessor.cs
	CreateAuthor:xuhonghua
	CreateTime:8/20/2020 11:21:39 PM
	Tip:8/20/2020 11:21:39 PM
************************/


using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace GFrame.AssetPreprocessor.Editor
{
    public class TexturePostprocessor : AssetPostprocessor
    {
        public void OnPreprocessTexture()
        {
            Debug.Log("OnPreProcessTexture=" + this.assetPath);
            TextureImporter importer = this.assetImporter as TextureImporter;
            if (importer == null) return;


            importer.mipmapEnabled = TexturePreprocessorConfig.enableMipmap;
            importer.streamingMipmaps = TexturePreprocessorConfig.enableMipmapStreaming;
            //if (importer.alphaSource != TexturePreprocessorConfig.alphaSource)
            //importer.alphaSource = TexturePreprocessorConfig.alphaSource;

            if (TexturePreprocessorConfig.enableReadWirte && !importer.isReadable)
            {
                Debug.Log("Enabling Read/Write." + importer.name);
                importer.isReadable = true;
            }

            if (TexturePreprocessorConfig.forceFilterMode)
            {
                importer.anisoLevel = TexturePreprocessorConfig.anisoLevel;
                importer.filterMode = TexturePreprocessorConfig.filterMode;
            }

            var nativeTextureSize = GetOriginalTextureSize(importer);
            var nativeSize = Mathf.NextPowerOfTwo(Mathf.Max(nativeTextureSize.width, nativeTextureSize.height));
            var maxTextureSize = TexturePreprocessorConfig.maxTextureSize;
            var multipliedNativeRes = Mathf.RoundToInt(nativeSize * TexturePreprocessorConfig.nativeTextureSizeMultiplier);
            var textureSize = Mathf.Min(multipliedNativeRes, maxTextureSize);

            // importer.textureType = TextureImporterType.Sprite;
            // importer.spriteImportMode = SpriteImportMode.Single;

            var hasAlpha = importer.DoesSourceTextureHaveAlpha();

            SetTextureImporterStandaloneSetting(importer, textureSize,
                hasAlpha ? TexturePreprocessorConfig.standaloneConfig.RGBAFormat : TexturePreprocessorConfig.standaloneConfig.RGBFormat);
            SetTextureImporterAndroidSetting(importer, textureSize,
                hasAlpha ? TexturePreprocessorConfig.androidConfig.RGBAFormat : TexturePreprocessorConfig.androidConfig.RGBFormat);
            // SetTextureImporterIOSSetting(importer, textureSize,
            //     hasAlpha ? TexturePreprocessorConfig.iosConfig.RGBAFormat : TexturePreprocessorConfig.iosConfig.RGBFormat);
        }

        private static void SetTextureImporterStandaloneSetting(TextureImporter textureImporter, int textureSize, TextureImporterFormat format)
        {
            textureImporter.SetPlatformTextureSettings(new TextureImporterPlatformSettings
            {
                overridden = true,
                name = "Standalone",
                maxTextureSize = textureSize,
                format = format,
                compressionQuality = (int)TexturePreprocessorConfig.standaloneConfig.TextureCompressionQuality,
                allowsAlphaSplitting = false,
            });
        }

        private static void SetTextureImporterAndroidSetting(TextureImporter textureImporter, int textureSize, TextureImporterFormat format)
        {
            textureImporter.SetPlatformTextureSettings(new TextureImporterPlatformSettings
            {
                overridden = true,
                name = "Android",
                maxTextureSize = textureSize,
                format = format,
                compressionQuality = (int)TexturePreprocessorConfig.androidConfig.TextureCompressionQuality,
                allowsAlphaSplitting = false,
            });
        }

        private static void SetTextureImporterIOSSetting(TextureImporter textureImporter, int textureSize, TextureImporterFormat format)
        {
            textureImporter.SetPlatformTextureSettings(new TextureImporterPlatformSettings
            {
                overridden = true,
                name = "iOS",
                maxTextureSize = textureSize,
                format = format,
                compressionQuality = (int)TexturePreprocessorConfig.iosConfig.TextureCompressionQuality,
                allowsAlphaSplitting = false,
            });
        }

        // private static void SetTextureImporterPlatformSetting(TextureImporter textureImporter, int textureSize, TextureImporterFormat format)
        // {
        //     Debug.Log($"Setting: {textureSize} | Format: {format} ");

        //     TexturePreprocessorConfig.platformsRegexList.ForEach(platformRegexString =>
        //     {
        //         textureImporter.SetPlatformTextureSettings(new TextureImporterPlatformSettings
        //         {
        //             overridden = true,
        //             name = platformRegexString,
        //             maxTextureSize = textureSize,
        //             format = format,
        //             //compressionQuality = (int)config.TextureCompressionQuality,
        //             allowsAlphaSplitting = false
        //         });
        //     });

        // }


        private static Size GetOriginalTextureSize(TextureImporter importer)
        {
            if (_getImageSizeDelegate == null)
            {
                var method = typeof(TextureImporter).GetMethod("GetWidthAndHeight", BindingFlags.NonPublic | BindingFlags.Instance);
                _getImageSizeDelegate = Delegate.CreateDelegate(typeof(GetImageSize), null, method) as GetImageSize;
            }

            var size = new Size();

            _getImageSizeDelegate(importer, ref size.width, ref size.height);

            return size;
        }

        private delegate void GetImageSize(TextureImporter importer, ref int width, ref int height);
        private static GetImageSize _getImageSizeDelegate;

        private struct Size
        {
            public int width;
            public int height;
        }

    }
}