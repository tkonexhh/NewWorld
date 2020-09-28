/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Sit.cs
	CreateAuthor:neo.xu
	CreateTime:9/28/2020 6:25:39 PM
	Tip:9/28/2020 6:25:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class RoleFSMState_Sit : FSMState<Role>
    {
        private Role m_Role;
        public override void Init()
        {
            GameInputMgr.S.mainAction.Any.performed += OnAnyPerformed;
        }

        public override void Enter(Role entity, params object[] args)
        {
            m_Role = entity;
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
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }

        private void OnAnyPerformed(InputAction.CallbackContext callback)
        {
            (m_Role as Role_Player).fsmComponent.SetRoleState(RoleState.Relax);
        }
    }

}