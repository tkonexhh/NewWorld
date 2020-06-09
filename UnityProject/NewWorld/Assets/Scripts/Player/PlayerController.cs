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
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        public float idleTimeout = 5f;
        public CameraSettings cameraSettings;

        [SerializeField] private MovementSetting m_MovementSetting;

        protected CharacterController m_CharCtrl;
        protected PlayerInput m_Input;
        protected PlayerAnim m_Anim;


        protected float m_IdleTimer;
        protected float m_AngleDiff;

        private void Awake()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Anim = GetComponent<PlayerAnim>();
            m_CharCtrl = GetComponent<CharacterController>();
            cameraSettings = FindObjectOfType<CameraSettings>();
        }

        // private void OnAnimatorMove()
        // {
        //     Debug.LogError("OnAnimatorMove");
        // }
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
            TimeoutToIdle();
            SetTargetRotation();

            if (m_Input.IsMoveInput)
                UpdateOrientation();
        }



        float turnSmoothVelocity;
        void SetTargetRotation()
        {
            Vector2 moveInput = m_Input.MoveInput;
            //Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;

            if (moveInput.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + cameraSettings.camera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, m_MovementSetting.turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                //m_CharCtrl.SimpleMove(moveDirection.normalized * direction.magnitude * m_MovementSetting.moveSpeed * Time.deltaTime);

            }
            // if (moveInput.magnitude > 1f)
            // {
            //     if (!m_Input.Running)
            //         moveInput.Normalize();
            // }
            m_Anim.animator.SetFloat(PlayerAnim.HashForwardSpeed, Mathf.Sqrt(moveInput.x * moveInput.x + moveInput.y * moveInput.y));
        }

        void UpdateOrientation()
        {
            m_Anim.animator.SetFloat(PlayerAnim.HashAngleDeltaRadFloat, m_AngleDiff * Mathf.Deg2Rad);
        }


        void TimeoutToIdle()
        {
            bool input = m_Input.IsMoveInput && !m_Input.Crouch;
            if (!input)
            {
                m_IdleTimer += Time.fixedDeltaTime;
                if (m_IdleTimer >= idleTimeout)
                {
                    m_IdleTimer = 0;
                    m_Anim.animator.SetTrigger(PlayerAnim.HashTimeoutToIdle);
                }
            }
            else
            {
                m_IdleTimer = 0;
                m_Anim.animator.ResetTrigger(PlayerAnim.HashTimeoutToIdle);
            }
            m_Anim.animator.SetBool(PlayerAnim.HashInputDetectedBool, input);
        }


        void Damaged()
        {
            m_Anim.animator.SetTrigger(PlayerAnim.HashHurtTrigger);
            m_Anim.animator.SetFloat(PlayerAnim.HasHurtFormX, Random.Range(-1.0f, 1.0f));
            m_Anim.animator.SetFloat(PlayerAnim.HasHurtFormY, Random.Range(-1.0f, 1.0f));
        }

        void Died()
        {
            m_Anim.animator.SetTrigger(PlayerAnim.HashDeadTrigger);
            m_Anim.animator.SetFloat(PlayerAnim.HasHurtFormX, Random.Range(-1.0f, 1.0f));
            m_Anim.animator.SetFloat(PlayerAnim.HasHurtFormY, Random.Range(-1.0f, 1.0f));
        }

    }

}