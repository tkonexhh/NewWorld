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
        private Weapon m_CurWeapon;
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
            Debug.LogError("Hit");

            int random = Random.Range(0, 100);
            DamageTextEnum type = DamageTextEnum.Normal;
            if (random < 10)
            {
                type = DamageTextEnum.Crit;
            }
            WorldUIPanel.S.ShowDamage(PlayerMgr.S.role.transform.position, new Vector3(Random.Range(-40, 40), Random.Range(-40, 40) + 60, 0), type, Random.Range(1, 200));

            m_CurWeapon?.Hit();
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

    }

}