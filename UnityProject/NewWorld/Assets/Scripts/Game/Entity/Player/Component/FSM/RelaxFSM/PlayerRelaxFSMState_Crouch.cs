/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RelaxFSM/RoleRelaxFSMState_Talking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 1:43:03 PM
	Tip:9/30/2020 1:43:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Crouch : FSMState<Player>
    {
        // private Player m_;

        public override void Enter(Player player, params object[] args)
        {
            // m_Role = role as Role_Player;
            player.role.animComponent.SetCrouch(true);
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Crouch);
            }
        }

        public override void Exit(Player player)
        {
            player.role.animComponent.SetCrouch(false);
        }

        public override void OnMsg(Player role, int key, params object[] args)
        {

        }


    }

}