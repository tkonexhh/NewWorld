/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/3/2020 7:26:03 PM
	Tip:11/3/2020 7:26:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Air : PlayerBaseState_Air
    {

        protected override void OnHitGround(RaycastHit hit)
        {
            if (m_AirTimer > 0.8f)
            {
                Debug.LogError("InAirTimer:" + m_AirTimer);
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Land);
            }
            else
            {
                // Debug.LogError("Back To Ground");
                m_Player.role.controlComponent.BackToMovement();
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }
        }
    }

}