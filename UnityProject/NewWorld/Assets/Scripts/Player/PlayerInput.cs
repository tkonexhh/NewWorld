/************************
	FileName:/Scripts/Player/PlayerInput.cs
	CreateAuthor:neo.xu
	CreateTime:6/9/2020 11:28:47 AM
	Tip:6/9/2020 11:28:47 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputSetting m_InputSetting;

        [HideInInspector] public bool playerInputBlocked;

        private Vector2 m_Movement;
        private float horizontal;
        private float vertical;

        public bool jump;
        public bool Crouch;

        private const KeyCode Input_Crouch = KeyCode.LeftControl;
        private const KeyCode Input_Run = KeyCode.LeftShift;

        private float m_HorizontalVelocity;
        private float m_VerticalVelocity;
        private float m_InputSmoothTime = 0.05f;

        public bool IsMoveInput
        {
            get { return !Mathf.Approximately(MoveInput.sqrMagnitude, 0f); }
        }

        public Vector2 MoveInput
        {
            get
            {
                if (playerInputBlocked)
                {
                    return Vector2.zero;
                }

                return m_Movement;
            }
        }


        private void Update()
        {
            m_InputSetting.GetInput();

            if (Input.GetKey(Input_Run))
            {
                if (m_InputSetting.Horizontal != 0)
                {
                    if (m_InputSetting.Horizontal > 0)
                    {
                        m_InputSetting.Horizontal += 0.5f;
                    }
                    else
                    {

                        m_InputSetting.Horizontal -= 0.5f;
                    }

                }

                if (m_InputSetting.Vertical != 0)
                {
                    if (m_InputSetting.Vertical > 0)
                    {
                        m_InputSetting.Vertical += 0.5f;
                    }
                    else
                    {
                        m_InputSetting.Vertical -= 0.5f;
                    }

                }
            }

            horizontal = Mathf.SmoothDamp(horizontal, m_InputSetting.Horizontal, ref m_HorizontalVelocity, m_InputSmoothTime);
            vertical = Mathf.SmoothDamp(vertical, m_InputSetting.Vertical, ref m_VerticalVelocity, m_InputSmoothTime);

            m_Movement.Set(horizontal, vertical);

            if (m_Movement.magnitude <= 0.1f && Input.GetKeyDown(Input_Crouch))//确保只有在几乎静止的时候才能切换
            {
                Crouch = !Crouch;
            }
        }

    }

}