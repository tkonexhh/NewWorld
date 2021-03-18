/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Binding.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 5:47:02 PM
	Tip:3/2/2021 5:47:02 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Binding
{
    public class Binding : AbstractBinding
    {
        private object _lock = new object();

        private readonly ISourceProxyFactory sourceProxyFactory;
        private readonly ITargetProxyFactory targetProxyFactory;

        private ISourceProxy sourceProxy;
        private ITargetProxy targetProxy;

        private EventHandler sourceValueChangedHandler;
        private EventHandler targetValueChangedHandler;

        private BindingDescription bindingDescription;

        public Binding(IBindingContext bindingContext, object dataContext, object target, BindingDescription bindingDescription, ISourceProxyFactory sourceProxyFactory, ITargetProxyFactory targetProxyFactory)
            : base(bindingContext, dataContext, target)
        {
            this.bindingDescription = bindingDescription;
            this.sourceProxyFactory = sourceProxyFactory;
            this.targetProxyFactory = targetProxyFactory;

            this.CreateTargetProxy(target, this.bindingDescription);
            this.CreateSourceProxy(this.DataContext, this.bindingDescription.Source);
            this.UpdateDataOnBind();
        }

        protected override void OnDataContextChanged()
        {
            Debug.LogError("OnDataContextChanged");
            this.UpdateDataOnBind();
        }

        protected void UpdateDataOnBind()
        {
            Debug.LogError("UpdateDataOnBind");
        }
        protected void CreateTargetProxy(object target, BindingDescription bindingDescription)
        {
            this.targetProxy = this.targetProxyFactory.CreateProxy(target, bindingDescription);
        }

        protected void CreateSourceProxy(object source, SourceDescription description)
        {
            Debug.LogError("CreateSourceProxy");
            this.sourceProxy = this.sourceProxyFactory.CreateProxy(source, description);
            if (this.sourceProxy is INotifiable)
            {
                this.sourceValueChangedHandler = (sender, args) => this.UpdateTargetFromSource();
                (this.sourceProxy as INotifiable).ValueChanged += this.sourceValueChangedHandler;
            }
        }

        protected void UpdateTargetFromSource()
        {
            lock (_lock)
            {
                Debug.LogError(11111111);
            }
        }
    }

}