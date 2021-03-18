/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/IBinding.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 5:04:17 PM
	Tip:3/1/2021 5:04:17 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IBinding : IDisposable
    {
        IBindingContext BindingContext { get; set; }
        object Target { get; }
        object DataContext { get; set; }
    }

}