/************************
	FileName:/GFrameWork/Scripts/Engine/Scene/SceneInfo.cs
	CreateAuthor:neo.xu
	CreateTime:8/26/2020 12:39:27 PM
	Tip:8/26/2020 12:39:27 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GFrame
{
    public class SceneInfo : IPoolAble
    {
        private enum eSceneState : byte
        {
            UnInit,
            Loading,
            Ready,
        }

        //private AbstractScene m_Scene;
        private eSceneState m_SceneState;
        private Action m_OpenCallback;
        private int m_SceneID;

        #region gette settter
        public int sceneID => m_SceneID;
        //public bool isReady => m_Scene != null;
        #endregion

        #region cache
        public bool cacheFlag
        {
            get;
            set;
        }

        public void OnCacheReset()
        {
            //m_Scene = null;
            m_SceneState = eSceneState.UnInit;

            m_OpenCallback = null;
        }
        #endregion

        public void Init(int sceneID)
        {
            m_SceneID = sceneID;
        }

        public void AddOpenCallback(Action callback)
        {
            if (callback == null) return;

            m_OpenCallback += callback;
        }

        public void LoadSceneRes()
        {
            if (m_SceneState != eSceneState.UnInit) return;


            m_SceneState = eSceneState.Loading;
            SceneData data = SceneDataTable.Get(m_SceneID);

            if (data == null)
            {
                return;
            }
            if (data.loadStrategy == SceneLoadStatgy.Addressable)
            {
                AddressableResMgr.S.LoadSceneAsync(data.fullPath, (sceneInstance) =>
                {

                    if (m_OpenCallback != null)
                    {
                        m_OpenCallback.Invoke();
                    }
                }, data.loadSceneMode);
            }
            else
            {
                SceneManager.LoadSceneAsync(data.fullPath, data.loadSceneMode).completed += (handle) =>
                {
                    if (m_OpenCallback != null)
                    {
                        m_OpenCallback.Invoke();
                    }
                };
            }
        }

    }

}