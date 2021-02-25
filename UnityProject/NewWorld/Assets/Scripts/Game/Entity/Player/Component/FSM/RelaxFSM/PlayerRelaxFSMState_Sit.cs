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
    public class PlayerRelaxFSMState_Sit : PlayerBaseState_GroundCheck
    {

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.anyEvent += OnAny;
            player.role.controlComponent.Sit();
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.anyEvent -= OnAny;
        }

        public override void Update(Player player, float dt)
        {
            AnimatorStateInfo info = player.role.monoReference.animator.GetCurrentAnimatorStateInfo(0);
            // 判断动画是否播放完成
            if (info.IsName(player.role.controlComponent.animName.sit_StandUp) && info.normalizedTime >= 1f)
            {
                m_Player.role.controlComponent.Idle();
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }
        }

        private void OnAny()
        {
            AnimatorStateInfo info = m_Player.role.monoReference.animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName(m_Player.role.controlComponent.animName.sit_Idle) && !m_Player.role.monoReference.animator.IsInTransition(0))
            {
                m_Player.role.controlComponent.SitStandUp();
            }
        }
    }

}