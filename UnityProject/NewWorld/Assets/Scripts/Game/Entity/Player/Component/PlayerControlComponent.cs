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
            private set
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
        }

        public void SetForward(Vector3 forward)
        {
            this.roleForward = forward;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSpeed">最大速度</param>
        /// <param name="acceleration">加速度</param>
        /// <param name="dt">dt</param>
        public void Move(float maxSpeed, float acceleration, float dt)
        {
            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            Vector3 velocity = this.velocity;
            float maxSpeedChange = player.role.data.baseData.acceleration * dt;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
            // Debug.LogError(GameInputMgr.S.moveVec + "----" + m_MoveVelocity + "---" + maxSpeedChange + "----" + desiredVelocity);
            this.velocity = velocity;
            //去除掉Y轴速度带来的影响
            player.role.animComponent.SetVelocityZ(this.velocity.magnitude);
        }

        void UpdateState()
        {
            velocity = this.velocity;
            if (onGround)
            {
                // jumpPhase = 0;
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

        void AdjustVelocity(float maxSpeed, float acceleration)
        {
            Vector3 xAxis = ProjectOnContactPlane(Vector3.right).normalized;
            Vector3 zAxis = ProjectOnContactPlane(Vector3.forward).normalized;

            float currentX = Vector3.Dot(velocity, xAxis);
            float currentz = Vector3.Dot(velocity, zAxis);

            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            float maxSpeedChange = acceleration * Time.fixedDeltaTime;
            float newX = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            float newZ = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

            velocity += xAxis * (newX - currentX) + zAxis * (newZ - currentz);
        }

        private Vector3 ProjectOnContactPlane(Vector3 vector)
        {
            return vector - m_ContractNormal * Vector3.Dot(vector, m_ContractNormal);
        }

        public void Jump()
        {
            Debug.LogError("Jump");
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * player.role.data.baseData.jumpHeight);
            if (this.velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - this.velocity.y, 0f);
            }
            this.velocity += new Vector3(0, jumpSpeed, 0);
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

    }

}