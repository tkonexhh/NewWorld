/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Relax.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 5:15:24 PM
	Tip:9/25/2020 5:15:24 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class RoleFSMState_Relax : FSMState<Role>
    {
        public override void Enter(Role entity, params object[] args)
        {
            base.Enter(entity, args);
        }

        public override void Execute(Role entity, float dt)
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