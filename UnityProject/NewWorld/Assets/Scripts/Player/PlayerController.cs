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
        }

        // void CalcForwardMovement()
        // {
        //     Vector2 moveInput = m_Input.MoveInput;
        //     if (moveInput.sqrMagnitude > 1f)
        //     {
        //         moveInput.Normalize();
        //     }

        //     float m_DesiredForwardSpeed = moveInput.magnitude * m_MovementSetting.moveSpeed;
        //     // Mathf.MoveTowards()
        //     m_Anim.animator.SetFloat(PlayerAnim.HashForwardSpeed, moveInput.magnitude);
        // }

        // void CalcVerticalMovement()
        // {

        // }

        float turnSmoothVelocity;
        void SetTargetRotation()
        {
            Vector2 moveInput = m_Input.MoveInput;

            Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;

            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraSettings.camera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, m_MovementSetting.turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                m_CharCtrl.SimpleMove(moveDirection.normalized * direction.magnitude * m_MovementSetting.moveSpeed * Time.deltaTime);

            }

            m_Anim.animator.SetFloat(PlayerAnim.HashForwardSpeed, moveInput.magnitude);
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