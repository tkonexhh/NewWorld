/************************
	FileName:/0TempRes/Test/RoleTest/MovingSphere.cs
	CreateAuthor:neo.xu
	CreateTime:11/3/2020 10:59:50 AM
	Tip:11/3/2020 10:59:50 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class MovingSphere : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)] private float maxSpeed = 10f;
        [SerializeField, Range(0, 100f)] private float maxAcceleration = 10f, maxAirAcceleration = 1f;
        [SerializeField, Range(0, 10f)] private float jumpHeight = 2f;
        [SerializeField, Range(0, 5)] private int maxAirJumps = 0;
        private Rigidbody body;

        private Vector3 velocity;

        bool desiredJump = false;
        bool onGround;
        int jumpPhase;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
            // GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            desiredJump |= true;
        }

        // private void Update()
        // {
        //     desiredJump |= Input.GetButtonDown("Jump");
        // }

        private void FixedUpdate()
        {
            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            UpdateState();
            float acceleration = onGround ? maxAcceleration : maxAirAcceleration;
            float maxSpeedChange = acceleration * Time.fixedDeltaTime;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

            if (desiredJump)
            {
                desiredJump = false;
                Jump();
            }
            body.velocity = velocity;
            onGround = false;
        }


        void Jump()
        {
            if (onGround || jumpPhase < maxAirJumps)
            {
                Debug.LogError("Jump");
                jumpPhase += 1;
                float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
                if (velocity.y > 0f)
                {
                    // jumpSpeed = jumpSpeed - velocity.y;
                    jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
                }
                velocity.y += jumpSpeed;
            }
        }

        private void UpdateState()
        {
            velocity = body.velocity;
            if (onGround)
            {
                jumpPhase = 0;
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
                onGround |= normal.y >= 0.9f;
            }
        }
    }

}