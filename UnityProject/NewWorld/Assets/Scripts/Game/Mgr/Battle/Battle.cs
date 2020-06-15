/************************
	FileName:/Scripts/Game/Mgr/BattleMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:05:02 PM
	Tip:6/15/2020 5:05:02 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Battle
    {
        BattleStateMechine m_FSM;
        public BattleStateMechine stateMechine
        {
            get
            {
                return m_FSM;
            }
        }
        public void Init()
        {
            m_FSM = new BattleStateMechine();
            m_FSM.Init(this);
        }

    }

}