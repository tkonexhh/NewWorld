/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryRoleShow/InventoryRoleShow.cs
	CreateAuthor:neo.xu
	CreateTime:9/4/2020 5:23:39 PM
	Tip:9/4/2020 5:23:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class InventoryRoleShow : MonoBehaviour, IEventListener
    {
        [SerializeField] private RawImage m_RawImage;
        private float m_RoleRotateSpeed;
        private CharacterAppearance m_CharacterAppearance;
        private void Awake()
        {
            m_RawImage.SetNativeSize();
        }

        public void Init()
        {
            RegisterEvent();
            AddressableResMgr.S.InstantiateAsync("InventoryRoleScene", (target) =>
            {
                target.transform.position = Vector3.one * 5000;
                m_CharacterAppearance = target.GetComponentInChildren<CharacterAppearance>();
                m_CharacterAppearance.SetAppearanceData(PlayerMgr.S.role.data.appearanceData);
            });

            GameInputMgr.S.uiAction.Rotate.performed += OnRoleRotatePerformed;
            GameInputMgr.S.uiAction.Rotate.canceled += OnRoleRotateCanceled;
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
                Vector3 target_angle = m_CharacterAppearance.transform.rotation.eulerAngles;
                m_CharacterAppearance.transform.rotation = Quaternion.Lerp(m_CharacterAppearance.transform.rotation, Quaternion.Euler(target_angle + new Vector3(0, m_RoleRotateSpeed, 0)), 0.5f);
            }
        }

        #region IEventListener
        public void RegisterEvent()
        {
            EventSystem.S.Register(EventID.OnRefeshAppearance, HandleEvent);
        }

        public void UnRegisterEvent()
        {
            EventSystem.S.UnRegister(EventID.OnRefeshAppearance, HandleEvent);
        }

        public void HandleEvent(int key, params object[] args)
        {
            switch (key)
            {
                case (int)EventID.OnRefeshAppearance:
                    if (m_CharacterAppearance != null)
                    {
                        InventoryEquipSlot slot = (InventoryEquipSlot)args[0];
                        Equipment equipment = (Equipment)args[1];
                        Equipment oldEquipment = (Equipment)args[2];
                        oldEquipment?.equipmentAppearance.Removeppearance(m_CharacterAppearance);
                        //对装备栏角色产生装备效果
                        equipment?.equipmentAppearance.ApplyAppearance(m_CharacterAppearance);
                        m_CharacterAppearance.CombineMeshs();

                    }
                    break;
            }
        }
        #endregion
    }
}

