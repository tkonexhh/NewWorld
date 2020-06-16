/************************
	FileName:/Scripts/Game/Mgr/BattleMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:05:02 PM
	Tip:6/15/2020 5:05:02 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class Battle
    {
        List<BattleMapBlock> m_MapBlocks;
        BattleStateMechine m_FSM;

        public List<BattleMapBlock> MapBlocks
        {
            get
            {
                return m_MapBlocks;
            }
        }

        public BattleStateMechine stateMechine
        {
            get
            {
                return m_FSM;
            }
        }

        public void Init()
        {
            m_MapBlocks = new List<BattleMapBlock>();

            m_FSM = new BattleStateMechine();
            m_FSM.Init(this);
        }

        private void Update()
        {
            //m_FSM.Update(Time.deltaTime);
        }

        public void ExitBattle()
        {
            for (int i = m_MapBlocks.Count - 1; i >= 0; i--)
            {
                AddressableResMgr.S.ReleaseInstance(m_MapBlocks[i].gameObject);
                m_MapBlocks.RemoveAt(i);
            }
            m_MapBlocks = null;
            m_FSM = null;
        }
    }

}