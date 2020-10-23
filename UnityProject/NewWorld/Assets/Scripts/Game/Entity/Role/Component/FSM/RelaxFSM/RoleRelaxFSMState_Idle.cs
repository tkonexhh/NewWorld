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
    public class RoleRelaxFSMState_Idle : FSMState<Role>
    {
        private Role_Player player;

        public override void Enter(Role role, params object[] args)
        {
            player = role as Role_Player;
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
        }

        public override void Update(Role role, float dt)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Battle);
            }
        }

        public override void Exit(Role entity)
        {
            GameInputMgr.S.mainAction.Move.performed -= OnMovePerformed;
        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            (player.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}