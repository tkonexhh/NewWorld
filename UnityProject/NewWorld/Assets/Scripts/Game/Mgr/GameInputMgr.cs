/************************
	FileName:/Scripts/Game/Mgr/GameInputMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/8/2020 5:32:43 PM
	Tip:7/8/2020 5:32:43 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GFrame;


namespace Game.Logic
{
    [TMonoSingletonAttribute("[Game]/[Tools]/[GameInputMgr]")]
    public class GameInputMgr : TMonoSingleton<GameInputMgr>
    {
        private GameInput m_Input;

        public GameInput.MainActions mainAction => m_Input.Main;
        public GameInput.UIActions uiAction => m_Input.UI;
        public GameInput.ShortcutActions shortcutActions => m_Input.Shortcut;

        private Vector2 m_VelMoveInput;
        private readonly float moveSensitivity = 2.0f;//移动轴的灵敏度

        public Vector2 moveVec
        {
            get;
            private set;
        }

        public Vector2 moveInput
        {
            get;
            private set;
        }



        public override void OnSingletonInit()
        {
            m_Input = new GameInput();
            EnableInput();
        }


        private void OnDestroy()
        {
        }

        public void EnableInput()
        {
            m_Input.UI.Enable();
            m_Input.Main.Enable();
            m_Input.Shortcut.Enable();
        }

        public void DisableInput()
        {
            m_Input.UI.Disable();
            m_Input.Main.Disable();
            m_Input.Shortcut.Disable();
        }

        private void Update()
        {
            moveInput = mainAction.Move.ReadValue<Vector2>();
            moveVec = Vector2.SmoothDamp(moveVec, moveInput, ref m_VelMoveInput, moveSensitivity * Time.deltaTime);
        }

        public void ClearMove()
        {

        }
    }

}