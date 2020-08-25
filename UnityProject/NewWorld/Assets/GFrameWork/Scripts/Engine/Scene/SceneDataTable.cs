/************************
	FileName:/GFrameWork/Scripts/Engine/Scene/SceneDataTable.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:51:56 PM
	Tip:8/25/2020 5:51:56 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class SceneDataTable
    {
        private static Dictionary<int, SceneData> s_SceneDataMap = new Dictionary<int, SceneData>();
        private static LoadStrategy m_LoadStrategy = LoadStrategy.Resource;

        public static void SetLoadMode(LoadStrategy loadMode)
        {
            m_LoadStrategy = loadMode;
        }

        public static void AddSceneData<T>(T sceneID, string path) where T : System.IConvertible
        {
            Add(new SceneData(sceneID.ToInt32(null), path, m_LoadStrategy));
        }

        private static void Add(SceneData data)
        {
            if (data == null) return;

            if (s_SceneDataMap.ContainsKey(data.sceneID))
            {
                Log.w("#Already Add UIID:" + data.sceneID);
                return;
            }

            s_SceneDataMap.Add(data.sceneID, data);
        }

        public static SceneData Get<T>(T uiID) where T : System.IConvertible
        {
            SceneData result = null;

            if (s_SceneDataMap.TryGetValue(uiID.ToInt32(null), out result))
            {
                return result;
            }
            Log.e("#InValid UIID:" + uiID.ToInt32(null));
            return null;
        }
    }

}