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
        private static Dictionary<int, UIData> m_UIDataMap = new Dictionary<int, UIData>();

        public static void AddPanelData<T>(T uiID, string name) where T : System.IConvertible
        {
            Add(new PanelData(uiID.ToInt32(null), name));
        }


        private static void Add(UIData data)
        {
            if (data == null) return;

            if (m_UIDataMap.ContainsKey(data.uiID))
            {
                Log.w("#Already Add UIID:" + data.uiID);
                return;
            }

            m_UIDataMap.Add(data.uiID, data);
        }
    }

}