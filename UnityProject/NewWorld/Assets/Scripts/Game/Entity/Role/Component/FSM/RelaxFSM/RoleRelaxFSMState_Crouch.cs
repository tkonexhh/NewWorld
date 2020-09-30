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
    public class RoleRelaxFSMState_Crouch : FSMState<Role>
    {
        private Role_Player m_Role;

        public override void Enter(Role role, params object[] args)
        {
            m_Role = role as Role_Player;
            role.animComponent.SetCrouch(true);
        }

        public override void Execute(Role role, float dt)
        {
            if (role.animComponent == null)
                return;

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                (m_Role.fsmComponent.stateMachine.currentState as RoleFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }
        }

        public override void Exit(Role role)
        {
            role.animComponent.SetCrouch(false);
        }

        public override void OnMsg(Role role, int key, params object[] args)
        {

        }


    }

}