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
    public class RoleFSMState_Death : FSMState<Role>
    {
        private Role_Player player;


        public override void Enter(Role entity, params object[] args)
        {
            player = entity as Role_Player;
            entity.animComponent.SetDeathTrigger();
        }

        public override void Update(Role role, float dt)
        {

        }

        public override void Exit(Role entity)
        {

        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }
    }

}