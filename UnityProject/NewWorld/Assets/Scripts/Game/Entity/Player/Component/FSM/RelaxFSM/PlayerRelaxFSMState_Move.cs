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
    public class PlayerRelaxFSMState_Move : PlayerBaseState_Move
    {

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            GameInputMgr.S.mainAction.Roll.performed += OnRollPerformed;
            GameInputMgr.S.mainAction.Run.performed += OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled += OnRunCanceled;
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            player.role.animComponent.SetMoving(GameInputMgr.S.moveVec.sqrMagnitude > 0.1f);
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

        // public override void FixedUpdate(Player player, float dt)
        // {
        //     base.FixedUpdate(player, dt);
        // }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Roll.performed -= OnRollPerformed;
            GameInputMgr.S.mainAction.Run.performed -= OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled -= OnRunCanceled;
        }

        private void OnRunPerformed(InputAction.CallbackContext callback)
        {
            m_Player.role.controlComponent.running = true;
        }

        private void OnRunCanceled(InputAction.CallbackContext callback)
        {
            m_Player.role.controlComponent.running = false;
        }


        private void OnRollPerformed(InputAction.CallbackContext callback)
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Roll);
        }

        protected override void OnHitGround(RaycastHit hit)
        {
            m_Player.transform.position = targetPosition;
        }

        protected override void OnInAir(Vector3 moveDir)
        {
            // Debug.LogError("To Air");
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Air, m_MoveDir);
        }

    }

}