/************************
	FileName:/GFrameWork/Tools/AssetPostprocessor/TexturePostprocessor.cs
	CreateAuthor:xuhonghua
	CreateTime:8/20/2020 11:21:39 PM
	Tip:8/20/2020 11:21:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Game.Logic
{
    public class TexturePostprocessor : AssetPostprocessor
    {
        public void OnPreprocessTexture()
        {
            Debug.Log("OnPreProcessTexture=" + this.assetPath);
            TextureImporter importer = this.assetImporter as TextureImporter;
            if (importer == null) return;

            importer.mipmapEnabled = false;
            var hasAlpha = importer.DoesSourceTextureHaveAlpha();

            importer.maxTextureSize = 2048;
            // /importer.androidETC2FallbackOverride =
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
        }

    }

}