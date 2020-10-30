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
        private Role m_Role;
        public void Init(Role role)
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

        }

        public void Shoot()
        {
            //施法到目标
        }

        public void WeaponSwitch(int value)
        {
            Debug.LogError("WeaponSwitch:" + value);
            if (value == 0)
            {
                AttachToHand();
            }
            else
            {
                AttachToOrigin();
            }
        }

        private void AttachToHand()
        {
            var weapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            var hand = m_Role.monoReference.handRightAttach;
            weapon.AttachToHand(hand);
            m_Role.iKComponent.rightHandIK.SetFocusTarget(null);

        }
        private void AttachToOrigin()
        {
            var weapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            weapon.AttachToOrigin();
            m_Role.iKComponent.rightHandIK.SetFocusTarget(null);
        }

    }

}