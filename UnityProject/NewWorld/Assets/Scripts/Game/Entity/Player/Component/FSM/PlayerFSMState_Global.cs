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
    public class PlayerFSMState_Global : FSMState<Player>
    {
        // private Role_Player player;


        public override void Enter(Player player, params object[] args)
        {
            // player = role as Role_Player;
        }

        public override void Update(Player player, float dt)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                player.fsmComponent.SetRoleState(RoleState.Death);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                player.fsmComponent.SetRoleState(RoleState.Swim);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                player.role.animComponent.ReviveTrigger();
            }
        }

        public override void Exit(Player player)
        {

        }

        public override void OnMsg(Player player, int key, params object[] args)
        {

        }
    }

}