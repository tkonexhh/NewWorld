/************************
	FileName:/Scripts/Game/UI/MainMenuPanel/MainMenuPanel.cs
	CreateAuthor:neo.xu
	CreateTime:7/8/2020 9:44:36 AM
	Tip:7/8/2020 9:44:36 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;


namespace Game.Logic
{
    public class MainMenuPanel : AbstractPanel
    {
        [SerializeField] private Animator m_AnimFirstInput;
        [SerializeField] private Transform m_TrsMenu;

        [SerializeField] private MainMentBtn m_BtnNewGame;
        [SerializeField] private MainMentBtn m_BtnLoadGame;
        [SerializeField] private MainMentBtn m_BtnExit;

        private GameInput m_Input;
        private bool m_HasInput = false;
        private bool m_HasShowMenu = false;

        protected override void OnUIInit()
        {
            m_AnimFirstInput.gameObject.SetActive(true);
            m_TrsMenu.gameObject.SetActive(false);

            m_BtnNewGame.SetClickListerner(OnClickNewGame);
            m_BtnLoadGame.SetClickListerner(OnClickLoadGame);
            m_BtnExit.SetClickListerner(OnClickExit);

            UIMgr.S.uiRoot.eventSystem.SetSelectedGameObject(null);
            UIMgr.S.uiRoot.eventSystem.firstSelectedGameObject = m_BtnNewGame.gameObject;


            GameInputMgr.S.uiAction.Any.started += PressAny;
        }

        private void PressAny(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            if (!m_HasInput)
            {
                m_HasInput = true;
                m_AnimFirstInput.Play("Hide");
            }
        }

        private void Update()
        {
            if (!m_HasShowMenu)
            {
                AnimatorStateInfo animatorStateInfo = m_AnimFirstInput.GetCurrentAnimatorStateInfo(0);
                if (animatorStateInfo.IsName("Hide") && animatorStateInfo.normalizedTime > 1.0f)
                {
                    m_HasShowMenu = true;
                    m_TrsMenu.gameObject.SetActive(true);//.Play("Show");
                }
            }

        }

        private void OnClickNewGame()
        {
            UIMgr.S.OpenPanel(UIID.LoadingPanel, (panel) =>
            {
                ((LoadingPanel)panel).RegisterShowOverListener(() =>
                {
                    CloseSelfPanel();
                    AddressableResMgr.S.LoadSceneAsync("CreateCharacterScene");
                });
            });

        }

        private void OnClickLoadGame()
        {

        }

        private void OnClickExit()
        {
            Application.Quit();
        }

    }

}