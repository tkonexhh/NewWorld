/************************
	FileName:/Scripts/Game/UI/Base/Demo/DemoView.cs
	CreateAuthor:neo.xu
	CreateTime:8/14/2020 10:04:26 AM
	Tip:8/14/2020 10:04:26 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Logic
{
    public class DemoView : UIView
    {
        [SerializeField] private Text m_TextID;

        private DemoViewModel demoViewModel
        {
            get { return viewModel as DemoViewModel; }
        }

        private void Awake()
        {
            viewModel = new DemoViewModel();
            demoViewModel.ID.OnValueChanged += IDValueChanged;
        }

        private void IDValueChanged(int oldValue, int newValue)
        {
            m_TextID.text = newValue.ToString();
        }


        private void Update()
        {
            demoViewModel.ID.Value += 1;
            Debug.LogError(demoViewModel.ID.Value);
        }
    }

}