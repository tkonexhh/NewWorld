/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleState/BattleState_Over.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:10:58 PM
	Tip:6/15/2020 5:10:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class BattleState_Over : BattleState
    {
        public override void Enter(Battle entity, params object[] args)
        {
            base.Enter(entity);

            entity.ExitBattle();
            GamePlayMgr.S.ExitBattle();
        }

        public override void Exit(Battle entity)
        {
            base.Exit(entity);
        }
    }

}