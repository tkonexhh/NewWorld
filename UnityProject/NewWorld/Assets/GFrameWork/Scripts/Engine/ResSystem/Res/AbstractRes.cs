/************************
	FileName:/GFrameWork/Scripts/Engine/ResSystem/Res/AbstractRes.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 5:39:28 PM
	Tip:7/7/2020 5:39:28 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AbstractRes : IRes
    {
        protected string m_Name;
        protected UnityEngine.Object m_Asset;


        public string name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public UnityEngine.Object asset
        {
            get { return m_Asset; }
            set { m_Asset = value; }
        }

        public virtual bool Load()
        {
            return false;
        }


    }

}