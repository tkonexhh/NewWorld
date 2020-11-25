/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Roll.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 4:04:25 PM
	Tip:11/24/2020 4:04:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Roll : PlayerBaseState_Roll
    {
        protected override void OnRollComplete()
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }

    }

}