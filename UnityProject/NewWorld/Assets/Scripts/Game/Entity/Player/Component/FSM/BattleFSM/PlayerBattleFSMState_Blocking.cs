/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/BattleFSM/RoleFSMStateBattle_Blocking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 10:17:27 AM
	Tip:9/30/2020 10:17:27 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerBattleFSMState_Blocking : FSMState<Player>
    {
        private Role_Player player;
        public override void Enter(Player player, params object[] args)
        {
            player.role.controlComponent.Block();
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetHurt();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                BlockBreak();
            }

            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Battle);
            }
        }

        public override void Exit(Player player)
        {
            player.role.controlComponent.UnBlock();
        }

        public override void OnMsg(Player player, int key, params object[] args)
        {

        }

        private void GetHurt()
        {
            player.animComponent.SetAction(Random.Range(1, 3));
            player.animComponent.SetGetHurtTrigger();
        }

        private void BlockBreak()
        {
            player.animComponent.SetBlockBreakTrigger();
        }
    }

}