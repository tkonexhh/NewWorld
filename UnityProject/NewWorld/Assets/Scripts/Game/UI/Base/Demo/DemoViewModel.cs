/************************
	FileName:/Scripts/Game/UI/Base/Demo/DemoViewModel.cs
	CreateAuthor:neo.xu
	CreateTime:8/14/2020 10:04:37 AM
	Tip:8/14/2020 10:04:37 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class DemoViewModel : ViewModel
    {
        // private int m_ID;

        // public int id
        // {
        //     get => m_ID;
        //     set
        //     {
        //         this.Set<int>(ref m_ID, value);
        //     }
        // }
        public BindableProperty<int> ID = new BindableProperty<int>();


    }

}