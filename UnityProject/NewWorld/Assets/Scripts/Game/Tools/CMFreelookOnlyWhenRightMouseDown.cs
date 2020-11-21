/************************
	FileName:/Scripts/Game/Tools/CMFreelookOnlyWhenRightMouseDown.cs
	CreateAuthor:neo.xu
	CreateTime:11/21/2020 1:54:46 PM
	Tip:11/21/2020 1:54:46 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace Game.Logic
{
    public class CMFreelookOnlyWhenRightMouseDown : MonoBehaviour
    {
        void Start()
        {
            CinemachineCore.GetInputAxis = GetAxisCustom;
        }
        public float GetAxisCustom(string axisName)
        {
            if (axisName == "Mouse X")
            {
                if (Input.GetMouseButton(1))
                {
                    return -UnityEngine.Input.GetAxis("Mouse X");
                }
                else
                {
                    return 0;
                }
            }
            else if (axisName == "Mouse Y")
            {
                if (Input.GetMouseButton(1))
                {
                    return -UnityEngine.Input.GetAxis("Mouse Y");
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

    }

}