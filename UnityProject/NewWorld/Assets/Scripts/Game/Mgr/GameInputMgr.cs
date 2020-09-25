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
    public class GameInputMgr : TSingleton<GameInputMgr>
    {
        private GameInput m_Input;

        public GameInput.MainActions mainAction => m_Input.Main;
        public GameInput.UIActions uiAction => m_Input.UI;
        public GameInput.ShortcutActions shortcutActions => m_Input.Shortcut;

        public override void OnSingletonInit()
        {
            m_Input = new GameInput();
            EnableInput();
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


    }

}