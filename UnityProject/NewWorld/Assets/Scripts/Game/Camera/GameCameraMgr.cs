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
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[GameCameraMgr]")]
    public class GameCameraMgr : TMonoSingleton<GameCameraMgr>
    {
        public Camera mainCamera;
        public CinemachineFreeLook freeLookVCam;
        [SerializeField, Range(.5f, 3f)] private float m_SpeedMultiplier = 1f;//TODO: make this modifiable in the game settings
        private bool m_CameraMovementLock = false;
        private bool m_IsRightMouseButtonClick = false;
        private PostEffect m_CameraPostEffect;
        public PostEffect postEffect
        {
            get
            {
                if (m_CameraPostEffect == null)
                {
                    m_CameraPostEffect = mainCamera.GetComponent<PostEffect>();
                }
                return m_CameraPostEffect;
            }
        }

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

        private void OnDestory()
        {
            GameInputMgr.S.cameraMoveEvent -= OnCameraMove;
            GameInputMgr.S.enableMouseControlCameraEvent -= OnEnableMouseControlCamera;
            GameInputMgr.S.disableMouseControlCameraEvent -= OnDisableMouseControlCamera;
        }

        private void OnEnableMouseControlCamera()
        {
            m_IsRightMouseButtonClick = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(DisableMouseControlForFrame());
        }

        IEnumerator DisableMouseControlForFrame()
        {
            m_CameraMovementLock = true;
            yield return new WaitForEndOfFrame();
            m_CameraMovementLock = false;
        }

        private void OnDisableMouseControlCamera()
        {
            m_IsRightMouseButtonClick = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            freeLookVCam.m_XAxis.m_InputAxisValue = 0;
            freeLookVCam.m_YAxis.m_InputAxisValue = 0;
        }

        private void OnCameraMove(Vector2 cameraMovement)
        {
            if (m_CameraMovementLock) return;
            if (!m_IsRightMouseButtonClick) return;

            freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * Time.smoothDeltaTime * m_SpeedMultiplier;
            freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * Time.smoothDeltaTime * m_SpeedMultiplier;
        }
    }

}