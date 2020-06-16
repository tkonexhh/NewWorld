using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.Editor
{
    [CustomEditor(typeof(ProjectPathConfig), false)]
    public class ProjectPathConfigEditor : UnityEditor.Editor
    {
        [MenuItem("Assets/GFrame/Config/Build ProjectConfig")]
        public static void BuildConfig()
        {
            ProjectPathConfig data = null;
            string folderPath = "Assets/Resources/Config/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string spriteDataPath = folderPath + "ProjectPathConfig.asset";
            data = AssetDatabase.LoadAssetAtPath<ProjectPathConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<ProjectPathConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("#Create ProjectPathConfig In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}
