using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.Editor
{
    public class EditorUtils
    {
        [MenuItem("Tools/GFrame/Init", false, 0)]
        public static void GFrameInit()
        {
            List<string> createPath = new List<string>(){
                "Assets/Resources/Config/",
                "Assets/AddressableRes/FileMode/",
                "Assets/AddressableRes/FolderMode/",
                "Assets/Res/",
                "Assets/Scripts/",
            };

            foreach (var path in createPath)
            {
                FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(path));
            }

            ProjectPathConfigEditor.BuildConfig();
            ProjectDefaultConfigEditor.BuildConfig();

            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/GFrame/Module", false, 1)]
        public static void GFrameModule()
        {

        }


        public static string GetRootResourcesPath()
        {
            return Application.dataPath + "/Resources";
        }
    }
}