/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Binders/IBinder.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 11:06:35 AM
	Tip:3/2/2021 11:06:35 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IBinder
    {
        IBinding Bind(IBindingContext bindingContext, object source, object target, BindingDescription bindingDescription);
        IEnumerable<IBinding> Bind(IBindingContext bindingContext, object source, object target, IEnumerable<BindingDescription> bindingDescriptions);
    }

}