/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/BattleFSM/RoleFSMStateBattle_Blocking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 10:17:27 AM
	Tip:9/30/2020 10:17:27 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{

    public class PlayerBattleFSMState_Move : PlayerBaseState_Move
    {

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            GameInputMgr.S.mainAction.AttackL.canceled += OnAttackLCanceled;
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
            GameInputMgr.S.mainAction.Roll.performed += OnRollPerformed;
            GameInputMgr.S.mainAction.Run.performed += OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled += OnRunCanceled;
            m_Player.role.controlComponent.firstAttack = true;
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            player.role.animComponent.SetMoving(GameInputMgr.S.moveVec.sqrMagnitude > 0.1f);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetHurt();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Blocking);
            }


            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Cast(Random.Range(1, 7));
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                player.role.animComponent.SetCastEndTrigger();
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                player.role.animComponent.SetAttackCastTrigger();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Crouch);
            }
        }


        public override void Exit(Player player)
        {
            base.Exit(player);
            GameInputMgr.S.mainAction.AttackL.canceled -= OnAttackLCanceled;
            GameInputMgr.S.mainAction.Roll.performed -= OnRollPerformed;
            GameInputMgr.S.mainAction.Run.performed -= OnRunPerformed;
            GameInputMgr.S.mainAction.Run.canceled -= OnRunCanceled;
            GameInputMgr.S.mainAction.Jump.performed -= OnJumpPerformed;
        }

        private void GetHurt()
        {
            m_Player.role.animComponent.SetAction(Random.Range(1, 6));
            m_Player.role.animComponent.SetHurt(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
            m_Player.role.animComponent.SetGetHurtTrigger();
        }

        private void Cast(int action)
        {
            m_Player.role.animComponent.SetAction(action);
            m_Player.role.animComponent.SetCastTrigger();
        }

        private void OnAttackLCanceled(InputAction.CallbackContext callback)
        {
            m_Player.role.controlComponent.Attack();
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
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Roll);
        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            Debug.LogError("Jump");
            m_MoveDir = Vector3.zero;
            m_MoveDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            m_MoveDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            m_MoveDir.y = 0;
            m_Player.role.controlComponent.Jump();
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Jump);

        }


        protected override void OnHitGround(RaycastHit hit)
        {
            m_Player.transform.position = targetPosition;
        }

        protected override void OnInAir(Vector3 moveDir)
        {
            Debug.LogError("To Air");
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Air, m_MoveDir);
        }

    }

}