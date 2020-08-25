/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UIData.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 1:43:34 PM
	Tip:7/7/2020 1:43:34 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace GFrame
{
    public class UIData
    {
        protected string m_ResPath;
        protected int m_UIID;
        protected int m_CacheCount = 0;
        protected bool m_IsSingleton = true;
        protected LoadStrategy m_LoadStrategy = LoadStrategy.Resource;

        public string path => m_ResPath;
        public int uiID => m_UIID;
        public int cacheCount => m_CacheCount;
        public bool isSingleton => m_IsSingleton;


        public UIData(int uiID, string path, LoadStrategy loadMode)
        {
            m_UIID = uiID;
            //m_PanelClassType = type;
            m_ResPath = path;
            m_LoadStrategy = loadMode;
        }

        public UIData(int uiID, string path, bool singleton, int cacheCount, LoadStrategy loadMode)
        {
            m_UIID = uiID;
            //m_PanelClassType = type;
            m_ResPath = path;
            m_IsSingleton = singleton;
            m_CacheCount = cacheCount;
            m_LoadStrategy = loadMode;
        }

        public virtual string fullPath
        {
            get
            {
                if (m_LoadStrategy == LoadStrategy.Addressable)
                {
                    return m_ResPath;
                }

                return string.Format(prefixPath, m_ResPath);
            }
        }

        protected virtual string prefixPath
        {
            get { return "{0}"; }
        }

        private string FileName(string name)
        {
            int folderIndex = name.LastIndexOf('/');
            if (folderIndex >= 0)
            {
                return name.Substring(folderIndex + 1);
            }

            return name;
        }
    }

    public class PanelData : UIData
    {
        public static string PANEL_PATH = "";

        public PanelData(int uiID, string path, LoadStrategy loadMode) : base(uiID, path, loadMode)
        {
        }

        public PanelData(int uiID, string path, bool singleton, int cacheCount, LoadStrategy loadMode) : base(uiID, path, singleton, cacheCount, loadMode)
        {
        }

        protected override string prefixPath
        {
            get { return PANEL_PATH; }
        }
    }

}