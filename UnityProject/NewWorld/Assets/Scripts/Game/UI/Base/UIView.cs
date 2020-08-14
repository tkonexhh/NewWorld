/************************
	FileName:/Scripts/Game/UI/Base/UIView.cs
	CreateAuthor:neo.xu
	CreateTime:8/14/2020 10:04:10 AM
	Tip:8/14/2020 10:04:10 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class UIView : MonoBehaviour
    {
        public ViewModel viewModel
        {
            get;
            set;
        }

        // public readonly BindableProperty<ViewModel> ViewModelProperty = new BindableProperty<ViewModel>();
        // public ViewModel BindingContext
        // {
        //     get { return ViewModelProperty.Value; }
        //     set { ViewModelProperty.Value = value; }
        // }

        // protected virtual void OnBindingContextChanged(ViewModel oldViewModel, ViewModel newViewModel)
        // {
        // }

        // private void Awake()
        // {
        //     this.ViewModelProperty.OnValueChanged += OnBindingContextChanged;
        // }
    }




}