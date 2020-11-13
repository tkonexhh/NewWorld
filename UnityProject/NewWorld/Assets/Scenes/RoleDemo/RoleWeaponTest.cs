/************************
	FileName:/Scenes/RoleDemo/RoleWeapon.cs
	CreateAuthor:neo.xu
	CreateTime:11/11/2020 10:55:35 AM
	Tip:11/11/2020 10:55:35 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Game.Logic
{
    public class RoleWeaponTest : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown m_Dropdown;
        [SerializeField] private Button m_BtnWeaponEquip;
        [SerializeField] private Button m_BtnWeaponUnEquip;
        [SerializeField] private Button m_BtnUnSheath;
        [SerializeField] private Button m_BtnSheath;

        private RoleAnimTestPanel m_Panel;
        private WeaponType m_WeaponType;
        private Weapon m_Weapon;

        private RoleAnimTest role => m_Panel.role;
        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            m_Dropdown.options.Clear();
            for (int i = 0; i < (int)WeaponType.Length; i++)
            {
                TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
                data.text = ((WeaponType)i).ToString();
                m_Dropdown.options.Add(data);
            }
            m_Dropdown.value = 0;
            m_Dropdown.onValueChanged.AddListener(ChooseWeapon);
            m_BtnWeaponEquip.onClick.AddListener(OnClickEquip);
            m_BtnWeaponUnEquip.onClick.AddListener(OnClickUnEquip);
            m_BtnUnSheath.onClick.AddListener(OnClickUnSheath);
            m_BtnSheath.onClick.AddListener(OnClickSheath);
            m_Weapon = m_Panel.role.equipComponent.GetWeapon();
            UpdateBtn();

            role.controlComponent.onWeaponSwitchComplete += () =>
            {
                UpdateBtn();
            };
        }

        private void HideAllBtn()
        {
            m_BtnWeaponEquip.gameObject.SetActive(false);
            m_BtnWeaponUnEquip.gameObject.SetActive(false);
            m_BtnSheath.gameObject.SetActive(false);
            m_BtnUnSheath.gameObject.SetActive(false);
        }

        private void UpdateBtn()
        {
            m_BtnWeaponEquip.gameObject.SetActive(m_Weapon == null);
            m_BtnWeaponUnEquip.gameObject.SetActive(!m_BtnWeaponEquip.gameObject.activeSelf);

            if (m_Weapon == null)
            {
                m_BtnSheath.gameObject.SetActive(false);
                m_BtnUnSheath.gameObject.SetActive(false);
            }
            else
            {
                bool armed = role.controlComponent.armed;
                m_BtnSheath.gameObject.SetActive(armed);
                m_BtnUnSheath.gameObject.SetActive(!armed);

                m_BtnWeaponEquip.gameObject.SetActive(!armed);
                m_BtnWeaponUnEquip.gameObject.SetActive(!armed);
            }
        }

        private void ChooseWeapon(int index)
        {
            m_WeaponType = (WeaponType)index;
        }

        private void OnClickEquip()
        {
            if (m_Weapon != null) return;
            if (role.controlComponent.weaponSwitching) return;//正在切换中
            m_Weapon = EquipmentFactory.CreateTestEquipment(m_WeaponType);
            role.equipComponent.Equip(m_Weapon);
            UpdateBtn();
        }

        private void OnClickUnEquip()
        {
            if (m_Weapon == null) return;
            if (role.controlComponent.weaponSwitching) return;//正在切换中
            m_Weapon.Remove();
            m_Weapon = null;
            UpdateBtn();
        }

        private void OnClickUnSheath()
        {
            if (m_Weapon == null) return;
            if (role.controlComponent.weaponSwitching) return;//正在切换中
            role.controlComponent.Arm();
            HideAllBtn();
        }

        private void OnClickSheath()
        {
            if (m_Weapon == null) return;
            if (role.controlComponent.weaponSwitching) return;//正在切换中
            role.controlComponent.UnArm();
            HideAllBtn();
        }
    }

}