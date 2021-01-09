using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GFrame.AssetPreprocessor;

namespace GFrame.Editor
{
    public class EditorUtils
    {
        [MenuItem("Tools/GFrame/Init", false, 0)]
        public static void GFrameInit()
        {

            ProjectPathConfigEditor.BuildConfig();
            ProjectDefaultConfigEditor.BuildConfig();
            PreprocessorConfigEditor.BuildTexturePreprocessorConfig();

            List<string> createPath = new List<string>(){
                "Assets/Resources/Config/",
                "Assets/AddressableRes/FileMode/",
                "Assets/AddressableRes/FolderMode/",
                "Assets/Scripts/",
                "Assets/"+ ProjectPathConfig.DataBasePath,
                "Assets/"+ ProjectPathConfig.tableCsharpPath+"Generate/",
                "Assets/"+ ProjectPathConfig.tableCsharpPath+"Extend/",
            };

            foreach (var path in createPath)
            {
                FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(path));
            }

            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/GFrame/Allocate Engine Define", false, 1)]
        public static void AllocateEngineDefine()
        {
            //    projec
            var asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/Tagmanager.asset");
            if (asset != null)
            { // sanity checking
                var so = new SerializedObject(asset);
                var tags = so.FindProperty("tags");
                var numTags = tags.arraySize;
                for (int i = 0; i < numTags; i++)
                {
                    var existingTag = tags.GetArrayElementAtIndex(i);
                    Debug.LogError(existingTag.name);
                }
            }

        }
    }
}