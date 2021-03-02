/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Context/IBindingContext.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 10:24:27 AM
	Tip:3/2/2021 10:24:27 AM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IBindingContext : IDisposable
    {
        object Owner { get; }
        object DataContext { get; set; }
        void Add(IBinding binding, object key = null);
        void Add(IEnumerable<IBinding> bindings, object key = null);
        void Add(object target, BindingDescription description, object key = null);
        void Add(object target, IEnumerable<BindingDescription> descriptions, object key = null);
        void Clear(object key);
        void Clear();
    }

}