/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/AbstractBinding.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 5:05:56 PM
	Tip:3/1/2021 5:05:56 PM
************************/

using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public abstract class AbstractBinding : IBinding
    {
        private IBindingContext bindingContext;
        private object dataContext;
        private WeakReference target;

        public AbstractBinding(IBindingContext bindingContext, object dataContext, object target)
        {
            this.bindingContext = bindingContext;
            this.dataContext = dataContext;
            this.target = new WeakReference(target, false);
        }

        public virtual IBindingContext BindingContext
        {
            get { return this.bindingContext; }
            set { this.bindingContext = value; }
        }

        public virtual object Target
        {
            get
            {
                var target = this.target != null ? this.target.Target : null;
                return target;
            }
        }

        public virtual object DataContext
        {
            get { return this.dataContext; }
            set
            {
                if (this.dataContext == value)
                    return;

                this.dataContext = value;
                this.OnDataContextChanged();
            }
        }

        protected abstract void OnDataContextChanged();

        #region IDisposable Support     

        protected virtual void Dispose(bool disposing)
        {
            this.bindingContext = null;
            this.dataContext = null;
            this.target = null;
        }

        ~AbstractBinding()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}