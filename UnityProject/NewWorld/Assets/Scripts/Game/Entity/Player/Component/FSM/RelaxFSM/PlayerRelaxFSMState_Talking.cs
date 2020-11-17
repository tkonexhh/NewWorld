/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RelaxFSM/RoleRelaxFSMState_Talking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 1:43:03 PM
	Tip:9/30/2020 1:43:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Talking : FSMState<Player>
    {
        private Player m_Player;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Any.performed += OnAnyPerformed;
            player.role.controlComponent.StartTalking();

        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Any.performed -= OnAnyPerformed;
            player.role.controlComponent.EndTalking();
        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {

        }


        private void OnAnyPerformed(InputAction.CallbackContext callback)
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}