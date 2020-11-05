/************************
	FileName:/Scripts/Game/Entity/Player/Component/PlayerControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:11/2/2020 4:25:33 PM
	Tip:11/2/2020 4:25:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class PlayerControlComponent : EntityComponennt
    {
        private Player player;

        private Vector3 m_ContractNormal;
        private float m_MinGroundDotProduct;//
        private int m_GroundContactCount;//接触的面的数量
        private bool onGround => m_GroundContactCount > 0;//是否在地面上
        private bool m_DesireJump = false;
        private Vector3 m_Velocity;//速度
        private Vector2 m_MoveDir;//移动方向
        private float m_MaxSpeed;//最大速度
        private float m_Acceleration;//加速度

        //捕捉
        //防止被很小的高度巅飞起来
        private float m_MaxSnapSpeed = 100f;
        private float m_MaxSnapDistance = 1;
        LayerMask groundMask = -1;
        int stepsSinceLastGrounded, stepsSinceLastJump;

        public Vector3 velocity
        {
            get => player.monoReference.rigidbody.velocity;
            set
            {
                player.monoReference.rigidbody.velocity = value;
            }
        }

        public Vector3 roleForward
        {
            get => player.role.transform.forward;
            set
            {
                player.role.transform.forward = value;
            }
        }


        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
            player.monoReference.onCollisionEnter += OnCollisionEnter;
            player.monoReference.onCollisionStay += OnCollisionStay;

            m_MinGroundDotProduct = Mathf.Cos(player.role.data.baseData.maxGroundAngle * Mathf.Deg2Rad);
        }

        public override void Excute(float dt)
        {
        }

        public override void FixedExcute(float dt)
        {
            UpdateState();
            CheckMove();
            CheckJump();
            this.velocity = m_Velocity;
            ClearState();
        }

        void UpdateState()
        {
            stepsSinceLastGrounded += 1;
            stepsSinceLastJump += 1;
            m_Velocity = this.velocity;
            if (onGround || SnapToGround())
            {
                stepsSinceLastGrounded = 0;
                if (m_GroundContactCount > 1)
                    m_ContractNormal.Normalize();
            }
            else
            {
                m_ContractNormal = Vector3.up;
            }
        }

        void ClearState()
        {
            m_GroundContactCount = 0;
            m_ContractNormal = Vector3.zero;
        }

        private void CheckMove()
        {
            Vector3 xAxis = ProjectOnContactPlane(Vector3.right).normalized;
            Vector3 zAxis = ProjectOnContactPlane(Vector3.forward).normalized;

            float currentX = Vector3.Dot(m_Velocity, xAxis);
            float currentz = Vector3.Dot(m_Velocity, zAxis);

            Vector3 desiredVelocity = new Vector3(m_MoveDir.x, 0, m_MoveDir.y) * m_MaxSpeed;
            //经过测试 如果加速度比较小的话，上坡会很慢，这里提供一个斜坡加速度支持
            float angle = Vector3.Dot(Vector3.up, m_ContractNormal);
            m_Acceleration *= (1 + (1 - angle) * player.role.data.baseData.clambAccelerationRate);

            // Debug.LogError(angle + "--" + acceleration);
            float maxSpeedChange = m_Acceleration * Time.fixedDeltaTime;

            float newX = Mathf.MoveTowards(m_Velocity.x, desiredVelocity.x, maxSpeedChange);
            float newZ = Mathf.MoveTowards(m_Velocity.z, desiredVelocity.z, maxSpeedChange);

            m_Velocity += xAxis * (newX - currentX) + zAxis * (newZ - currentz);
            player.role.animComponent.SetVelocityZ(this.velocity.magnitude);
        }



        private Vector3 ProjectOnContactPlane(Vector3 vector)
        {
            return vector - m_ContractNormal * Vector3.Dot(vector, m_ContractNormal);
        }

        private void CheckJump()
        {
            if (!m_DesireJump)
                return;
            m_DesireJump = false;

            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * player.role.data.baseData.jumpHeight);
            float alignedSpeed = Vector3.Dot(m_Velocity, m_ContractNormal);
            if (alignedSpeed > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - alignedSpeed, 0f);
            }
            // m_Velocity += m_ContractNormal * jumpSpeed;
            m_Velocity += Vector3.up * jumpSpeed;
        }


        public void Jump()
        {
            m_DesireJump = true;
        }

        public void Move(Vector2 moveDir, float speed, float acceleration)
        {
            m_MoveDir = moveDir;
            m_MaxSpeed = speed;
            m_Acceleration = acceleration;
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
                if (normal.y >= m_MinGroundDotProduct)
                {
                    m_GroundContactCount += 1;
                    m_ContractNormal += normal;
                }
            }
        }


        bool SnapToGround()
        {
            if (stepsSinceLastGrounded > 1 || stepsSinceLastJump <= 2)
            {
                return false;
            }
            float speed = velocity.magnitude;
            if (speed > m_MaxSnapSpeed)
            {
                return false;
            }

            if (!Physics.Raycast(player.monoReference.rigidbody.position, Vector3.down, out RaycastHit hit, m_MaxSnapDistance, groundMask))
            {
                return false;
            }

            if (hit.normal.y < m_MinGroundDotProduct)
            {
                return false;
            }

            m_GroundContactCount = 1;
            m_ContractNormal = hit.normal;

            float dot = Vector3.Dot(velocity, hit.normal);
            if (dot > 0)
                velocity = (velocity - hit.normal * dot).normalized * speed;
            return true;
        }

    }

}