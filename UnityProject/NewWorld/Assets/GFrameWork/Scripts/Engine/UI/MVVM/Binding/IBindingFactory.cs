/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/IBindingFactory.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 5:38:12 PM
	Tip:3/2/2021 5:38:12 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IBindingFactory
    {
        IBinding Create(IBindingContext bindingContext, object source, object target, BindingDescription bindingDescription);
    }

}