/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Relax.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 5:15:24 PM
	Tip:9/25/2020 5:15:24 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class RoleFSMState_Relax : FSMState<Role>
    {
        private Role_Player player;
        private Vector2 m_InputMove = Vector2.zero;
        private Vector2 m_VecMove = Vector2.zero;
        private float m_VecSpeed = 3.0f;

        public override void Enter(Role entity, params object[] args)
        {
            player = entity as Role_Player;
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled += OnMoveCancled;
        }

        public override void Execute(Role role, float dt)
        {
            if (role.animComponent == null)
                return;
            m_VecMove = Vector2.Lerp(m_VecMove, m_InputMove, dt * m_VecSpeed);
            role.animComponent.SetVelocity(m_VecMove);

            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Battle);
            }
        }

        public override void Exit(Role entity)
        {
            GameInputMgr.S.mainAction.Move.performed -= OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled -= OnMoveCancled;
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            m_InputMove = callback.ReadValue<Vector2>();
            player.controlComponent.Moving = true;
        }

        private void OnMoveCancled(InputAction.CallbackContext callback)
        {
            m_InputMove = Vector2.zero;
            player.controlComponent.Moving = false;
        }
    }

}