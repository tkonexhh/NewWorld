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
    public class PlayerRelaxFSMState_Move : FSMState<Player>
    {
        private Player m_Player;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            player.role.animComponent.SetMoving(GameInputMgr.S.moveVec.sqrMagnitude > 0.1f);
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Battle);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Talking);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Sit);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Crouch);
            }
        }

        public override void FixedUpdate(Player player, float dt)
        {
            // 控制角色朝向
            // if (player.role.controlComponent.canRotate)
            // {
            //     Vector2 velXZ = new Vector2(player.controlComponent.velocity.x, player.controlComponent.velocity.z);
            //     if (velXZ.sqrMagnitude > 0.01f)
            //     {
            //         player.controlComponent.roleForward = Vector3.Slerp(player.controlComponent.roleForward, new Vector3(velXZ.x, 0, velXZ.y), 0.5f);
            //     }
            // }
            player.role.animComponent.SetVelocityZ(player.controlComponent.velocity.sqrMagnitude);
        }

        public override void Exit(Player player)
        {
        }
    }

}