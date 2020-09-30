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
    public class RoleRelaxFSMState_Talking : FSMState<Role>
    {
        private Role_Player m_Role;
        private float m_Timer;
        public override void Enter(Role entity, params object[] args)
        {
            m_Role = entity as Role_Player;
            GameInputMgr.S.mainAction.Any.performed += OnAnyPerformed;
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
            GameInputMgr.S.mainAction.Any.performed -= OnAnyPerformed;
            entity.animComponent.SetTalking(0);
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }

        private static void RandomTalk(Role entity)
        {
            entity.animComponent.SetTalking(Random.Range(1, 9));
        }

        private void OnAnyPerformed(InputAction.CallbackContext callback)
        {
            (m_Role.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}