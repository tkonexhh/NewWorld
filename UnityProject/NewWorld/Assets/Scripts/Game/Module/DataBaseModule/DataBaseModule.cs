/************************
	FileName:/Scripts/Game/Module/DataBaseModule/DataBaseModule.cs
	CreateAuthor:neo.xu
	CreateTime:7/16/2020 3:02:59 PM
	Tip:7/16/2020 3:02:59 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class DataBaseModule : AbstractComponent
    {
        protected override void OnAwake()
        {
            InitPreLoadDataBase();
            InitDelayLoadDataBase();
        }

        private void InitPreLoadDataBase()
        {

        }

        private void InitDelayLoadDataBase()
        {

        }
    }

}