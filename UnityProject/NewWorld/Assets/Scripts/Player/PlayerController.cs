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
        }

        private void FixedUpdate()
        {
            TimeoutToIdle();
            SetUpAnim();
            CalcForwardMovement();

        }

        void CalcForwardMovement()
        {
            Vector2 moveInput = m_Input.MoveInput;
            m_Anim.animator.SetFloat(PlayerAnim.HashForwardSpeed, moveInput.magnitude);
        }
        void SetUpAnim()
        {
            m_Anim.animator.SetBool(PlayerAnim.HashCrouchBool, m_Input.Crouch);
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
            m_Anim.animator.SetFloat(PlayerAnim.HasHurtFormX, Random.Range(0, 1.0f));
            m_Anim.animator.SetFloat(PlayerAnim.HasHurtFormY, Random.Range(0, 1.0f));
        }

    }

}