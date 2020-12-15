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

namespace Game.Logic
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
            AddComponent(new UIDataModule());
            AddComponent(new SceneDataModule());
            AddComponent(new DataBaseModule());

            //TODO
            // GamePlayMgr.S.Init();
        }

        protected override void OnModuleAwake()
        {
            //ShowLogoPanel();
            AddComponent(new StartProcessModule());
        }

        protected override void OnModuleStart()
        {
            // EnterMainMenuScene();
            // EnterCreateRole();
            EnterGameScene();
        }

        private void EnterMainMenuScene()
        {
            SceneMgr.S.OpenScene(SceneID.MainMenuScene);
        }

        #region Test
        private void EnterCreateRole()
        {
            SceneMgr.S.OpenScene(SceneID.CreateRoleScene);
        }

        private void EnterGameScene()
        {
            SceneMgr.S.OpenScene(SceneID.GameScene);
        }
        #endregion
    }



}