/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleState_Talking.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 4:49:22 PM
	Tip:9/25/2020 4:49:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class RoleFSMState_Talking : FSMState<Role>
    {
        private float m_Timer;
        public override void Enter(Role entity, params object[] args)
        {
            Debug.LogError("RoleFSMState_Talking Enter");
            m_Timer = 0;
            RandomTalk(entity);
        }

        public override void Execute(Role entity, float dt)
        {
            m_Timer += dt;
            if (m_Timer >= 2)
            {
                m_Timer = 0;
                RandomTalk(entity);
            }
        }

        public override void Exit(Role entity)
        {
            entity.animComponent.SetTalking(0);
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }

        private static void RandomTalk(Role entity)
        {
            entity.animComponent.SetTalking(Random.Range(1, 9));
        }
    }

}