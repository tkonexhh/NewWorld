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
        private ISourceProxyFactory sourceProxyFactory;
        private ITargetProxyFactory targetProxyFactory;

        public BindingFactory(ISourceProxyFactory sourceProxyFactory, ITargetProxyFactory targetProxyFactory)
        {
            this.sourceProxyFactory = sourceProxyFactory;
            this.targetProxyFactory = targetProxyFactory;
        }

        public IBinding Create(IBindingContext bindingContext, object source, object target, BindingDescription bindingDescription)
        {
            return new Binding.Binding(bindingContext, source, target, bindingDescription, this.sourceProxyFactory, this.targetProxyFactory);
        }
    }

}