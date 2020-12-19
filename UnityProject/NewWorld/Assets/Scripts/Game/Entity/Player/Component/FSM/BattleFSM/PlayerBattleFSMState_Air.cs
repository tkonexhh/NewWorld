/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BattleFSM/PlayerBattleFSMState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 12:29:25 PM
	Tip:11/25/2020 12:29:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerBattleFSMState_Air : PlayerBaseState_Air
    {

        protected override void OnHitGround(RaycastHit hit)
        {
            if (m_AirTimer > 0.8f)
            {
                Debug.LogError("InAirTimer:" + m_AirTimer);
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Land);
            }
            else
            {
                // Debug.LogError("Back To Ground");
                m_Player.role.controlComponent.BackToMovement();
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Move);
            }
        }


    }

}