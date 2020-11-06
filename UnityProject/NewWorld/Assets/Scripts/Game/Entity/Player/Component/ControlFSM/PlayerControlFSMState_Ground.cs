/************************
	FileName:/Scripts/Game/Entity/Player/Component/ControlFSM/PlayerControlFSMState_Ground.cs
	CreateAuthor:neo.xu
	CreateTime:11/6/2020 3:48:50 PM
	Tip:11/6/2020 3:48:50 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.Logic
{
    public class PlayerControlFSMState_Ground : PlayerControlFSMBaseState
    {
        private float maxSpeed;//最大速度
        private float maxAcceleration;//最大加速度
        private float jumpHeight;
        private Vector3 m_Velocity;//速度
        float minGroundDotProduct;//
        private int groundContactCount;
        Vector3 contractNormal;

        bool canJump = true;


        private int stepsSinceLastGrounded;//腾空帧数
        private int stepsSinceLastJump;
        private float maxSnapSpeed = 100f;
        private float maxSnapDistance = 0.3f;
        private float maxGroundDistance = 0.7f;

        public override void Init(Player entity)
        {
            base.Init(entity);
            maxSpeed = entity.role.data.baseData.walkSpeed;
            maxAcceleration = entity.role.data.baseData.acceleration;
            jumpHeight = entity.role.data.baseData.jumpHeight;

            //最大地面角度
            float maxGroundAngle = entity.role.data.baseData.maxGroundAngle;
            minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
        }

        public override void Enter(Player entity, params object[] args)
        {
            base.Enter(entity, args);

            entity.monoReference.onCollisionEnter += OnCollisionEnter;
            entity.monoReference.onCollisionStay += OnCollisionStay;

            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
        }

        public override void Update(Player entity, float dt)
        {

        }

        public override void FixedUpdate(Player entity, float dt)
        {
            UpdateState();
            AdjustVelocity(maxSpeed, maxAcceleration, contractNormal, ref m_Velocity);
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

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            Jump();
        }

        private void UpdateState()
        {
            stepsSinceLastGrounded += 1;
            stepsSinceLastJump += 1;
            m_Velocity = player.controlComponent.velocity;

            if (groundContactCount > 0 || SnapToGround())
            {
                stepsSinceLastGrounded = 0;
                if (stepsSinceLastJump > 2)
                    canJump = true;
                if (groundContactCount > 1)
                {
                    contractNormal.Normalize();
                }
            }
            else
            {
                contractNormal = Vector3.up;
            }
        }

        void ClearState()
        {
            groundContactCount = 0;
            contractNormal = Vector3.zero;

            // steepContactCount = 0;
            // steepNormal = Vector3.zero;
        }

        void CheckState()
        {
            //向下打射线检测地表距离
            // Debug.DrawLine(target.transform.position, target.transform.position + Vector3.down * maxGroundDistance, Color.red);
            if (!Physics.Raycast(player.controlComponent.position, Vector3.down, out RaycastHit hit, maxGroundDistance, 1 << groundMask))
            {
                // Debug.LogError("Not Ground");
                player.controlComponent.SetControlState(ControlState.Air);
            }
        }

        private void Jump()
        {
            if (!canJump)
                return;

            canJump = false;
            stepsSinceLastJump = 0;

            Vector3 jumpDirection = Vector3.up;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            float alignedSpeed = Vector3.Dot(m_Velocity, jumpDirection);
            if (alignedSpeed > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - alignedSpeed, 0f);
            }
            player.controlComponent.velocity += jumpDirection * jumpSpeed;
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
                if (normal.y >= minGroundDotProduct)
                {
                    groundContactCount += 1;
                    contractNormal += normal;
                }
            }
        }

        //处理很小的坡 将物体巅起的问题
        bool SnapToGround()
        {
            if (stepsSinceLastGrounded > 1 || stepsSinceLastJump <= 2)
            {
                return false;
            }
            float speed = m_Velocity.magnitude;
            if (speed > maxSnapSpeed)
            {
                return false;
            }

            if (!Physics.Raycast(player.controlComponent.position, Vector3.down, out RaycastHit hit, maxSnapDistance, groundMask))
            {
                Debug.LogError("Dont need Snap");
                return false;
            }

            if (hit.normal.y < minGroundDotProduct)
            {
                return false;
            }

            groundContactCount = 1;
            contractNormal = hit.normal;

            float dot = Vector3.Dot(m_Velocity, hit.normal);
            if (dot > 0)
                m_Velocity = (m_Velocity - hit.normal * dot).normalized * speed;
            return true;
        }
    }

}