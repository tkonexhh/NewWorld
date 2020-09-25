/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 4:13:37 PM
	Tip:9/25/2020 4:13:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class RoleFSMComponent : RoleBaseComponent
    {
        private FSMStateMachine<Role> m_FSM;


        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_FSM = new FSMStateMachine<Role>(role);
            m_FSM.stateFactory = new FSMStateFactory<Role>(false);
            m_FSM.stateFactory.RegisterState(RoleState.Talking, new RoleFSMState_Talking());
            m_FSM.stateFactory.RegisterState(RoleState.Relax, new RoleFSMState_Relax());
        }

        public override void Update(float dt)
        {
            m_FSM.UpdateState(dt);
        }

        public void SetRoleState(RoleState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }
    }

    public enum RoleState
    {
        Relax,
        Talking,
    }

}