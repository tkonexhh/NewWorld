/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Binders/BinderBase.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 11:14:59 AM
	Tip:3/2/2021 11:14:59 AM
************************/

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class BinderBase : IBinder
    {
        protected IBindingFactory factory;

        public BinderBase(IBindingFactory factory)
        {
            this.factory = factory;
        }

        public IBinding Bind(IBindingContext bindingContext, object source, object target, BindingDescription bindingDescription)
        {
            return factory.Create(bindingContext, source, target, bindingDescription);
        }

        public IEnumerable<IBinding> Bind(IBindingContext bindingContext, object source, object target, IEnumerable<BindingDescription> bindingDescriptions)
        {
            if (bindingDescriptions == null)
                return new IBinding[0];

            return bindingDescriptions.Select(description => this.Bind(bindingContext, source, target, description));
        }
    }

}