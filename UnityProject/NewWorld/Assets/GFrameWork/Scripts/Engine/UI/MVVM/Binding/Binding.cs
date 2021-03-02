/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Binding.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 5:47:02 PM
	Tip:3/2/2021 5:47:02 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Binding
{
    public class Binding : AbstractBinding
    {
        private BindingDescription bindingDescription;

        public Binding(IBindingContext bindingContext, object dataContext, object target, BindingDescription bindingDescription) : base(bindingContext, dataContext, target)
        {
            this.bindingDescription = bindingDescription;
            this.UpdateDataOnBind();
        }

        protected override void OnDataContextChanged()
        {
            this.UpdateDataOnBind();
        }

        protected void UpdateDataOnBind()
        {
            Debug.LogError("UpdateDataOnBind");
        }
    }

}