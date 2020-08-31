using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.AssetPreprocessor.Editor
{
    public class ModelPostprocessor : AssetPostprocessor
    {
        private void OnPostprocessModel(GameObject model)
        {
            if (!ModelPreprocessorConfig.S.ShouldProcessAsset(assetImporter))
                return;

            Debug.Log("OnPostprocessModel=" + this.assetPath);
            var importer = assetImporter as ModelImporter;

            importer.sortHierarchyByName = ModelPreprocessorConfig.S.sortHierarchyByName;
            importer.isReadable = ModelPreprocessorConfig.S.enableReadWrite;
        }
    }
}
