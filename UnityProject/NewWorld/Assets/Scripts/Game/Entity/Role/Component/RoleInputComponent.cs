/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleInputComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/17/2020 8:12:17 PM
	Tip:9/17/2020 8:12:17 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.Logic
{
    //响应Input
    public class RoleInputComponent : RoleBaseComponent
    {
        private CharacterController m_Controller;
        private Role_Player player;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = role as Role_Player;
            m_Controller = role.roleGameObject.GetComponentInChildren<CharacterController>();

        }

        public override void Update(float dt)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                player.controlComponent.IsInjured = !player.controlComponent.IsInjured;
            }
        }

    }

}