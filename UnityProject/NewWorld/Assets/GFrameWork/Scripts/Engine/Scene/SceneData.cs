/************************
	FileName:/GFrameWork/Scripts/Engine/Scene/SceneData.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:51:39 PM
	Tip:8/25/2020 5:51:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GFrame
{
    public class SceneData
    {
        public static string SCENE_PATH = "";


        protected string m_ResPath;
        protected int m_SceneID;
        protected SceneLoadStatgy m_LoadStrategy = SceneLoadStatgy.Addressable;
        protected LoadSceneMode m_LoadMode = LoadSceneMode.Single;

        public string path => m_ResPath;
        public int sceneID => m_SceneID;
        public SceneLoadStatgy loadStrategy => m_LoadStrategy;
        public LoadSceneMode loadSceneMode => m_LoadMode;


        public SceneData(int sceneID, string path, SceneLoadStatgy loadMode, LoadSceneMode mode)
        {
            m_SceneID = sceneID;
            m_ResPath = path;
            m_LoadStrategy = loadMode;
            m_LoadMode = mode;
        }

        public virtual string fullPath
        {
            get
            {
                if (m_LoadStrategy == SceneLoadStatgy.Addressable)
                {
                    return m_ResPath;
                }

                return string.Format(SCENE_PATH, m_ResPath);
            }
        }
    }

}