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
    public class PlayerFSMComponent : EntityComponennt
    {
        private FSMStateMachine<Player> m_FSM;

        public FSMStateMachine<Player> stateMachine => m_FSM;


        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_FSM = new FSMStateMachine<Player>(ownner as Player);
            m_FSM.SetGlobalState(new PlayerFSMState_Global());
            m_FSM.stateFactory = new FSMStateFactory<Player>(false);
            m_FSM.stateFactory.RegisterState(RoleState.Relax, new PlayerFSMState_Relax());
            m_FSM.stateFactory.RegisterState(RoleState.Battle, new PlayerFSMState_Battle());
            m_FSM.stateFactory.RegisterState(RoleState.Death, new RoleFSMState_Death());
            m_FSM.stateFactory.RegisterState(RoleState.Swim, new RoleFSMState_Swim());

            SetRoleState(RoleState.Relax);
        }

        public override void Excute(float dt)
        {
            m_FSM.UpdateState(dt);
        }

        public override void FixedExcute(float dt)
        {
            m_FSM.FixedUpdateState(dt);
        }

        public void SetRoleState(RoleState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }
    }

    public enum RoleState
    {
        Relax,
        Battle,
        Swim,
        Death,
    }

}