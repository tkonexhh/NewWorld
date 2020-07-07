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
        protected bool m_IsAddressMode = false;

        public string path
        {
            get { return m_ResPath; }
        }

        public int uiID
        {
            get { return m_UIID; }
        }


        public UIData(int uiID, string path, bool addressMode)
        {
            m_UIID = uiID;
            //m_PanelClassType = type;
            m_ResPath = path;
            m_IsAddressMode = addressMode;
        }

        public virtual string fullPath
        {
            get
            {
                if (m_IsAddressMode)
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
        public PanelData(int uiID, string path, bool addressMode) : base(uiID, path, addressMode)
        {

        }

        protected override string prefixPath
        {
            get { return PANEL_PATH; }
        }
    }

}