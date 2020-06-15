/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleState/BattleState_Fight.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:11:21 PM
	Tip:6/15/2020 5:11:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public enum InnerBattleState
    {
        WaitingForInput,
        UnitSelected,
        TurnChanging,
        AITurn,
        GameOver,
    }


    public class BattleState_Fight : BattleState
    {
        //子状态机
        private FSMStateMachine<Battle> m_FSM;
        private FSMStateFactory<Battle> m_Factory;
        public override void Enter(Battle entity)
        {
            base.Enter(entity);
            m_FSM = new FSMStateMachine<Battle>(entity);
            m_Factory = new FSMStateFactory<Battle>(true);
            m_Factory.RegisterState(InnerBattleState.WaitingForInput, new BattleState_Prepare());
            m_Factory.RegisterState(InnerBattleState.UnitSelected, new BattleState_Start());
            m_Factory.RegisterState(InnerBattleState.TurnChanging, new BattleState_Fight());
            m_Factory.RegisterState(InnerBattleState.AITurn, new BattleState_Over());
            m_Factory.RegisterState(InnerBattleState.GameOver, new BattleState_Over());
            m_FSM.stateFactory = m_Factory;
            m_FSM.SetCurrentStateByID(InnerBattleState.WaitingForInput);
        }

        public override void Exit(Battle entity)
        {
            base.Exit(entity);
        }
    }

}