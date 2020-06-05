/************************
	FileName:/Scripts/InputMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/5/2020 5:33:47 PM
	Tip:6/5/2020 5:33:47 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class InputMgr : TMonoSingleton<InputMgr>
    {
        private const string Input_Horizontal = "Horizontal";
        private const string Input_Vertical = "Vertical";

        public float horizontalAxis = 0;
        public float vertacalAxis = 0;

        void Update()
        {
            horizontalAxis = Input.GetAxisRaw(Input_Horizontal);
            vertacalAxis = Input.GetAxisRaw(Input_Vertical);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (horizontalAxis != 0) horizontalAxis += 0.5f;
                if (vertacalAxis != 0) vertacalAxis += 0.5f;
            }
        }
    }

}