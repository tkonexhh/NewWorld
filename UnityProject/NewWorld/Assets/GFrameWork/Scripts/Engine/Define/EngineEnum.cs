/************************
	FileName:/GFrameWork/Scripts/Engine/Define/EngineEnum.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 6:02:00 PM
	Tip:8/25/2020 6:02:00 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public enum LoadStrategy
    {
        Resource,
        Addressable,
    }

    public enum SceneLoadStatgy
    {
        BuildIn,
        Addressable,
    }
}