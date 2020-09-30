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

namespace Game.Logic
{
    public class RoleBattleFSMState_Crouch : FSMState<Role_Player>
    {
        private Role_Player player;
        public override void Enter(Role_Player role, params object[] args)
        {
            player = role;
            role.animComponent.SetCrouch(true);
        }

        public override void Execute(Role_Player role, float dt)
        {
            if (role.animComponent == null)
                return;

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                (role.fsmComponent.stateMachine.currentState as RoleFSMState_Battle).SetBattleState(RoleBattleState.Battle);
            }
        }

        public override void Exit(Role_Player role)
        {
            role.animComponent.SetCrouch(false);
        }

        public override void OnMsg(Role_Player entity, int key, params object[] args)
        {

        }

    }

}