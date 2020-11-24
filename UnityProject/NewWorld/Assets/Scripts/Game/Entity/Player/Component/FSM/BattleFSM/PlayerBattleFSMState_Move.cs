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

    public class PlayerBattleFSMState_Move : PlayerBaseMoveState
    {

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            GameInputMgr.S.mainAction.AttackL.performed += OnAttackLPerformed;
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
            GameInputMgr.S.mainAction.AttackL.performed -= OnAttackLPerformed;
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

        private void OnAttackLPerformed(InputAction.CallbackContext callback)
        {
            m_Player.role.controlComponent.Attack();
        }

        protected override void OnHitGround(RaycastHit hit)
        {
            if (GameInputMgr.S.moveAmount > 0)
            {
                //TODO 如果刚刚落地的话，坐标需要插值过去
                // player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, dt);
                m_Player.transform.position = targetPosition;
            }
            else
            {
                m_Player.transform.position = targetPosition;
            }
        }

        protected override void OnInAir(Vector3 moveDir)
        {
            Debug.LogError("To Air");
            // (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Air, m_MoveDir);
        }

    }

}