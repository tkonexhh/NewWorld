/************************
	FileName:/Scripts/Player/InputSetting.cs
	CreateAuthor:neo.xu
	CreateTime:6/8/2020 2:41:48 PM
	Tip:6/8/2020 2:41:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    [System.Serializable]
    public class InputSetting
    {
        public float Horizontal;
        public float Vertical;
        public float mouseX;
        public float mouseY;
        public bool jump;
        public bool crouch;

        private const string Input_Horizontal = "Horizontal";
        private const string Input_Vertical = "Vertical";
        private const string Input_MouseX = "Mouse X";
        private const string Input_MouseY = "Mouse Y";
        private const KeyCode Input_Crouch = KeyCode.LeftControl;
        private const KeyCode Input_Run = KeyCode.LeftShift;
        public void GetInput()
        {
            Horizontal = Input.GetAxis(Input_Horizontal);
            Vertical = Input.GetAxis(Input_Vertical);

            if (Input.GetKey(Input_Run))
            {
                if (Horizontal != 0)
                {
                    if (Horizontal > 0)
                        Horizontal += 0.5f;
                    else
                        Horizontal -= 0.5f;
                }

                if (Vertical != 0)
                {
                    if (Vertical > 0)
                        Vertical += 0.5f;
                    else
                        Vertical -= 0.5f;
                }
            }

            mouseX = Input.GetAxis(Input_MouseX);
            mouseY = Input.GetAxis(Input_MouseY);

            float horizontal = Horizontal;
            float vertical = Vertical;
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude < 0.1f && Input.GetKeyDown(Input_Crouch))//确保只有在几乎静止的时候才能切换
            {
                crouch = !crouch;
            }
        }


    }

}