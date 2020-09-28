/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleInputComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/17/2020 8:12:17 PM
	Tip:9/17/2020 8:12:17 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.Logic
{
    //响应Input
    public class RoleInputComponent : RoleBaseComponent
    {
        private CharacterController m_Controller;
        private Vector2 m_InputMove = Vector2.zero;
        private Vector2 m_VecMove = Vector2.zero;
        private float m_VecSpeed = 3.0f;

        private Role_Player player;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = role as Role_Player;
            m_Controller = role.gameObject.GetComponentInChildren<CharacterController>();
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled += OnMoveCancled;
        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            m_InputMove = callback.ReadValue<Vector2>();
            Debug.LogError(m_InputMove);
            player.controlComponent.Moving = true;
        }

        private void OnMoveCancled(InputAction.CallbackContext callback)
        {
            m_InputMove = Vector2.zero;
            player.controlComponent.Moving = false;
        }

        public override void Update(float dt)
        {
            if (role.animComponent == null)
                return;
            m_VecMove = Vector2.Lerp(m_VecMove, m_InputMove, dt * m_VecSpeed);
            role.animComponent.SetVelocity(m_VecMove);

            if (Input.GetKeyDown(KeyCode.T))
            {
                player.controlComponent.IsInjured = !player.controlComponent.IsInjured;
            }
        }

    }

}