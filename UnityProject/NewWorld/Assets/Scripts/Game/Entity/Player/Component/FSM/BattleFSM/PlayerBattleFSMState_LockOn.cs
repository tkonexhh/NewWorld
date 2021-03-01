/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BattleFSM/PlayerBattleFSMState_LockOn.cs
	CreateAuthor:xuhonghua
	CreateTime:3/1/2021 8:28:15 PM
	Tip:3/1/2021 8:28:15 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerBattleFSMState_LockOn : PlayerBaseState_Move
    {

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            Transform target = (Transform)args[0];
            GameCameraMgr.S.FocusTarget(target);
            player.role.iKComponent.SetFocusTarget(target);
            GameInputMgr.S.attackLEvent += OnAttackL;
            GameInputMgr.S.jumpEvent += OnJump;
            GameInputMgr.S.rollEvent += OnRoll;
            GameInputMgr.S.enableRunEvent += OnEnableRun;
            GameInputMgr.S.disableRunEvent += OnDisableRun;
            m_Player.role.controlComponent.firstAttack = true;
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            player.role.animComponent.SetMoving(player.controlComponent.movementVector.magnitude > 0.1f);

            if (Input.GetKeyDown(KeyCode.F))
            {
                FindFocusTarget();
            }

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
            GameInputMgr.S.attackLEvent -= OnAttackL;
            GameInputMgr.S.rollEvent -= OnRoll;
            GameInputMgr.S.enableRunEvent -= OnEnableRun;
            GameInputMgr.S.disableRunEvent -= OnDisableRun;
            GameInputMgr.S.jumpEvent -= OnJump;
            GameCameraMgr.S.SetType(GameCameraType.FreeLook);
            player.role.iKComponent.SetFocusTarget(null);
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

        private void OnAttackL()
        {
            m_Player.role.controlComponent.Attack();
        }

        private void OnEnableRun()
        {
            m_Player.role.controlComponent.running = true;
        }

        private void OnDisableRun()
        {
            m_Player.role.controlComponent.running = false;
        }

        private void OnRoll()
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Roll);
        }

        private void OnJump()
        {
            m_Player.role.controlComponent.Jump();
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Jump);
        }

        private void FindFocusTarget()
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Move);
        }


        protected override void OnHitGround(RaycastHit hit)
        {
            m_Player.transform.position = targetPosition;
        }

        protected override void OnInAir(Vector3 moveDir)
        {
            Debug.LogError("To Air");
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Air);
        }

    }

}