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
        [SerializeField] private Transform m_TrsCharacter;
        private bool m_IsRotateMode = false;
        private float m_TargetY = 0;


        private void Start()
        {
            Role role = new Role();
            //role.gameObject.SetActive();
            // GameInputMgr.S.uiAction.SetpUpRotateMode.started += OnSetUpRotateModeStart;
            // GameInputMgr.S.uiAction.SetpUpRotateMode.canceled += OnSetUpRotateModeCancled;
            // GameInputMgr.S.uiAction.SetpUpRotate.performed += OnSetUpRotate;
        }

        private void OnDestroy()
        {
            // GameInputMgr.S.uiAction.SetpUpRotateMode.started -= OnSetUpRotateModeStart;
            // GameInputMgr.S.uiAction.SetpUpRotateMode.canceled -= OnSetUpRotateModeCancled;
            // GameInputMgr.S.uiAction.SetpUpRotate.performed -= OnSetUpRotate;
        }

        private void OnSetUpRotateModeStart(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            m_IsRotateMode = true;
            m_TargetY = m_TrsCharacter.localRotation.eulerAngles.y;
        }

        private void OnSetUpRotateModeCancled(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            m_IsRotateMode = false;
        }

        private void OnSetUpRotate(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            if (!m_IsRotateMode) return;

            var value = callback.ReadValue<Vector2>();
            float x = value.x;
            m_TargetY -= x;
            m_TargetY = ClampAngle(m_TargetY, -360, 360);

            Quaternion rotation = Quaternion.Euler(0, m_TargetY, 0);
            m_TrsCharacter.localRotation = rotation;
        }

        private static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360) angle += 360;
            if (angle > 360) angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }

    }

}