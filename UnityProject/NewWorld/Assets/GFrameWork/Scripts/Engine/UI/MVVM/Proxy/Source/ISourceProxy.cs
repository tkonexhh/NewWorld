/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Source/ISourceProxy.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 2:26:39 PM
	Tip:3/3/2021 2:26:39 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface ISourceProxy : IBindingProxy
    {
        Type Type { get; }
        TypeCode TypeCode { get; }
        object Source { get; }
    }

}