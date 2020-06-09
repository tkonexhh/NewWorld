/************************
	FileName:/Scripts/Player/CameraSettings.cs
	CreateAuthor:neo.xu
	CreateTime:6/9/2020 3:27:10 PM
	Tip:6/9/2020 3:27:10 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace GameWish.Game
{
    public class CameraSettings : MonoBehaviour
    {
        [Serializable]
        public struct InvertSetting
        {
            public bool invertX;
            public bool invertY;
        }
        public Camera camera;
        public Transform follow;
        public Transform lookAt;

        public CinemachineFreeLook controllerCamera;
        public InvertSetting controllerInvertSetting;


        private void Awake()
        {
            camera = Camera.main;
            UpdateCameraSetting();
        }


        void UpdateCameraSetting()
        {
            controllerCamera.Follow = follow;
            controllerCamera.LookAt = lookAt;
            controllerCamera.m_XAxis.m_InvertInput = controllerInvertSetting.invertX;
            controllerCamera.m_YAxis.m_InvertInput = controllerInvertSetting.invertY;
        }
    }

}