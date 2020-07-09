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
            AddComponent(new UIDataModule());
        }

        protected override void OnModuleAwake()
        {
            //ShowLogoPanel();
            AddComponent(new StartProcessModule());
        }

        protected override void OnModuleStart()
        {
            EnterMainMenu();
            //EnterCreateRole();
        }

        private void EnterMainMenu()
        {
            UIMgr.S.OpenPanel(UIID.MainMenuPanel);
        }

        #region Test
        private void EnterCreateRole()
        {
            AddressableResMgr.S.LoadSceneAsync("CreateCharacterScene");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        #endregion
    }



}