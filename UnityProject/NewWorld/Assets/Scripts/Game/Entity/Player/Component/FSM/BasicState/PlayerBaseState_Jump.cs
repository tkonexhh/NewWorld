/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BasicState/PlayerBaseState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 2:51:55 PM
	Tip:11/25/2020 2:51:55 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerBaseState_Jump : FSMState<Player>
    {
        protected Player m_Player;

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            m_Player = player;
            m_Player.monoReference.rigidbody.velocity += (Vector3.up * m_Player.role.data.baseData.jumpHeight);
        }

        public override void Exit(Player entity)
        {
        }

        public override void FixedUpdate(Player player, float dt)
        {
            base.FixedUpdate(player, dt);

            if (player.role.controlComponent.canRotate)
            {
                HandleRotation(dt);
            }

            if (player.role.controlComponent.canMove)
            {
                HandleMove(dt);
            }

            if (player.monoReference.rigidbody.velocity.y <= 0)
            {
                Debug.LogError("to Fall");
                if (m_Player.fsmComponent.stateMachine.currentState is PlayerFSMState_Battle stateBattle)
                {
                    stateBattle.SetBattleState(RoleBattleState.Air);
                }
                else if (m_Player.fsmComponent.stateMachine.currentState is PlayerFSMState_Relax stateRelax)
                {
                    stateRelax.SetRelaxState(RoleRelaxState.Air);
                }
            }
        }


        private void HandleRotation(float dt)
        {
            Vector3 targetDir = m_Player.controlComponent.movementInput;

            if (targetDir == Vector3.zero)
            {
                targetDir = m_Player.transform.forward;
            }

            float rotateSpeed = 10;
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(m_Player.transform.rotation, tr, rotateSpeed * dt);
            m_Player.transform.rotation = targetRotation;
        }

        private void HandleMove(float dt)
        {
            if (m_Player.role.controlComponent.usingMotion)
                return;

            //这里希望速度也能够配合动画进行缓动
            m_Player.monoReference.rigidbody.velocity = new Vector3(
                m_Player.controlComponent.movementVector.x,
                m_Player.monoReference.rigidbody.velocity.y,
                m_Player.controlComponent.movementVector.z);

        }
    }

}