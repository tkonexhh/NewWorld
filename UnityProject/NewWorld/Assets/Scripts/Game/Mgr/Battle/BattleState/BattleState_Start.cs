/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleState/BattleState_Start.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:10:17 PM
	Tip:6/15/2020 5:10:17 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class BattleState_Start : BattleState
    {
        public override void Enter(Battle entity, params object[] args)
        {
            base.Enter(entity);
            entity.stateMechine.SetState(BattleStateEnum.Fight);
        }

        public override void Exit(Battle entity)
        {
            base.Exit(entity);
        }
    }

}