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
    public enum TurnStateEnum
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
            m_Factory = new FSMStateFactory<Battle>(false);
            m_Factory.RegisterState(TurnStateEnum.WaitingForInput, new BattleState_Prepare());
            m_Factory.RegisterState(TurnStateEnum.UnitSelected, new BattleState_Start());
            m_Factory.RegisterState(TurnStateEnum.TurnChanging, new TurnState_TurnChanging());
            m_Factory.RegisterState(TurnStateEnum.AITurn, new BattleState_Over());
            m_Factory.RegisterState(TurnStateEnum.GameOver, new TurnState_GameOver());
            m_FSM.stateFactory = m_Factory;
            m_FSM.SetCurrentStateByID(TurnStateEnum.WaitingForInput);
        }

        public override void Exit(Battle entity)
        {
            base.Exit(entity);
        }
    }

}