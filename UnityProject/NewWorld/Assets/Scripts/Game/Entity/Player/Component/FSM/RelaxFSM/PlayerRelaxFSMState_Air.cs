/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/3/2020 7:26:03 PM
	Tip:11/3/2020 7:26:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Air : FSMState<Player>
    {
        private Player m_Player;
        private int m_JumpChance = 0;
        private Vector3 m_MoveVelocity;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            m_JumpChance = 0;
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
            player.monoReference.onCollisionEnter += OnCollisionEnter;
            player.monoReference.onCollisionStay += OnCollisionStay;
        }

        public override void Update(Player player, float dt)
        {
            // if (player.role.animComponent == null)
            //     return;
        }

        public override void FixedUpdate(Player player, float dt)
        {
            float maxSpeed = player.role.data.baseData.runSpeed;//: player.role.data.baseData.walkSpeed;
            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            m_MoveVelocity = player.controlComponent.velocity;
            float maxSpeedChange = player.role.data.baseData.airAcceleration * dt;
            m_MoveVelocity.x = Mathf.MoveTowards(m_MoveVelocity.x, desiredVelocity.x, maxSpeedChange);
            m_MoveVelocity.z = Mathf.MoveTowards(m_MoveVelocity.z, desiredVelocity.z, maxSpeedChange);
            // Debug.LogError(GameInputMgr.S.moveVec + "----" + m_MoveVelocity + "---" + maxSpeedChange + "----" + desiredVelocity);
            player.controlComponent.velocity = m_MoveVelocity;
            //去除掉Y轴速度带来的影响
            player.role.animComponent.SetVelocityZ(player.controlComponent.velocity.magnitude);
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Jump.performed -= OnJumpPerformed;
            player.monoReference.onCollisionEnter -= OnCollisionEnter;
            player.monoReference.onCollisionStay -= OnCollisionStay;
        }

        public override void OnMsg(Player role, int key, params object[] args)
        {

        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            Jump();
        }

        private void Jump()
        {
            if (m_JumpChance < m_Player.role.data.baseData.jumpCount - 1)
            {
                Debug.LogError("Jump");
                m_JumpChance += 1;
                float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * m_Player.role.data.baseData.jumpHeight);
                if (m_Player.controlComponent.velocity.y > 0f)
                {
                    jumpSpeed = Mathf.Max(jumpSpeed - m_Player.controlComponent.velocity.y, 0f);
                }
                m_Player.controlComponent.velocity += new Vector3(0, jumpSpeed, 0);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            EvaluateCollision(other);
        }

        private void OnCollisionStay(Collision other)
        {
            EvaluateCollision(other);
        }

        private void EvaluateCollision(Collision collision)
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                Vector3 normal = collision.GetContact(i).normal;
                if (normal.y >= 0.9f)
                {
                    // Debug.LogError("OnGround");
                    (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
                }
            }
        }
    }

}