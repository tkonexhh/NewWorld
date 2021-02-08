/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BasicState/PlayerBaseState_None.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 3:14:03 PM
	Tip:11/25/2020 3:14:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerBaseState_Crouch : PlayerBaseState_GroundCheck
    {
        private bool m_ToIdle = false;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.disableCrouchEvent += OnDisableCrouch;
            player.role.controlComponent.Crouch();
            m_ToIdle = false;
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.disableCrouchEvent -= OnDisableCrouch;
        }

        public override void Update(Player player, float dt)
        {
            AnimatorStateInfo info = player.role.monoReference.animator.GetCurrentAnimatorStateInfo(0);
            // 判断动画是否播放完成
            if (player.role.monoReference.animator.IsInTransition(0) && info.IsName(player.role.controlComponent.animName.crouch) && info.normalizedTime >= 1f)
            {
                if (m_Player.fsmComponent.stateMachine.currentState is PlayerFSMState_Battle stateBattle)
                {
                    stateBattle.SetBattleState(RoleBattleState.Move);
                }
                else if (m_Player.fsmComponent.stateMachine.currentState is PlayerFSMState_Relax stateRelax)
                {
                    stateRelax.SetRelaxState(RoleRelaxState.Move);
                }
            }
        }

        private void OnDisableCrouch()
        {
            if (m_ToIdle) return;
            m_ToIdle = true;
            m_Player.role.controlComponent.Idle();
            //TODO 等待起身完毕之后才可以再次走路
        }


    }

}