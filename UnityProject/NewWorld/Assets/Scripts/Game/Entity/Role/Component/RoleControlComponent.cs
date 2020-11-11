/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:11/11/2020 2:41:23 PM
	Tip:11/11/2020 2:41:23 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class RoleControlComponent : RoleBaseComponent
    {
        private bool m_DesiredToArm = false;

        /// <summary>
        /// 正在切换武器中
        /// </summary>
        /// <value></value>
        public bool weaponSwitching { get; private set; }

        /// <summary>
        /// 是否装备武器
        /// </summary>
        /// <value></value>
        public bool armed { get; private set; }


        public Run onWeaponSwitchComplete;

        public void Arm()
        {
            if (weaponSwitching) return;
            weaponSwitching = true;
            m_DesiredToArm = true;
            var weapon = role.equipComponent.GetWeapon();
            weapon.UnSheath(role);
        }

        public void UnArm()
        {
            if (weaponSwitching) return;
            weaponSwitching = true;
            m_DesiredToArm = false;
            var weapon = role.equipComponent.GetWeapon();
            weapon.Sheath(role);
        }

        public void WeaponSwitchComplete()
        {
            weaponSwitching = false;
            armed = m_DesiredToArm;
            m_DesiredToArm = false;
            if (onWeaponSwitchComplete != null)
                onWeaponSwitchComplete();
        }
    }

}