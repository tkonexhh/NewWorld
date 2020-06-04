using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.I18N
{
    public class I18NConfig : ScriptableObject
    {
        public List<KeyInfo> keys = new List<KeyInfo>();
        public List<AreaInfo> areas = new List<AreaInfo>();



        public void SetKey(string[] keys)
        {
            this.keys.Clear();
            foreach (var key in keys)
            {
                KeyInfo info = new KeyInfo();
                info.key = key;
                info.languages = new List<LanguageInfo>();
                foreach (var area in areas)
                {
                    LanguageInfo languageInfo = new LanguageInfo();
                    languageInfo.areaName = area.name;
                    languageInfo.value = "123";
                    info.languages.Add(languageInfo);
                }
                this.keys.Add(info);
            }
        }

        public void SetAreaInfo(string[] areas)
        {
            this.areas.Clear();
            foreach (var area in areas)
            {
                this.areas.Add(new AreaInfo { name = area });
            }
        }

        [Serializable]
        public class KeyInfo
        {
            public string key;
            public List<LanguageInfo> languages;
        }

        [Serializable]
        public class LanguageInfo
        {
            public string areaName;
            public string value;
        }

        [Serializable]
        public class AreaInfo
        {
            public string name;
        }
    }
}
