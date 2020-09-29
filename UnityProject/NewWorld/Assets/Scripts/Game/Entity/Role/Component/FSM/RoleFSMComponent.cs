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
            m_FSM.SetGlobalState(new RoleFSMState_Global());
            m_FSM.stateFactory = new FSMStateFactory<Role>(false);
            m_FSM.stateFactory.RegisterState(RoleState.Talking, new RoleFSMState_Talking());
            m_FSM.stateFactory.RegisterState(RoleState.Relax, new RoleFSMState_Relax());
            m_FSM.stateFactory.RegisterState(RoleState.Sit, new RoleFSMState_Sit());
            m_FSM.stateFactory.RegisterState(RoleState.Weapon, new RoleFSMState_Weapon());
            m_FSM.stateFactory.RegisterState(RoleState.Death, new RoleFSMState_Death());
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
        Sit,
        Weapon,
        Death,
    }

}