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
    public class PlayerRelaxFSMState_Sit : FSMState<Player>
    {
        private Player m_Role;

        public override void Enter(Player player, params object[] args)
        {
            m_Role = player;
            GameInputMgr.S.mainAction.Any.performed += OnAnyPerformed;
            player.role.animComponent.SetAction(0);
            player.role.animComponent.SetActionTrigger();
        }

        public override void Update(Player player, float dt)
        {

        }

        public override void Exit(Player player)
        {
            player.role.animComponent.SetAction(-1);
            player.role.animComponent.SetActionTrigger();
            GameInputMgr.S.mainAction.Any.performed -= OnAnyPerformed;
        }

        public override void OnMsg(Player player, int key, params object[] args)
        {

        }

        private void OnAnyPerformed(InputAction.CallbackContext callback)
        {
            (m_Role.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}