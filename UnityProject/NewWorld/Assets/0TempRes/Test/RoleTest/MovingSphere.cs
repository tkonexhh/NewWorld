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
        [SerializeField, Range(0, 90)] private float maxGroundAngle = 25f, maxStairAngle = 50f;
        [SerializeField, Range(0f, 100f)] private float maxSnapSpeed = 100f;//最大捕捉速度
        [SerializeField, Min(0f)] private float maxSnapDistance = 1f;//最大捕捉距离
        [SerializeField] LayerMask groundMask = -1, stairsMask = -1;
        private Rigidbody body;

        private Vector3 velocity;

        bool desiredJump = false;
        bool onGround => groundContactCount > 0;
        int groundContactCount;
        int jumpPhase;
        float minGroundDotProduct, minStairsDotProduct;
        Vector3 contractNormal;

        //Steep
        Vector3 steepNormal;
        int steepContactCount;
        bool OnSteep => steepContactCount > 0;


        //S3
        int stepsSinceLastGrounded, stepsSinceLastJump;

        private void Awake()
        {
            minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
            minStairsDotProduct = Mathf.Cos(maxStairAngle * Mathf.Deg2Rad);
            body = GetComponent<Rigidbody>();
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            desiredJump |= true;
        }

        private void Update()
        {
            // GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white * (groundContactCount * 0.25f));
            GetComponent<Renderer>().material.SetColor("_BaseColor", onGround ? Color.black : Color.white);
        }

        private void FixedUpdate()
        {
            UpdateState();
            AdjustVelocity();

            if (desiredJump)
            {
                desiredJump = false;
                Jump();
            }
            body.velocity = velocity;
            ClearState();
        }

        private void UpdateState()
        {
            stepsSinceLastGrounded += 1;
            stepsSinceLastJump += 1;
            velocity = body.velocity;
            if (onGround || SnapToGround() || CheckSteepContacts())
            {
                stepsSinceLastGrounded = 0;
                if (stepsSinceLastJump > 1)
                {
                    jumpPhase = 0;
                }
                if (groundContactCount > 1)
                    contractNormal.Normalize();
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

            steepContactCount = 0;
            steepNormal = Vector3.zero;
        }

        private Vector3 ProjectOnContactPlane(Vector3 vector)
        {
            return vector - contractNormal * Vector3.Dot(vector, contractNormal);
        }
        void AdjustVelocity()
        {
            Vector3 xAxis = ProjectOnContactPlane(Vector3.right).normalized;
            Vector3 zAxis = ProjectOnContactPlane(Vector3.forward).normalized;

            float currentX = Vector3.Dot(velocity, xAxis);
            float currentz = Vector3.Dot(velocity, zAxis);

            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * maxSpeed;
            float acceleration = onGround ? maxAcceleration : maxAirAcceleration;
            float maxSpeedChange = acceleration * Time.fixedDeltaTime;
            float newX = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            float newZ = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

            velocity += xAxis * (newX - currentX) + zAxis * (newZ - currentz);
        }


        void Jump()
        {
            Vector3 jumpDirection;
            if (onGround)
            {
                jumpDirection = contractNormal;
            }
            else if (OnSteep)
            {
                jumpDirection = steepNormal;
                jumpPhase = 0;
            }
            else if (maxAirJumps > 0 && jumpPhase <= maxAirJumps)
            {
                if (jumpPhase == 0)
                {
                    jumpPhase = 1;
                }
                jumpDirection = contractNormal;
            }
            else
            {
                return;
            }

            // if (onGround || jumpPhase < maxAirJumps)
            {
                Debug.LogError("Jump");
                stepsSinceLastJump = 0;
                jumpPhase += 1;
                float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
                float alignedSpeed = Vector3.Dot(velocity, jumpDirection);
                if (alignedSpeed > 0f)
                {
                    jumpSpeed = Mathf.Max(jumpSpeed - alignedSpeed, 0f);
                }
                velocity += jumpDirection * jumpSpeed;
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
            float minDot = GetMinDot(collision.gameObject.layer);
            for (int i = 0; i < collision.contactCount; i++)
            {
                Vector3 normal = collision.GetContact(i).normal;
                if (normal.y >= minDot)
                {
                    groundContactCount += 1;
                    contractNormal += normal;
                }
                else if (normal.y > -0.01f)
                {
                    steepContactCount += 1;
                    steepNormal += normal;
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
            if (speed > maxSnapSpeed)
            {
                return false;
            }

            if (!Physics.Raycast(body.position, Vector3.down, out RaycastHit hit, maxSnapDistance, groundMask))
            {
                return false;
            }

            if (hit.normal.y < GetMinDot(hit.collider.gameObject.layer))
            {
                return false;
            }

            groundContactCount = 1;
            contractNormal = hit.normal;

            float dot = Vector3.Dot(velocity, hit.normal);
            if (dot > 0)
                velocity = (velocity - hit.normal * dot).normalized * speed;
            return true;
        }

        float GetMinDot(int layer)
        {
            return (stairsMask & (1 << layer)) == 0 ? minGroundDotProduct : minStairsDotProduct;
        }

        bool CheckSteepContacts()
        {
            if (steepContactCount > 1)
            {
                steepNormal.Normalize();
                if (steepNormal.y >= minGroundDotProduct)
                {
                    groundContactCount = 1;
                    contractNormal = steepNormal;
                    return true;
                }
            }

            return false;
        }
    }

}