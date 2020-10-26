/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RelaxFSM/RoleRelaxFSMState_Talking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 1:43:03 PM
	Tip:9/30/2020 1:43:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class RoleRelaxFSMState_Move : FSMState<Role>
    {
        private Role_Player player;
        private Vector2 m_InputMove = Vector2.zero;
        private Vector2 m_VecMove = Vector2.zero;
        private bool m_Runing = false;

        private Vector2 m_VelMoveVelocity;
        public override void Enter(Role role, params object[] args)
        {
            player = role as Role_Player;
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled += OnMoveCancled;
            GameInputMgr.S.mainAction.Run.performed += OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled += OnRunCancled;
        }

        public override void Update(Role role, float dt)
        {
            if (role.animComponent == null)
                return;
            m_VecMove = Vector2.SmoothDamp(m_VecMove, m_InputMove, ref m_VelMoveVelocity, dt);

            //控制角色朝向
            if (m_VecMove.sqrMagnitude > 0.01f)
            {
                player.roleTransform.forward = Vector3.Slerp(player.roleTransform.forward, new Vector3(m_VecMove.x, 0, m_VecMove.y), 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Battle);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                (player.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Talking);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                (player.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Sit);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Crouch);
            }
        }

        public override void FixedUpdate(Role entity, float dt)
        {
            // player.gameObject.transform.position += player.roleTransform.forward * m_VecMove.sqrMagnitude * dt * player.data.statusData.moveSpeed;
            float speed = player.data.statusData.moveSpeed * (m_Runing ? 2.5f : 1);
            player.rigidbody.velocity = new Vector3(m_VecMove.x * speed, player.rigidbody.velocity.y, m_VecMove.y * speed);
            //去除掉Y轴速度带来的影响
            player.animComponent.SetVelocityZ(player.rigidbody.velocity.SetY(0).sqrMagnitude);

            // if (player.rigidbody.velocity.sqrMagnitude < 0.01f)
            // {
            //     player.controlComponent.Moving = false;
            // }
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
            // player.controlComponent.Moving = false;
        }

        private void OnRunPerformed(InputAction.CallbackContext callback)
        {
            m_Runing = true;
        }

        private void OnRunCancled(InputAction.CallbackContext callback)
        {
            m_Runing = false;
        }
    }

}