/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Land.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 8:03:56 PM
	Tip:11/24/2020 8:03:56 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Land : PlayerBaseState_Land
    {
        protected override void OnLandComplete()
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}