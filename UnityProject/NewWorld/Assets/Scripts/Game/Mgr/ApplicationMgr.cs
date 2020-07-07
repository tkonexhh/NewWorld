/************************
	FileName:/Scripts/Game/Mgr/ApplicationMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 11:34:33 AM
	Tip:7/7/2020 11:34:33 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class ApplicationMgr : GFrame.ApplicationMgr
    {
        protected override void StartGame()
        {
            Debug.LogError("StartGame");
            GameMgr.S.Init();
            GameDataMgr.S.Init();
        }
    }

}