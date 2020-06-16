/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleStateMechine.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:16:49 PM
	Tip:6/15/2020 5:16:49 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public enum BattleStateEnum
    {
        Prepare,
        Start,
        Fight,
        Over,
    }
    public class BattleStateMechine
    {
        private FSMStateMachine<Battle> m_FSM;
        private FSMStateFactory<Battle> m_Factory;

        private bool m_IsInit = false;
        public void Init(Battle battle)
        {
            m_FSM = new FSMStateMachine<Battle>(battle);
            m_Factory = new FSMStateFactory<Battle>(false);
            m_Factory.RegisterState(BattleStateEnum.Prepare, new BattleState_Prepare());
            m_Factory.RegisterState(BattleStateEnum.Start, new BattleState_Start());
            m_Factory.RegisterState(BattleStateEnum.Fight, new BattleState_Fight());
            m_Factory.RegisterState(BattleStateEnum.Over, new BattleState_Over());
            m_FSM.stateFactory = m_Factory;
            SetState(BattleStateEnum.Prepare);
            m_IsInit = true;
        }

        public void SetState(BattleStateEnum state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

        public void Update(float dt)
        {
            if (!m_IsInit) return;
            m_FSM.UpdateState(dt);
        }
    }

}