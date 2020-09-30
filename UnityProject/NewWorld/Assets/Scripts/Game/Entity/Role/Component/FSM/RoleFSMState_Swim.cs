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
    public class RoleFSMState_Swim : FSMState<Role>
    {
        private Role_Player player;


        public override void Enter(Role role, params object[] args)
        {
            player = role as Role_Player;

            role.animComponent.SwimTrigger();
        }

        public override void Execute(Role role, float dt)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                player.fsmComponent.SetRoleState(RoleState.Relax);
            }
        }

        public override void Exit(Role role)
        {

        }

        public override void OnMsg(Role role, int key, params object[] args)
        {

        }
    }

}