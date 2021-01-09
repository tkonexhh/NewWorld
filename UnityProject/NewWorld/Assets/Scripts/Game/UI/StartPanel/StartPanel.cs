using System;
/************************
	FileName:/Scripts/Game/UI/StartPanel/StartPanel.cs
	CreateAuthor:neo.xu
	CreateTime:10/29/2020 7:41:27 PM
	Tip:10/29/2020 7:41:27 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;


namespace Game.Logic
{
    public class StartPanel : AbstractPanel
    {
        [SerializeField] private Button m_BtnEnterGame;
        [SerializeField] private Button m_BtnNewRole;

        private MainMenuScene m_Scene;

        protected override void OnUIInit()
        {
            m_BtnEnterGame.onClick.AddListener(OnClickEnterGame);
            m_BtnNewRole.onClick.AddListener(OnClickNewRole);
        }

        protected override void OnOpen()
        {

        }

        public void InitMainScene(MainMenuScene scene)
        {
            m_Scene = scene;
        }

        private void OnClickEnterGame()
        {
            UIMgr.S.OpenTopPanel(UIID.LoadingPanel, (panel) =>
            {
                ((LoadingPanel)panel).RegisterShowOverListener(() =>
                {
                    CloseSelfPanel();
                    SceneMgr.S.OpenScene(SceneID.GameScene);
                });
            });
        }

        private void OnClickNewRole()
        {
            CloseSelfPanel();
            UIMgr.S.OpenPanel(UIID.CreateCharacterPanel, (panel) =>
            {
                ((CreateCharacterPanel)panel).InitMainScene(m_Scene);
            });

            if (m_Scene != null)
            {
                m_Scene.cameraControl.LookCreate();
                m_Scene.ControlRotate();
            }

        }
    }

}