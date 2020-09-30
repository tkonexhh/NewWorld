/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 5:08:33 PM
	Tip:9/18/2020 5:08:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class RoleControlComponent : RoleBaseComponent
    {
        private bool moving = false;
        private bool isInjured = false;
        private bool canAction = true;

        private Role_Player player;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Role_Player)role;
            player.fsmComponent.SetRoleState(RoleState.Relax);
        }

        public bool Moving
        {
            get => moving;
            set
            {
                moving = value;
                role.animComponent.SetMoving(moving);
            }
        }

        public bool IsInjured
        {
            get => isInjured;
            set
            {
                isInjured = value;
                role.animComponent.SetInjured(isInjured);
            }
        }


    }

}