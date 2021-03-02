/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/BindingFactory.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 5:44:30 PM
	Tip:3/2/2021 5:44:30 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame.Binding;

namespace GFrame
{
    public class BindingFactory : IBindingFactory
    {
        public IBinding Create(IBindingContext bindingContext, object source, object target, BindingDescription bindingDescription)
        {
            return new Binding.Binding(bindingContext, source, target, bindingDescription);
        }
    }

}