using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GFrame;

namespace GFrame.AssetPreprocessor
{
    //https://github.com/andrelevi/AssetPreprocessor/blob/master/Scripts/Editor/TexturePreprocessorConfig.cs
    public class BasePreprocessorConfig<T> : ScriptableObject where T : BasePreprocessorConfig<T>
    {
        #region Instance
        private static string PROJECT_CONFIG_PATH = "Config/Preprocessor/" + typeof(T).Name;
        private static T s_Instance = null;

        private static T LoadInstance()
        {
            UnityEngine.Object obj = Resources.Load(PROJECT_CONFIG_PATH);

            if (obj == null)
            {
                Log.e("#Not Find " + typeof(T).Name + " Config File");
                return null;
            }

            Log.i("#Success Load " + typeof(T).Name + " Config.");

            s_Instance = obj as T;

            return s_Instance;
        }


        public static T S
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = LoadInstance();
                }

                return s_Instance;
            }
        }
    }
    #endregion



    public class PreprocessorConfigEditor : UnityEditor.Editor
    {
        [MenuItem("Assets/GFrame/Config/Preprocessor/Build TexturePreprocessorConfig")]
        public static void BuildTexturePreprocessorConfig()
        {
            TexturePreprocessorConfig data = null;
            string folderPath = "Assets/Resources/Config/Preprocessor/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string spriteDataPath = folderPath + "TexturePreprocessorConfig.asset";
            data = AssetDatabase.LoadAssetAtPath<TexturePreprocessorConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<TexturePreprocessorConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("#Create TexturePreprocessorConfig In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}
