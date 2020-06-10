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

        public bool Running;
        public bool Jump;
        //public bool Crouch;

        private const KeyCode Input_Crouch = KeyCode.LeftControl;
        private const KeyCode Input_Run = KeyCode.LeftShift;

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
            Running = Input.GetKey(Input_Run);
            Jump = m_InputSetting.jump;

            m_Movement.Set(m_InputSetting.Horizontal, m_InputSetting.Vertical);
            m_Movement = SquareToCircle(m_Movement);

            // if (m_Movement.magnitude <= 0.1f && Input.GetKeyDown(Input_Crouch))//确保只有在几乎静止的时候才能切换
            // {
            //     Crouch = !Crouch;
            // }
        }

        private Vector2 SquareToCircle(Vector2 input)
        {
            Vector2 output = Vector2.zero;
            output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2);
            output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2);
            return output;
        }

    }

}