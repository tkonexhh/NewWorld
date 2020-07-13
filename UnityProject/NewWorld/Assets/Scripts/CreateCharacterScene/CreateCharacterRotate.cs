/************************
	FileName:/Scripts/CreateCharacterScene/CreateCharacterRotate.cs
	CreateAuthor:neo.xu
	CreateTime:7/13/2020 2:36:12 PM
	Tip:7/13/2020 2:36:12 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class CreateCharacterRotate : MonoBehaviour
    {
        [SerializeField] private float m_RotateSpeed;
        [SerializeField] private float m_RotateMaxSpeed;
        [SerializeField] private Transform m_TrsCharacter;
        private bool m_IsRotateMode = false;
        private float m_TargetRotate = 0;

        private float m_RotateVel;

        private void Start()
        {
            GameInputMgr.S.mainAction.SetpUpRotateMode.started += OnSetUpRotateModeStart;
            GameInputMgr.S.mainAction.SetpUpRotateMode.canceled += OnSetUpRotateModeCancled;
            GameInputMgr.S.mainAction.SetpUpRotate.performed += OnSetUpRotate;
        }

        private void OnDestroy()
        {
            GameInputMgr.S.mainAction.SetpUpRotateMode.started -= OnSetUpRotateModeStart;
            GameInputMgr.S.mainAction.SetpUpRotateMode.canceled -= OnSetUpRotateModeCancled;
            GameInputMgr.S.mainAction.SetpUpRotate.performed -= OnSetUpRotate;
        }

        private void LateUpdate()
        {
            m_TargetRotate = Mathf.SmoothDampAngle(m_TrsCharacter.localRotation.y, m_TargetRotate, ref m_RotateVel, m_RotateSpeed, m_RotateMaxSpeed);
            Quaternion rotation = Quaternion.Euler(0, m_TargetRotate, 0);
            m_TrsCharacter.localRotation = rotation;
        }

        private void OnSetUpRotateModeStart(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            m_IsRotateMode = true;
        }

        private void OnSetUpRotateModeCancled(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            m_IsRotateMode = false;
        }

        private void OnSetUpRotate(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            if (!m_IsRotateMode) return;

            var value = callback.ReadValue<Vector2>();
            Debug.LogError("--" + value);
            float x = value.x;
            m_TargetRotate += x;
        }
    }

}