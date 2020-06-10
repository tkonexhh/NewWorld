/************************
	FileName:/Scripts/Player/PlayerController.cs
	CreateAuthor:neo.xu
	CreateTime:6/9/2020 11:16:48 AM
	Tip:6/9/2020 11:16:48 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerController : MonoBehaviour
    {
        public float gravity = 20f;
        [SerializeField] private Transform m_CameraLookAt;
        [SerializeField] private MovementSetting m_MovementSetting;


        protected CameraSettings cameraSettings;
        protected CharacterController m_CharCtrl;
        protected PlayerInput m_Input;
        protected Character m_Character;

        protected float m_VerticalSpeed;
        protected float m_IdleTimer;
        protected float m_AngleDiff;
        protected bool m_IsGrounded = true;
        protected bool m_ReadyToJump = true;

        private void Awake()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Character = GetComponentInChildren<Character>();
            m_CharCtrl = GetComponent<CharacterController>();
            cameraSettings = FindObjectOfType<CameraSettings>();
            cameraSettings.follow = m_CameraLookAt;
            cameraSettings.lookAt = m_CameraLookAt;
        }


        private void OnAnimatorMove()
        {
            Debug.LogError("OnAnimatorMove");

            if (m_IsGrounded)
            {
                RaycastHit hit;
                Ray ray = new Ray(transform.position + Vector3.up * 1 * 0.5f, -Vector3.up);
                if (Physics.Raycast(ray, out hit, 1, Physics.AllLayers, QueryTriggerInteraction.Ignore))
                {

                }
            }
            else
            {

            }

            Vector2 moveInput = m_Input.MoveInput;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Damaged();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                Died();
            }
        }

        private void FixedUpdate()
        {
            m_IsGrounded = m_CharCtrl.isGrounded;
            TimeoutToIdle();
            CalcVertcalMovement();
            SetTargetRotation();



            // if (m_Input.IsMoveInput)
            //     UpdateOrientation();
        }

        /// <summary>
        /// 计算垂直方向的速度（跳跃）
        /// </summary>
        void CalcVertcalMovement()
        {


            if (!m_Input.Jump && m_IsGrounded)
            {
                m_ReadyToJump = true;
            }

            if (m_IsGrounded)
            {
                m_VerticalSpeed = -gravity * 0.3f;
                if (m_Input.Jump && m_ReadyToJump)
                {
                    //Debug.LogError("Jump");
                    m_VerticalSpeed = m_MovementSetting.jumpSpeed;
                    m_IsGrounded = false;
                    m_ReadyToJump = false;
                }
            }
            else
            {
                if (!m_Input.Jump && m_VerticalSpeed > 0)
                {
                    m_VerticalSpeed -= 10 * Time.deltaTime;
                }

                if (Mathf.Approximately(m_VerticalSpeed, 0))
                {
                    m_VerticalSpeed = 0;
                }

                m_VerticalSpeed -= gravity * Time.deltaTime;
            }

            if (!m_IsGrounded)
            {
                m_Character.animator.SetFloat(CharacterAnim.HashVerticalSpeed, m_VerticalSpeed);
            }

            //Debug.LogError("m_IsGrounded:" + m_IsGrounded);
            m_Character.animator.SetBool(CharacterAnim.HashGroundedBool, m_IsGrounded);

        }

        void SetTargetRotation()
        {
            Vector2 moveInput = m_Input.MoveInput;
            Vector3 movement;
            m_Character.transform.forward = Vector3.Slerp(m_Character.transform.forward, moveInput.x * transform.right + moveInput.y * transform.forward, m_MovementSetting.turnSmoothTime);
            movement = m_Character.transform.forward * moveInput.magnitude * m_MovementSetting.moveSpeed * (m_Input.Running ? 1.7f : 1) * Time.fixedDeltaTime;

            if (!m_IsGrounded)
            {
                //Debug.LogError("pos:" + m_VerticalSpeed);
                movement += 10000000 * Vector3.up;
                Debug.LogError(movement);
            }
            if (moveInput.magnitude > 0.1f)
            {
                //m_Character.transform.forward = Vector3.Slerp(m_Character.transform.forward, moveInput.x * transform.right + moveInput.y * transform.forward, m_MovementSetting.turnSmoothTime);
                //m_CharCtrl.SimpleMove(m_Character.transform.forward * moveInput.magnitude * m_MovementSetting.moveSpeed * (m_Input.Running ? 1.7f : 1) * Time.fixedDeltaTime);
                m_CharCtrl.SimpleMove(movement);
            }

            float lerpSpeed = Mathf.Lerp(m_Character.animator.GetFloat(CharacterAnim.HashForwardSpeed), (m_Input.Running ? 2 : 1), 0.3f);
            m_Character.animator.SetFloat(CharacterAnim.HashForwardSpeed, moveInput.magnitude * lerpSpeed);
        }

        void UpdateOrientation()
        {
            m_Character.animator.SetFloat(CharacterAnim.HashAngleDeltaRadFloat, m_AngleDiff * Mathf.Deg2Rad);
        }


        void TimeoutToIdle()
        {
            bool input = m_Input.IsMoveInput || m_Input.Jump;
            if (!input)
            {
                m_IdleTimer += Time.fixedDeltaTime;
                if (m_IdleTimer >= m_Character.characterAnim.animationSetting.idleTimeout)
                {
                    m_IdleTimer = 0;
                    m_Character.animator.SetTrigger(CharacterAnim.HashTimeoutToIdle);
                }
            }
            else
            {
                m_IdleTimer = 0;
                m_Character.animator.ResetTrigger(CharacterAnim.HashTimeoutToIdle);
            }
            m_Character.animator.SetBool(CharacterAnim.HashInputDetectedBool, input);
        }


        void Damaged()
        {
            m_Character.animator.SetTrigger(CharacterAnim.HashHurtTrigger);
            m_Character.animator.SetFloat(CharacterAnim.HasHurtFormX, Random.Range(-1.0f, 1.0f));
            m_Character.animator.SetFloat(CharacterAnim.HasHurtFormY, Random.Range(-1.0f, 1.0f));
        }

        void Died()
        {
            m_Character.animator.SetTrigger(CharacterAnim.HashDeadTrigger);
            m_Character.animator.SetFloat(CharacterAnim.HasHurtFormX, Random.Range(-1.0f, 1.0f));
            m_Character.animator.SetFloat(CharacterAnim.HasHurtFormY, Random.Range(-1.0f, 1.0f));
        }

    }

}