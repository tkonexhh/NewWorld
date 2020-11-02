/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Sit.cs
	CreateAuthor:neo.xu
	CreateTime:9/28/2020 6:25:39 PM
	Tip:9/28/2020 6:25:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class RoleFSMState_Swim : FSMState<Player>
    {
        public override void Enter(Player player, params object[] args)
        {
            player.role.animComponent.SwimTrigger();
        }

        public override void Update(Player player, float dt)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                player.fsmComponent.SetRoleState(RoleState.Relax);
            }
        }

        public override void Exit(Player role)
        {

        }

        public override void OnMsg(Player role, int key, params object[] args)
        {

        }
    }

}