/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 3:57:22 PM
	Tip:6/12/2020 3:57:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class GamePlayMgr : TMonoSingleton<GamePlayMgr>
    {
        private Battle m_CurBattle;
        public bool isBattle
        {
            get
            {
                return m_CurBattle != null;
            }
        }

        public List<Character> m_Enemy;

        public override void OnSingletonInit()
        {

        }

        private void Start()
        {
            m_CurBattle = new Battle();
            m_CurBattle.Init();
            m_CurBattle.SetEnemy(m_Enemy);
        }

        public void ExitBattle()
        {
            if (m_CurBattle == null) return;

            m_CurBattle.ExitBattle();
            m_CurBattle = null;
        }

    }

}