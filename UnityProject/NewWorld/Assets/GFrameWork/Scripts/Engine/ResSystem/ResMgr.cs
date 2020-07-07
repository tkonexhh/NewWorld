/************************
	FileName:/GFrameWork/Scripts/Engine/ResSystem/ResMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 5:35:29 PM
	Tip:7/7/2020 5:35:29 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[ResMgr]")]
    public class ResMgr : TMonoSingleton<ResMgr>
    {
        public IRes GetRes(string name)
        {
            IRes res = null;
            res = ResFactory.Create(name);
            return res;
        }
    }

}