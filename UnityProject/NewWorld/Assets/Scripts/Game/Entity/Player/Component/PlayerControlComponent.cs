using System;
/************************
	FileName:/Scripts/Game/Entity/Player/Component/PlayerControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:11/2/2020 4:25:33 PM
	Tip:11/2/2020 4:25:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public enum ControlState
    {
        Ground,
        Air
    }
    public class PlayerControlComponent : EntityComponennt
    {
        private Player player;

        public Vector3 velocity
        {
            get => player.monoReference.rigidbody.velocity;
            set
            {
                player.monoReference.rigidbody.velocity = value;
            }
        }

        public Vector3 position
        {
            get => player.monoReference.rigidbody.position;
        }

        public Vector3 roleForward
        {
            get => player.role.transform.forward;
            set
            {
                player.role.transform.forward = value;
            }
        }

        FSMStateMachine<Player> m_FSM;
        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
            m_FSM = new FSMStateMachine<Player>(player);
            m_FSM.stateFactory = new FSMStateFactory<Player>(false);
            m_FSM.stateFactory.RegisterState(ControlState.Ground, new PlayerControlFSMState_Ground());
            m_FSM.stateFactory.RegisterState(ControlState.Air, new PlayerControlFSMState_Air());
            m_FSM.SetCurrentStateByID(ControlState.Ground);

        }

        public override void Excute(float dt)
        {
            m_FSM?.UpdateState(dt);
        }

        public override void FixedExcute(float dt)
        {
            m_FSM?.FixedUpdateState(dt);
        }

        public void SetControlState(ControlState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }
    }
}