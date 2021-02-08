/************************
	FileName:/Scripts/Game/Camera/CameraMgr.cs
	CreateAuthor:neo.xu
	CreateTime:2/8/2021 10:13:26 AM
	Tip:2/8/2021 10:13:26 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using Cinemachine;

namespace Game.Logic
{
    public class CameraMgr : MonoBehaviour
    {
        public Camera mainCamera;
        public CinemachineFreeLook freeLookVCam;
        [SerializeField, Range(.5f, 3f)] private float m_SpeedMultiplier = 1f;//TODO: make this modifiable in the game settings
        private bool m_CameraMovementLock = false;

        public void SetTarget(Transform follow, Transform lookat)
        {
            freeLookVCam.Follow = follow;
            freeLookVCam.LookAt = lookat;
        }

        private void OnEnable()
        {
            GameInputMgr.S.cameraMoveEvent += OnCameraMove;
            GameInputMgr.S.enableMouseControlCameraEvent += OnEnableMouseControlCamera;
            GameInputMgr.S.disableMouseControlCameraEvent += OnDisableMouseControlCamera;
        }

        private void OnDisable()
        {
            GameInputMgr.S.cameraMoveEvent -= OnCameraMove;
            GameInputMgr.S.enableMouseControlCameraEvent -= OnEnableMouseControlCamera;
            GameInputMgr.S.disableMouseControlCameraEvent -= OnDisableMouseControlCamera;
        }

        private void OnEnableMouseControlCamera()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            m_CameraMovementLock = true;
        }

        private void OnDisableMouseControlCamera()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            freeLookVCam.m_XAxis.m_InputAxisValue = 0;
            freeLookVCam.m_YAxis.m_InputAxisValue = 0;
        }

        private void OnCameraMove(Vector2 cameraMovement)
        {
            if (m_CameraMovementLock) return;

            freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * Time.smoothDeltaTime * m_SpeedMultiplier;
            freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * Time.smoothDeltaTime * m_SpeedMultiplier;
        }
    }

}