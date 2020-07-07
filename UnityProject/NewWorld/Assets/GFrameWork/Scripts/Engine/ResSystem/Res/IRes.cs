/************************
	FileName:/GFrameWork/Scripts/Engine/ResSystem/IRes.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 5:37:36 PM
	Tip:7/7/2020 5:37:36 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IRes
    {
        UnityEngine.Object asset
        {
            get;
            set;
        }

        bool Load();
    }

}