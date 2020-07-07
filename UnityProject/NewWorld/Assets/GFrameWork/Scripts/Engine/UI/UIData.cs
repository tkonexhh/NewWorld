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
        protected string m_Name;
        protected int m_UIID;
        //protected Type m_PanelClassType;

        public string name
        {
            get { return m_Name; }
        }

        public int uiID
        {
            get { return m_UIID; }
        }


        public UIData(int uiID, string name)
        {
            m_UIID = uiID;
            //m_PanelClassType = type;
            m_Name = name;
        }
    }

    public class PanelData : UIData
    {
        public PanelData(int uiID, string name) : base(uiID, name)
        {

        }
    }

}