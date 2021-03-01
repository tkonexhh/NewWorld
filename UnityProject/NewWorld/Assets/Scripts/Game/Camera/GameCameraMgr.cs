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
    public enum GameCameraType
    {
        FreeLook,
        LockOn,
    }
    [TMonoSingletonAttribute("[Game]/[Tools]/[GameCameraMgr]")]
    public class GameCameraMgr : TMonoSingleton<GameCameraMgr>
    {
        private GameCameraType m_CameraType;
        public Camera mainCamera;
        public CinemachineFreeLook freeLookVCam;
        [Header("Focus Camera")]
        public CinemachineVirtualCamera focusLookVCam;
        public CinemachineTargetGroup focusTargetGroup;
        private Transform m_FocusTarget;

        [SerializeField, Range(.5f, 3f)] private float m_SpeedMultiplier = 3f;//TODO: make this modifiable in the game settings
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
            focusTargetGroup.AddMember(freeLookVCam.LookAt, 0.8f, 1.0f);
        }

        public void SetType(GameCameraType type)
        {
            if (m_CameraType == type) return;
            if (type == GameCameraType.FreeLook)
            {
                freeLookVCam.transform.position = focusLookVCam.transform.position;
                freeLookVCam.gameObject.SetActive(true);
                focusLookVCam.gameObject.SetActive(false);
            }
            else
            {
                focusLookVCam.transform.position = freeLookVCam.transform.position;
                freeLookVCam.gameObject.SetActive(false);
                focusLookVCam.gameObject.SetActive(true);
            }

            m_CameraType = type;
        }

        public void FocusTarget(Transform focus)
        {
            if (m_FocusTarget != null)
                focusTargetGroup.RemoveMember(m_FocusTarget);

            m_FocusTarget = focus;
            focusTargetGroup.AddMember(m_FocusTarget, 0.2f, 1.0f);
            SetType(GameCameraType.LockOn);

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