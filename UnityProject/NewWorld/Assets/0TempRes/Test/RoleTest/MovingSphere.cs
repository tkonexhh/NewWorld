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
        [SerializeField, Range(0, 100f)] private float maxAcceleration = 10f;
        [SerializeField, Range(0, 10f)] private float jumpHeight = 2f;
        private Rigidbody body;

        private Vector3 velocity;

        bool desiredJump = false;
        bool onGround;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            desiredJump |= Input.GetButtonDown("Jump");
        }

        private void FixedUpdate()
        {
            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            velocity = body.velocity;
            float maxSpeedChange = maxAcceleration * Time.fixedDeltaTime;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);


            if (desiredJump)
            {
                desiredJump = false;
                Jump();
            }
            body.velocity = velocity;
        }


        void Jump()
        {
            if (onGround)
            {
                velocity.y += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            onGround = true;
        }

        private void OnCollisionExit(Collision other)
        {
            onGround = false;
        }
    }

}