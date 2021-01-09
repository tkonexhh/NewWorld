/************************
	FileName:/Scripts/Game/Scene/MainMenuScene/MainMenuScene.cs
	CreateAuthor:neo.xu
	CreateTime:8/27/2020 10:45:36 AM
	Tip:8/27/2020 10:45:36 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace Game.Logic
{
    public class MainMenuScene : AbstractScene
    {
        [SerializeField] private Transform m_RoleRoot;
        [SerializeField] private MainMenuCameraControl m_CameraControl;

        public MainMenuCameraControl cameraControl => m_CameraControl;


        private float m_RoleRotateSpeed;
        private Role m_Role;
        private bool m_ControlRotate = false;

        protected override void OnSceneInit()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(UIMgr.S.uiRoot.uiCamera);
            m_CameraControl.LookNormal();
        }
        protected override void OnSceneEnter()
        {
            m_Role = new Role();
            m_Role.data.equipmentData.hipsID = 35;
            m_Role.onRoleCreated += (target) =>
            {
                target.transform.SetParent(m_RoleRoot);
                target.transform.localPosition = Vector3.zero;
                target.transform.localRotation = Quaternion.identity;
                m_Role.equipComponent.ApplyEquipment();
            };
            UIMgr.S.OpenPanel(UIID.StartPanel, (panel) =>
            {
                ((StartPanel)panel).InitMainScene(this);
            });
        }

        protected override void OnSceneExit()
        {
            RemoveControlRotate();
        }

        public void ControlRotate()
        {
            if (m_ControlRotate) return;

            m_ControlRotate = true;
            GameInputMgr.S.uiAction.Rotate.performed += OnRoleRotatePerformed;
            GameInputMgr.S.uiAction.Rotate.canceled += OnRoleRotateCanceled;
        }

        private void RemoveControlRotate()
        {
            if (m_ControlRotate)
            {
                GameInputMgr.S.uiAction.Rotate.performed -= OnRoleRotatePerformed;
                GameInputMgr.S.uiAction.Rotate.canceled -= OnRoleRotateCanceled;
            }
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
                Vector3 target_angle = m_Role.transform.rotation.eulerAngles;
                m_Role.transform.rotation = Quaternion.Lerp(m_Role.transform.rotation, Quaternion.Euler(target_angle + new Vector3(0, m_RoleRotateSpeed, 0)), 0.5f);
            }
        }

        public void ResetRoleRotation()
        {
            if (m_Role == null) return;
            RemoveControlRotate();
            m_Role.transform.DOLocalRotate(Vector3.zero, 0.5f);

        }

    }

}