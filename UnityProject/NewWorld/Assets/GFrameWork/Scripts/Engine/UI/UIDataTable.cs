/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UIDataTable.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 1:49:04 PM
	Tip:7/7/2020 1:49:04 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class UIDataTable
    {
        private static Dictionary<int, UIData> s_UIDataMap = new Dictionary<int, UIData>();
        private static LoadStrategy m_LoadStrategy = LoadStrategy.Resource;

        public static void SetLoadMode(LoadStrategy loadMode)
        {
            m_LoadStrategy = loadMode;
        }

        public static void AddPanelData<T>(T uiID, string path, bool singleton = true, int cacheCount = 1) where T : System.IConvertible
        {
            Add(new PanelData(uiID.ToInt32(null), path, singleton, cacheCount, m_LoadStrategy));
        }

        private static void Add(UIData data)
        {
            if (data == null) return;

            if (s_UIDataMap.ContainsKey(data.uiID))
            {
                Log.w("#Already Add UIID:" + data.uiID);
                return;
            }

            s_UIDataMap.Add(data.uiID, data);
        }

        public static UIData Get<T>(T uiID) where T : System.IConvertible
        {
            UIData result = null;

            if (s_UIDataMap.TryGetValue(uiID.ToInt32(null), out result))
            {
                return result;
            }
            Log.e("#InValid UIID:" + uiID.ToInt32(null));
            return null;
        }
    }

}