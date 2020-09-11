/************************
	FileName:/Scripts/Game/Mgr/GameResMgr.cs
	CreateAuthor:neo.xu
	CreateTime:9/7/2020 12:31:36 PM
	Tip:9/7/2020 12:31:36 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    [TMonoSingletonAttribute("[Game]/[Tools]/[GameResMgr]")]
    public class GameResMgr : TMonoSingleton<GameResMgr>
    {
        private GameGlobalRes m_GlobalRes;

        public GameGlobalRes globalRes => m_GlobalRes;
        public override void OnSingletonInit()
        {
            //加载必要的游戏资源
            GameObject global = new GameObject();
            global.name = "GlobalRes";
            global.transform.SetParent(transform);
            m_GlobalRes = global.AddComponent<GameGlobalRes>();
        }

        public void Init()
        {
            m_GlobalRes.Reload();

        }
    }

}