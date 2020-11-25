/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BattleFSM/PlayerBattleFSMState_Roll.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 12:29:03 PM
	Tip:11/25/2020 12:29:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerBattleFSMState_Roll : PlayerBaseState_Roll
    {
        protected override void OnRollComplete()
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Move);
        }

    }
}