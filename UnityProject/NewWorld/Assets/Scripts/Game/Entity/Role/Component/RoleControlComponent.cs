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
using System;

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

        public void StartTalking()
        {
            //如果拿了武器的话先收刀
            if (armed)
            {
                Run callback = null;
                callback = () =>
                {
                    StartTalking();
                    onWeaponSwitchComplete -= callback;
                };

                onWeaponSwitchComplete += callback;
                UnArm();
                return;
            }

            string talkAnimName = "Talk" + UnityEngine.Random.Range(1, 9);
            role.animComponent.animator.CrossFade(talkAnimName, 0.2f, 0, 0f);

        }

        public void EndTalking()
        {
            role.animComponent.animator.CrossFade("Idle", 0.2f, 0, 0.2f);
        }

        public void Block()
        {
            //没有武装不能进行防守
            if (!armed)
                return;

            var weapon = role.equipComponent.GetWeapon();
            weapon.Block(role);
        }

        public void UnBlock()
        {
            //没有武装不能进行防守
            if (!armed)
                return;

            var weapon = role.equipComponent.GetWeapon();
            weapon.UnBlock(role);
        }
    }

}