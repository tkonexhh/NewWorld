/************************
	FileName:/Scripts/Game/Entity/Role/Mono/RoleAnimEventMonoEvent.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 4:15:10 PM
	Tip:9/18/2020 4:15:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class RoleAnimEvent : MonoBehaviour
    {
        private Role_Player m_Role;
        private Weapon m_CurWeapon;

        public bool canCombo { get; set; }

        public void Init(Role_Player role)
        {
            m_Role = role;
        }

        public void FootR()
        {
            //TODO 根据地形播发脚部声音
            // Debug.LogError("FootR");
        }

        public void FootL()
        {
            // Debug.LogError("FootL");
        }

        public void Hit()
        {
            m_CurWeapon?.Hit(m_Role);
        }

        public void CanAttack()
        {
            m_Role.controlComponent.firstAttack = true;
        }

        public void CanCombo(int value)
        {
            canCombo = value == 1;
        }

        public void Combo()
        {
            // Debug.LogError("Combo");
            if (m_Role.controlComponent.attackType != AttackTypeEnum.None)
            {
                m_CurWeapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
                m_CurWeapon.Combo(m_Role);
                m_Role.controlComponent.attackType = AttackTypeEnum.None;
            }
        }

        public void CanRotate(int canRotate)
        {
            // Debug.LogError("CanRotate:" + canRotate);
            // m_Role.controlComponent.canRotate = canRotate == 1;
        }

        public void Shoot()
        {
            //施法到目标
        }

        public void WeaponSwitch(int value)
        {
            // Debug.LogError("WeaponSwitch:" + value);
            if (value == 0)
            {
                AttachToHand();
            }
            else
            {
                AttachToOrigin();
            }
        }

        public void WeaponSwitchComplete()
        {
            // Debug.LogError("WeaponSwitchComplete");
            m_Role.controlComponent.WeaponSwitchComplete();
        }

        private void AttachToHand()
        {
            m_CurWeapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            var hand = m_Role.monoReference.handRightAttach;
            m_CurWeapon.AttachToHand(hand);
            m_Role.iKComponent.rightHandIK.SetFocusTarget(null);

        }
        private void AttachToOrigin()
        {
            m_CurWeapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            m_CurWeapon.AttachToOrigin();
            m_Role.iKComponent.rightHandIK.SetFocusTarget(null);
            m_CurWeapon = null;
        }


        public void RollComplete()
        {
            m_Role.controlComponent.rolling = false;
            m_Role.monoReference.animator.applyRootMotion = false;
        }

        public void DodgeComplete()
        {
            m_Role.controlComponent.dodgeing = false;
        }

    }

}