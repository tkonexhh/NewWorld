/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BattleFSM/PlayerBattleFSMState_Land.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 12:28:42 PM
	Tip:11/25/2020 12:28:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerBattleFSMState_Land : PlayerBaseState_Land
    {

        protected override void OnLandComplete()
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Move);
        }
    }

}