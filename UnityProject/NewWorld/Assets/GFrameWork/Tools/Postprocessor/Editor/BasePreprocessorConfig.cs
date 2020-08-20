using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.AssetPreprocessor.Editor
{
    //https://github.com/andrelevi/AssetPreprocessor/blob/master/Scripts/Editor/TexturePreprocessorConfig.cs
    public class BasePreprocessorConfig : ScriptableObject//<T> where T : TScriptableObjectSingleton<T>
    {

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
    }
}
