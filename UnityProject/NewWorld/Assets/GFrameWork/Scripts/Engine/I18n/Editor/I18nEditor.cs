using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.I18N
{
    public class I18nEditor : EditorWindow
    {
        private static I18nEditor m_Window;

        private readonly List<EditorTab> m_Tabs = new List<EditorTab>();
        private int m_SelectTabIndex = 0;
        private int m_PreSelectTabIndex = -1;
        private static I18NConfig config;

        [MenuItem("Tools/GFrame/多语言配置工具")]
        private static void ShowWindow()
        {
            string folderPath = "Assets/Resources/Config/";
            FileHelper.CreateDirctory(PathHelper.AssetsPath2ABSPath(folderPath));
            string dataPath = folderPath + "I18NConfig.asset";
            config = AssetDatabase.LoadAssetAtPath<I18NConfig>(dataPath);
            if (config == null)
            {
                config = ScriptableObject.CreateInstance<I18NConfig>();
                AssetDatabase.CreateAsset(config, dataPath);
            }

            m_Window = GetWindow<I18nEditor>();
            m_Window.Show();
        }

        private void OnEnable()
        {
            m_Tabs.Add(new I18nTextTab());
            m_Tabs.Add(new I18nImageTab());
            m_Tabs.Add(new I18nAreaTab());
        }

        private void OnGUI()
        {
            m_SelectTabIndex = GUILayout.Toolbar(m_SelectTabIndex, new[] { "Text", "Image", "Area" });
            if (m_SelectTabIndex >= 0 && m_SelectTabIndex < m_Tabs.Count)
            {
                var selectEditor = m_Tabs[m_SelectTabIndex];
                if (m_PreSelectTabIndex != m_SelectTabIndex)
                {
                    selectEditor.OnOpen(config);
                }
                selectEditor.OnDraw();
                m_PreSelectTabIndex = m_SelectTabIndex;
            }
        }


    }
}
