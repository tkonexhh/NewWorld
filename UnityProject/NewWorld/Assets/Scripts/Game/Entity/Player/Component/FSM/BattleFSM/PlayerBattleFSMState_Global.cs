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
    public class PlayerBattleFSMState_Global : FSMState<Player>
    {
        public override void Enter(Player player, params object[] args)
        {
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Relax);
            }
        }

        public override void Exit(Player role)
        {
        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {

        }

    }

}