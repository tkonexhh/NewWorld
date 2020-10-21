/************************
	FileName:/Scripts/Game/SetupScene/SetupScene.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 8:27:07 PM
	Tip:7/9/2020 8:27:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class CreateCharacterScene : AbstractScene
    {
        [SerializeField] private Transform m_TransRoleRoot;
        [SerializeField] private CreateCharacterCameraControl m_CameraControl;

        private float m_RoleRotateSpeed;
        protected override void OnSceneInit()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(UIMgr.S.uiRoot.uiCamera);
        }

        protected override void OnSceneEnter()
        {
            UIMgr.S.OpenPanel(UIID.CreateCharacterPanel);

            Role setupRole = new Role();
            setupRole.onRoleCreated += (role) =>
            {
                role.transform.SetParent(m_TransRoleRoot);
                role.transform.localPosition = Vector3.zero;

                m_CameraControl.SetFocusRole(role);
            };

            GameInputMgr.S.uiAction.Rotate.performed += OnRoleRotatePerformed;
            GameInputMgr.S.uiAction.Rotate.canceled += OnRoleRotateCanceled;
            // UIMgr.S.OpenPanel(UIID.Inventorypanel);
        }


        private void OnRoleRotatePerformed(InputAction.CallbackContext callback)
        {
            m_RoleRotateSpeed = -callback.ReadValue<float>() * 7;
        }

        private void OnRoleRotateCanceled(InputAction.CallbackContext callback)
        {
            m_RoleRotateSpeed = 0;
        }

        private void FixedUpdate()
        {
            if (m_RoleRotateSpeed != 0)
            {
                Vector3 target_angle = m_TransRoleRoot.rotation.eulerAngles;
                m_TransRoleRoot.rotation = Quaternion.Lerp(m_TransRoleRoot.rotation, Quaternion.Euler(target_angle + new Vector3(0, m_RoleRotateSpeed, 0)), 0.5f);
            }
        }

    }

}