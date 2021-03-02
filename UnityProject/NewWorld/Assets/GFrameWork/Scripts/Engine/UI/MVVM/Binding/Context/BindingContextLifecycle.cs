/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Context/BindingContextLifecycle.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 11:01:16 AM
	Tip:3/2/2021 11:01:16 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class BindingContextLifecycle : MonoBehaviour
    {
        private IBindingContext bindingContext;
        public IBindingContext BindingContext
        {
            get { return this.bindingContext; }
            set
            {
                if (this.bindingContext == value)
                    return;

                if (this.bindingContext != null)
                    this.bindingContext.Dispose();

                this.bindingContext = value;
            }
        }

        protected virtual void OnDestroy()
        {
            if (this.bindingContext != null)
            {
                this.bindingContext.Dispose();
                this.bindingContext = null;
            }
        }
    }

}