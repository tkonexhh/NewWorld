/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleState/BattleState.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:19:19 PM
	Tip:6/15/2020 5:19:19 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class BattleState : FSMState<Battle>
    {
        public override void Enter(Battle entity, params object[] args)
        {
            Debug.LogError(stateName + "--Enter");
        }

        public override void Exit(Battle entity)
        {
            Debug.LogError(stateName + "--Exit");
        }

        public override void Execute(Battle entity, float dt)
        {
            //Debug.LogError(stateName + "--Execute");
        }
    }

}