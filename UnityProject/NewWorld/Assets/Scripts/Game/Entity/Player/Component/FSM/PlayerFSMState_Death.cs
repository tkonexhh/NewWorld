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
    public class RoleFSMState_Death : FSMState<Player>
    {


        public override void Enter(Player entity, params object[] args)
        {
            entity.role.animComponent.SetDeathTrigger();
        }

        public override void Update(Player role, float dt)
        {

        }

        public override void Exit(Player entity)
        {

        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {

        }
    }

}