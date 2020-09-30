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
    public class RoleRelaxFSMState_Sit : FSMState<Role>
    {
        private Role_Player m_Role;

        public override void Enter(Role entity, params object[] args)
        {
            m_Role = entity as Role_Player;
            GameInputMgr.S.mainAction.Any.performed += OnAnyPerformed;
            entity.animComponent.SetAction(0);
            entity.animComponent.SetActionTrigger();
        }

        public override void Execute(Role entity, float dt)
        {

        }

        public override void Exit(Role entity)
        {
            entity.animComponent.SetAction(-1);
            entity.animComponent.SetActionTrigger();
            GameInputMgr.S.mainAction.Any.performed -= OnAnyPerformed;
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }

        private void OnAnyPerformed(InputAction.CallbackContext callback)
        {
            (m_Role.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
        }
    }

}