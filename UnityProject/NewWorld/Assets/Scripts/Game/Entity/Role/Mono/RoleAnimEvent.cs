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

        public void WeaponSwitch(int value1)
        {
            // m_Role.monoReference.fullBodyIK.solver.rightHandEffector.target = null;
            // m_Role.monoReference.fullBodyIK.solver.rightHandEffector.positionWeight = 1;
            var weapon = m_Role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Equipment_Weapon;
            var hand = m_Role.monoReference.handRightAttach;

            DOTween.To(delegate (float value)
            {
                //向下取整
                m_Role.monoReference.fullBodyIK.solver.rightHandEffector.positionWeight = value;
            }, 1, 0, 0.2f);

            weapon.appearance.weaponModel.transform.SetParent(hand);
            // m_Role.monoReference.fullBodyIK.solver.rightHandEffector.positionWeight = 0;
        }

    }

}