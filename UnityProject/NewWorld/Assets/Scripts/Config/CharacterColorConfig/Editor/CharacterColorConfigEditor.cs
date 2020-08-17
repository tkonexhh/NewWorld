using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GFrame;
using Game.Logic;

namespace GameWish.Editor
{
    [CustomEditor(typeof(CharacterColorConfig), false)]
    public class CharacterColorConfigEditor : UnityEditor.Editor
    {
        [MenuItem("Assets/Game/Config/Build CharacterColorConfig")]
        public static void BuildConfig()
        {
            CharacterColorConfig data = null;
            string folderPath = "Assets/Resources/Config/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string spriteDataPath = folderPath + "CharacterColorConfig.asset";
            data = AssetDatabase.LoadAssetAtPath<CharacterColorConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<CharacterColorConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("#Create CharacterColorConfig In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}
