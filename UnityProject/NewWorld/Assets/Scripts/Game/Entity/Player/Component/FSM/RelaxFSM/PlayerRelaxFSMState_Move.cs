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
        private bool m_Runing = false;
        private Vector3 m_MoveVelocity;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
            GameInputMgr.S.mainAction.Run.performed += OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled += OnRunCancled;
            player.role.animComponent.SetMoving(true);
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            //控制角色朝向
            if (GameInputMgr.S.moveVec.sqrMagnitude > 0.01f)
            {
                player.controlComponent.SetForward(Vector3.Slerp(player.controlComponent.roleForward, new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y), 0.5f));
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
            float maxSpeed = m_Runing ? player.role.data.baseData.runSpeed : player.role.data.baseData.walkSpeed;
            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            m_MoveVelocity = player.controlComponent.velocity;
            float maxSpeedChange = player.role.data.baseData.acceleration * dt;
            m_MoveVelocity.x = Mathf.MoveTowards(m_MoveVelocity.x, desiredVelocity.x, maxSpeedChange);
            m_MoveVelocity.z = Mathf.MoveTowards(m_MoveVelocity.z, desiredVelocity.z, maxSpeedChange);
            // Debug.LogError(GameInputMgr.S.moveVec + "----" + m_MoveVelocity + "---" + maxSpeedChange + "----" + desiredVelocity);
            player.controlComponent.velocity = m_MoveVelocity;
            //去除掉Y轴速度带来的影响
            player.role.animComponent.SetVelocityZ(player.controlComponent.velocity.magnitude);
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Jump.performed -= OnJumpPerformed;
            GameInputMgr.S.mainAction.Run.performed -= OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled -= OnRunCancled;
            player.role.animComponent.SetMoving(false);
        }

        public override void OnMsg(Player player, int key, params object[] args)
        {

        }

        private void OnRunPerformed(InputAction.CallbackContext callback)
        {
            m_Runing = true;
        }

        private void OnRunCancled(InputAction.CallbackContext callback)
        {
            m_Runing = false;
        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            //TODO 点击条约进入Air状态 但是air状态还在地面上
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Air);
        }
    }

}