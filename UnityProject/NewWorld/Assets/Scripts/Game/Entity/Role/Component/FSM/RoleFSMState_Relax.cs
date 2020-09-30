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
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public enum RoleRelaxState
    {
        Move,
        Crouch,
        Talking,
        Sit,
    }

    public class RoleFSMState_Relax : FSMState<Role>
    {
        private Role_Player player;
        private FSMStateMachine<Role> m_FSM;


        public override void Enter(Role entity, params object[] args)
        {
            player = entity as Role_Player;


            if (m_FSM == null)
            {
                m_FSM = new FSMStateMachine<Role>(player);
                m_FSM.stateFactory = new FSMStateFactory<Role>(false);
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Talking, new RoleRelaxFSMState_Talking());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Sit, new RoleRelaxFSMState_Sit());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Move, new RoleRelaxFSMState_Move());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Crouch, new RoleRelaxFSMState_Crouch());
            }

            SetRelaxState(RoleRelaxState.Move);
        }

        public override void Execute(Role role, float dt)
        {
            m_FSM?.UpdateState(dt);
        }

        public override void Exit(Role entity)
        {
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {
        }

        public void SetRelaxState(RoleRelaxState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

    }

}