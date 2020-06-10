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

        private const string Input_Horizontal = "Horizontal";
        private const string Input_Vertical = "Vertical";
        private const string Input_MouseX = "Mouse X";
        private const string Input_MouseY = "Mouse Y";
        private const string Input_Jump = "Jump";

        public void GetInput()
        {
            Horizontal = Input.GetAxis(Input_Horizontal);
            Vertical = Input.GetAxis(Input_Vertical);

            mouseX = Input.GetAxis(Input_MouseX);
            mouseY = Input.GetAxis(Input_MouseY);

            jump = Input.GetButton(Input_Jump);
        }


    }

}