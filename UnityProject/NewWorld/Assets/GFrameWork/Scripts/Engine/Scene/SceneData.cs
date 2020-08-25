/************************
	FileName:/GFrameWork/Scripts/Engine/Scene/SceneData.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:51:39 PM
	Tip:8/25/2020 5:51:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class SceneData
    {
        public static string SCENE_PATH = "";


        protected string m_ResPath;
        protected int m_SceneID;
        protected LoadStrategy m_LoadStrategy = LoadStrategy.Resource;

        public string path => m_ResPath;
        public int sceneID => m_SceneID;


        public SceneData(int sceneID, string path, LoadStrategy loadMode)
        {
            m_SceneID = sceneID;
            //m_PanelClassType = type;
            m_ResPath = path;
            m_LoadStrategy = loadMode;
        }
    }

}