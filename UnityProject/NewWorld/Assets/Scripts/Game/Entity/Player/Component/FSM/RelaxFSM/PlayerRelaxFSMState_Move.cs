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
    public class PlayerRelaxFSMState_Move : FSMState<Player>
    {
        private Player m_Player;
        private Vector2 m_InputMove = Vector2.zero;
        private Vector2 m_VecMove = Vector2.zero;
        private bool m_Runing = false;

        private Vector2 m_VelMoveVelocity;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled += OnMoveCancled;
            GameInputMgr.S.mainAction.Run.performed += OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled += OnRunCancled;
            // player.animComponent.SetMoving(true);
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;
            m_VecMove = Vector2.SmoothDamp(m_VecMove, m_InputMove, ref m_VelMoveVelocity, dt);

            //控制角色朝向
            if (m_VecMove.sqrMagnitude > 0.01f)
            {
                player.controlComponent.SetForward(Vector3.Slerp(player.controlComponent.roleForward, new Vector3(m_VecMove.x, 0, m_VecMove.y), 0.5f));
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Battle);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Talking);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Sit);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Crouch);
            }
        }

        public override void FixedUpdate(Player player, float dt)
        {
            float speed = player.role.data.statusData.moveSpeed * (m_Runing ? 2.5f : 1);
            player.controlComponent.SetVelocity(new Vector3(m_VecMove.x * speed, player.controlComponent.velocity.y, m_VecMove.y * speed));
            //去除掉Y轴速度带来的影响
            player.role.animComponent.SetVelocityZ(player.controlComponent.velocity.SetY(0).sqrMagnitude);
        }

        public override void Exit(Player entity)
        {
            GameInputMgr.S.mainAction.Move.performed -= OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled -= OnMoveCancled;
            // player.animComponent.SetMoving(false);
        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {

        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            m_InputMove = callback.ReadValue<Vector2>();
            // player.animComponent.SetMoving(true);
        }

        private void OnMoveCancled(InputAction.CallbackContext callback)
        {
            m_InputMove = Vector2.zero;
            // player.animComponent.SetMoving(false);
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