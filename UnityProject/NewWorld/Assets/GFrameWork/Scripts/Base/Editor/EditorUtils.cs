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
    }
}