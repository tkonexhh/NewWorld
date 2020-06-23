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
        private FSMStateMachine<Battle> m_TurnFSM;
        private FSMStateFactory<Battle> m_Factory;
        public override void Enter(Battle entity, params object[] args)
        {
            base.Enter(entity);
            m_TurnFSM = new FSMStateMachine<Battle>(entity);
            m_Factory = new FSMStateFactory<Battle>(false);
            m_Factory.RegisterState(TurnStateEnum.WaitingForInput, new TurnState_WaittingForInput());
            m_Factory.RegisterState(TurnStateEnum.UnitSelected, new TurnState_UnitSelected());
            m_Factory.RegisterState(TurnStateEnum.TurnChanging, new TurnState_TurnChanging());
            //m_Factory.RegisterState(TurnStateEnum.AITurn, new BattleState_Over());
            m_Factory.RegisterState(TurnStateEnum.GameOver, new TurnState_GameOver());
            m_TurnFSM.stateFactory = m_Factory;
            m_TurnFSM.SetCurrentStateByID(TurnStateEnum.WaitingForInput);
        }

        public override void Exit(Battle entity)
        {
            base.Exit(entity);
        }

        public override void Execute(Battle entity, float dt)
        {
            base.Execute(entity, dt);
            m_TurnFSM.UpdateState(dt);
        }
    }

}