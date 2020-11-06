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
    public enum RoleWeapon
    {
        Unarmed = 0,
        DualHandAxe = 3,
    }
    public class PlayerBattleFSMState_Move : FSMState<Player>
    {
        private Player m_Player;


        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            player.role.animComponent.SetMoving(true);
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetHurt();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Blocking);
            }

            if (GameInputMgr.S.moveVec.sqrMagnitude < 0.1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    player.role.animComponent.SetLeftRight(1);
                    player.role.animComponent.SetAction(Random.Range(1, 4));
                    player.role.animComponent.SetAttackTrigger();
                }

                if (Input.GetMouseButtonDown(1))
                {
                    player.role.animComponent.SetLeftRight(2);
                    player.role.animComponent.SetAction(Random.Range(1, 4));
                    player.role.animComponent.SetAttackTrigger();
                }
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

        public override void FixedUpdate(Player player, float dt)
        {
            // 控制角色朝向
            if (GameInputMgr.S.moveVec.sqrMagnitude > 0.01f)
            {
                player.controlComponent.roleForward = Vector3.Slerp(player.controlComponent.roleForward, new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y), 0.5f);
            }
            player.role.animComponent.SetVelocityZ(player.controlComponent.velocity.magnitude);
        }

        public override void Exit(Player player)
        {
            player.role.animComponent.SetMoving(false);
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

    }

}