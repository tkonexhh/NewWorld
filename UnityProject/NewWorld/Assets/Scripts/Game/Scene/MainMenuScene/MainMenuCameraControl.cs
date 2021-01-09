/************************
	FileName:/Scripts/Game/Scene/MainMenuScene/MainMenuCameraControl.cs
	CreateAuthor:neo.xu
	CreateTime:1/9/2021 2:59:21 PM
	Tip:1/9/2021 2:59:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace Game.Logic
{
    public class MainMenuCameraControl : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_CameraNormal;
        [SerializeField] private CinemachineVirtualCamera m_CameraCreate;
        [SerializeField] private CinemachineVirtualCamera m_CameraFace;



        internal enum CameraType
        {
            Normal,
            Create,
        }

        private void Awake()
        {
            m_CameraNormal.Priority = 10;
            m_CameraCreate.Priority = 2;
            m_CameraFace.Priority = 1;
        }


        public void LookNormal()
        {
            m_CameraNormal.Priority = 10;
            m_CameraCreate.Priority = 1;
            m_CameraFace.Priority = 1;
        }

        public void LookCreate()
        {
            m_CameraNormal.Priority = 1;
            m_CameraCreate.Priority = 10;
            m_CameraFace.Priority = 1;
        }

        public void LookCreateFace()
        {
            m_CameraFace.Priority = 10;
            m_CameraNormal.Priority = 1;
            m_CameraCreate.Priority = 1;
        }

    }

}