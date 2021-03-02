/************************
	FileName:/0TempRes/DemoPanel.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 10:48:50 AM
	Tip:3/2/2021 10:48:50 AM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Game.Logic
{
    public class DemoPanel : View
    {
        public InputField input_Username;
        public Button confirmButton;
        private DemoViewModel viewModel;

        protected override void OnUIInit()
        {
            viewModel = new DemoViewModel();
            BindingSet<DemoPanel, DemoViewModel> bindingSet = this.CreateBindingSet<DemoPanel, DemoViewModel>(viewModel);
            bindingSet.Bind(this.input_Username).For(v => v.text, v => v.onEndEdit).To(vm => vm.Username);
            bindingSet.Bind(this.confirmButton).For(v => v.onClick).To(vm => vm.LoginCallback);
            bindingSet.Build();
        }
    }

    public class DemoViewModel : ViewModelBase
    {
        private string username;
        public string Username
        {
            get { return this.username; }
            set
            {
                Debug.LogError("Username");
                if (this.Set<string>(ref this.username, value, "Username"))
                {
                    this.ValidateUsername();
                }
            }
        }

        private Action loginCallback;
        public Action LoginCallback => loginCallback;

        public DemoViewModel()
        {
            loginCallback = new Action(() => { Debug.LogError("Login"); });
        }


        private void ValidateUsername()
        {
            Debug.LogError("ValidateUsername");
        }
    }

}