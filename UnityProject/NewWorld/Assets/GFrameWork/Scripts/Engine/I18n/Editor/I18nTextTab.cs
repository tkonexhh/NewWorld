using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.I18N
{
    public class I18nTextTab : EditorTab
    {
        private Vector2 pos;
        public override void OnOpen(I18NConfig config)
        {
            base.OnOpen(config);
            Log.e("I18nTextTab open");
        }

        public override void OnDraw()
        {
            // var rect = EditorGUILayout.GetControlRect();
            // pos = EditorGUILayout.BeginScrollView(pos, GUILayout.Width(rect.width * 0.5f));
            GUILayout.BeginVertical();

            for (int i = 0; i < config.keys.Count; i++)
            {
                GUILayout.Label(config.keys[i].key);
                for (int j = 0; j < config.areas.Count; j++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(config.areas[j].name, I18NDefine.arealabelWith);
                    GUILayout.TextField(config.keys[i].languages[j].value);
                    GUILayout.EndHorizontal();
                }
            }

            GUILayout.EndVertical();
            //EditorGUILayout.EndScrollView();
        }

        private void Save()
        {
            I18NConfig config = null;
            string folderPath = "Assets/Resources/Config/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string dataPath = folderPath + "I18NConfig.asset";
            config = AssetDatabase.LoadAssetAtPath<I18NConfig>(dataPath);
            if (config == null)
            {
                config = ScriptableObject.CreateInstance<I18NConfig>();
                AssetDatabase.CreateAsset(config, dataPath);
            }

            config.SetAreaInfo(new[] { "CN", "JP" });
            config.SetKey(new[] { "name", "value" });
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }
    }


}
