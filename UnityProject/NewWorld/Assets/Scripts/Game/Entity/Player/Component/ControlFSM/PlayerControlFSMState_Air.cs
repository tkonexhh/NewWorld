/************************
	FileName:/Scripts/Game/Entity/Player/Component/ControlFSM/PlayerControlFSMState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/6/2020 3:49:11 PM
	Tip:11/6/2020 3:49:11 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerControlFSMState_Air : PlayerControlFSMBaseState
    {
        private float maxSpeed;//最大速度
        private float maxAcceleration;//最大加速度
        private int maxJumpChance;
        private float jumpHeight;

        private Vector3 m_Velocity;//速度
        private int m_JumpChance;

        private float m_ColliderHeight;
        #region 墙跳
        private int steepContactCount;
        private Vector3 steepNormal;
        bool OnSteep => steepContactCount > 0;
        #endregion

        public override void Init(Player entity)
        {
            base.Init(entity);
            maxSpeed = entity.role.data.baseData.walkSpeed;
            maxAcceleration = entity.role.data.baseData.airAcceleration;
            maxJumpChance = entity.role.data.baseData.jumpCount;
            jumpHeight = entity.role.data.baseData.jumpHeight;

            m_ColliderHeight = entity.monoReference.rigidbodyCollider.height / 2;
        }

        public override void Enter(Player entity, params object[] args)
        {
            base.Enter(entity, args);
            m_JumpChance = 0;
            entity.monoReference.onCollisionEnter += OnCollisionEnter;
            entity.monoReference.onCollisionStay += OnCollisionStay;
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
        }

        public override void Update(Player entity, float dt)
        {

        }

        public override void FixedUpdate(Player entity, float dt)
        {
            Debug.LogError("Air");
            UpdateState();
            AdjustVelocity(maxSpeed, maxAcceleration, Vector3.up, ref m_Velocity);
            entity.controlComponent.velocity = m_Velocity;
            ClearState();
            CheckState();
        }

        public override void Exit(Player entity)
        {
            entity.monoReference.onCollisionEnter -= OnCollisionEnter;
            entity.monoReference.onCollisionStay -= OnCollisionStay;
            GameInputMgr.S.mainAction.Jump.performed -= OnJumpPerformed;
        }

        private void UpdateState()
        {
            m_Velocity = player.controlComponent.velocity;
        }

        private void ClearState()
        {
            steepContactCount = 0;
            steepNormal = Vector3.zero;
        }

        void CheckState()
        {
            //向下打射线检测地表距离
            if (Physics.Raycast(player.controlComponent.position, Vector3.down, out RaycastHit hit, m_ColliderHeight + 0.3f, 1 << groundMask))
            {
                player.controlComponent.SetControlState(ControlState.Ground);
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
                if (normal.y > -0.01f)
                {
                    steepContactCount += 1;
                    steepNormal += normal;
                }
            }
        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            Jump();
        }

        private void Jump()
        {
            if (m_JumpChance >= maxJumpChance)
                return;

            Vector3 jumpDirection = Vector3.up;
            if (OnSteep)
            {
                // Debug.LogError("OnSteep");
                jumpDirection = (steepNormal + Vector3.up).normalized;
                m_JumpChance = 0;
            }

            m_JumpChance++;

            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            float alignedSpeed = Vector3.Dot(m_Velocity, jumpDirection);
            if (alignedSpeed > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - alignedSpeed, 0f);
            }
            player.controlComponent.velocity += jumpDirection * jumpSpeed;
        }
    }

}