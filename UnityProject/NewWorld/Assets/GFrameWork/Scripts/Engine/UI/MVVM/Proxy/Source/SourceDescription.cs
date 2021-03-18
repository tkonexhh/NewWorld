/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Source/SourceDescription.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 2:33:14 PM
	Tip:3/3/2021 2:33:14 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class SourceDescription
    {
        private bool isStatic = false;
        public virtual bool IsStatic
        {
            get { return this.isStatic; }
            set { this.isStatic = value; }
        }
    }

}