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
        None,
        Idle,
        Move,
        Air,
        Crouch,
        Roll,
        // Jump,
        Fall,
        Land,
        Talking,
        Sit,
    }

    public class PlayerFSMState_Relax : FSMState<Player>
    {
        // private Role_Player player;
        private FSMStateMachine<Player> m_FSM;


        public override void Enter(Player entity, params object[] args)
        {
            // player = entity as Role_Player;
            if (m_FSM == null)
            {
                m_FSM = new FSMStateMachine<Player>(entity);
                m_FSM.stateFactory = new FSMStateFactory<Player>(false);
                m_FSM.stateFactory.RegisterState(RoleRelaxState.None, new PlayerBaseState_None());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Talking, new PlayerRelaxFSMState_Talking());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Sit, new PlayerRelaxFSMState_Sit());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Move, new PlayerRelaxFSMState_Move());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Air, new PlayerRelaxFSMState_Air());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Roll, new PlayerRelaxFSMState_Roll());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Land, new PlayerRelaxFSMState_Land());
                // m_FSM.stateFactory.RegisterState(RoleRelaxState.Idle, new RoleRelaxFSMState_Idle());
                m_FSM.stateFactory.RegisterState(RoleRelaxState.Crouch, new PlayerRelaxFSMState_Crouch());
            }

            SetRelaxState(RoleRelaxState.Move);
        }

        public override void Update(Player player, float dt)
        {
            m_FSM?.UpdateState(dt);
        }

        public override void FixedUpdate(Player player, float dt)
        {
            m_FSM?.FixedUpdateState(dt);
        }

        public override void Exit(Player player)
        {
            SetRelaxState(RoleRelaxState.None);
        }

        public override void OnMsg(Player player, int key, params object[] args)
        {
        }

        public void SetRelaxState(RoleRelaxState state, params object[] args)
        {
            m_FSM.SetCurrentStateByID(state, args);
        }

    }

}