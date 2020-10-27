/************************
	FileName:/Scripts/Game/Entity/Role/Mono/RoleAnimEventMonoEvent.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 4:15:10 PM
	Tip:9/18/2020 4:15:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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
                WeaponSheath();
            }
            else
            {
                WeaponUnSheath();
            }
        }

        private void WeaponSheath()
        {
            var weapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Equipment_Weapon;
            var hand = m_Role.monoReference.handRightAttach;

            m_Role.iKComponent.rightHandIK.SetFocusTarget(null, Vector3.zero);

            var model = (weapon.appearance.weaponModel as WeaponModel_TwoHandAxe);
            var dis = -model.rightHandPos.transform.localPosition;
            var angle = model.transform.localRotation;
            model.transform.SetParent(hand, false);
            // model.transform.RotateAround(model.rightHandPos.localPosition, Vector3.left, angle.y * 2);
            model.transform.localPosition = dis;
        }
        private void WeaponUnSheath()
        {
            var weapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Equipment_Weapon;
            var back = m_Role.appearanceComponent.appearance.weaponBackAttachment;

            m_Role.iKComponent.rightHandIK.SetFocusTarget(null, Vector3.zero);

            var model = (weapon.appearance.weaponModel as WeaponModel_TwoHandAxe);
            model.transform.SetParent(back, false);
            model.transform.localPosition = Vector3.zero;
        }

    }

}