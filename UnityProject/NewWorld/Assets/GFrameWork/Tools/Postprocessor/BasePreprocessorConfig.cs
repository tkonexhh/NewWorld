using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        #endregion

        [Header("Config Settings")]

        [Tooltip("Whether this config should be considered when processing assets.")]
        [SerializeField] private bool IsEnabled = true;

        public static bool isEnabled => S.IsEnabled;
    }



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

        [MenuItem("Assets/GFrame/Config/Preprocessor/Build AudioPreprocessorConfig")]
        public static void BuildAudioPreprocessorConfig()
        {
            AudioPreprocessorConfig data = null;
            string folderPath = "Assets/Resources/Config/Preprocessor/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string spriteDataPath = folderPath + "AudioPreprocessorConfig.asset";
            data = AssetDatabase.LoadAssetAtPath<AudioPreprocessorConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<AudioPreprocessorConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("#Create AudioPreprocessorConfig In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("Assets/GFrame/Config/Preprocessor/Build ModelPreprocessorConfig")]
        public static void BuildModelPreprocessorConfig()
        {
            ModelPreprocessorConfig data = null;
            string folderPath = "Assets/Resources/Config/Preprocessor/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string spriteDataPath = folderPath + "ModelPreprocessorConfig.asset";
            data = AssetDatabase.LoadAssetAtPath<ModelPreprocessorConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<ModelPreprocessorConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("#Create ModelPreprocessorConfig In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}
