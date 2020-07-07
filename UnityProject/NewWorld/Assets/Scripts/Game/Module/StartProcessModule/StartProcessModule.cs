/************************
	FileName:/Scripts/Game/Module/StartProcessModule/StartProcessModule.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 2:35:38 PM
	Tip:7/7/2020 2:35:38 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class StartProcessModule : AbstractStartProcess
    {
        protected override void InitProcess()
        {
            AddComponent(new UIDataModule());
        }
    }

}