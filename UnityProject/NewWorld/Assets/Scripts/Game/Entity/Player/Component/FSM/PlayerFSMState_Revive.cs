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
    public class RoleFSMState_Revive : PlayerBaseState_GroundCheck
    {

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            player.role.controlComponent.Revive();
        }

        public override void Update(Player player, float dt)
        {

        }

        public override void Exit(Player player)
        {

        }

    }

}