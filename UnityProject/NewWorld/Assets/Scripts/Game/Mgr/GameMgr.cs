/************************
	FileName:/GFrameWork/Scripts/Engine/App/GameMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 2:18:30 PM
	Tip:7/7/2020 2:18:30 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    [TMonoSingletonAttribute("[GFrame]/[Game]/[GameMgr]")]
    public class GameMgr : AbstractModule, ISingleton
    {
        private static GameMgr s_Instance;
        public static GameMgr S
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = MonoSingleton.CreateMonoSingleton<GameMgr>();
                }
                return s_Instance;
            }
        }
        public void OnSingletonInit()
        {

        }


        public void Init()
        {
            Log.i("#Init[GameMgr]");
        }

        protected override void OnModuleAwake()
        {
            Debug.LogError("OnModuleAwake");
            //ShowLogoPanel();
        }

        protected override void OnModuleStart()
        {
            Debug.LogError("OnModuleStart");
            //AddComponent(new StartProcessModule());
        }
    }



}