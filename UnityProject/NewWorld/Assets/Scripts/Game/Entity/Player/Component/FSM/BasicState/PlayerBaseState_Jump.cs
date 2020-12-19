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
        protected Vector3 m_MoveDir;


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
            Vector3 targetDir = Vector3.zero;
            float moveOverride = GameInputMgr.S.moveAmount;

            targetDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            targetDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            targetDir.Normalize();

            targetDir.y = 0;


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

            m_MoveDir = Vector3.zero;
            m_MoveDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            m_MoveDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            m_MoveDir.Normalize();
            m_MoveDir.y = 0;

            float speed = m_Player.role.controlComponent.running ? m_Player.role.data.baseData.runSpeed : m_Player.role.data.baseData.walkSpeed;
            m_MoveDir *= speed;

            float remapSpeed = 1;
            if (m_Player.role.controlComponent.running)
            {
                remapSpeed = m_Player.role.animComponent.GetVelocityZ().Remap(3, 6, 0, 1);
            }
            else
            {
                remapSpeed = m_Player.role.animComponent.GetVelocityZ().Remap(0, 3, 0, 1);
            }

            //这里希望速度也能够配合动画进行缓动
            m_Player.monoReference.rigidbody.velocity = new Vector3(m_MoveDir.x * remapSpeed, m_Player.monoReference.rigidbody.velocity.y, m_MoveDir.z * remapSpeed);

        }
    }

}