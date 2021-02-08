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
using UnityEngine.Events;
using GFrame;


namespace Game.Logic
{
    [TMonoSingletonAttribute("[Game]/[Tools]/[GameInputMgr]")]
    public class GameInputMgr : TMonoSingleton<GameInputMgr>, GameInput.IMainActions
    {
        private GameInput m_Input;

        public event UnityAction<Vector2> cameraMoveEvent = delegate { };
        public event UnityAction enableMouseControlCameraEvent = delegate { };
        public event UnityAction disableMouseControlCameraEvent = delegate { };
        public event UnityAction<Vector2> moveEvent = delegate { };
        public event UnityAction enableRunEvent = delegate { };
        public event UnityAction disableRunEvent = delegate { };
        public event UnityAction jumpEvent = delegate { };
        public event UnityAction jumpCanceledEvent = delegate { };
        public event UnityAction rollEvent = delegate { };
        public event UnityAction enableCrouchEvent = delegate { };
        public event UnityAction disableCrouchEvent = delegate { };

        public GameInput.MainActions mainAction => m_Input.Main;
        public GameInput.UIActions uiAction => m_Input.UI;
        public GameInput.ShortcutActions shortcutActions => m_Input.Shortcut;




        public override void OnSingletonInit()
        {
            m_Input = new GameInput();
            m_Input.Main.SetCallbacks(this);
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


        public void ClearMove()
        {

            //moveInput = Vector2.zero;
        }

        ////////////
        public void OnRotateCamera(InputAction.CallbackContext context)
        {
            cameraMoveEvent.Invoke(context.ReadValue<Vector2>());
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            moveEvent.Invoke(context.ReadValue<Vector2>());
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            jumpEvent.Invoke();
        }
        public void OnRoll(InputAction.CallbackContext context)
        {
            rollEvent.Invoke();
        }
        public void OnAny(InputAction.CallbackContext context) { }
        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                enableRunEvent.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                disableRunEvent.Invoke();
            }
        }
        public void OnAttackL(InputAction.CallbackContext context) { }
        public void OnAttackR(InputAction.CallbackContext context) { }
        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                enableCrouchEvent.Invoke();

            if (context.phase == InputActionPhase.Canceled)
                disableCrouchEvent.Invoke();
        }

        public void OnMouseControlCamera(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                enableMouseControlCameraEvent.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                disableMouseControlCameraEvent.Invoke();
            }
        }
    }

}