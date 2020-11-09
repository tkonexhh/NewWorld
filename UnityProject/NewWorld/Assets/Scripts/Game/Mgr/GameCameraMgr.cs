/************************
	FileName:/Scripts/Game/Mgr/GameCameraMgr.cs
	CreateAuthor:neo.xu
	CreateTime:11/9/2020 5:18:42 PM
	Tip:11/9/2020 5:18:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[GameCameraMgr]")]

    public class GameCameraMgr : TMonoSingleton<GameCameraMgr>
    {
        public Camera uiCamera => UIMgr.S.uiRoot.uiCamera;
        public Camera mainCamera
        {
            get => Camera.main;
            // set;
        }



    }

}