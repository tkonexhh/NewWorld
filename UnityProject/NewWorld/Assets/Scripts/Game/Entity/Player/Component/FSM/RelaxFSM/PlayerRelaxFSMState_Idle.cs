/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RelaxFSM/RoleRelaxFSMState_Idle.cs
	CreateAuthor:neo.xu
	CreateTime:10/23/2020 10:42:36 AM
	Tip:10/23/2020 10:42:36 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class RoleRelaxFSMState_Idle : FSMState<Player>
    {
        private Player m_Player;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
        }

        public override void Update(Player player, float dt)
        {



        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Move.performed -= OnMovePerformed;
        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}