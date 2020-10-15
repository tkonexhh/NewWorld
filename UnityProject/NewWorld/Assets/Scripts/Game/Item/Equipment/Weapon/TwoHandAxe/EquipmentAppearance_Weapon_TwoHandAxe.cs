/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/TwoHandAxe/EquipmentAppearance_Weapon_TwoHandAxe.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:47:09 AM
	Tip:10/15/2020 10:47:09 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class EquipmentAppearance_Weapon_TwoHandAxe : EquipmentAppearance_Weapon
    {
        private GameObject m_ObjWeapon;
        private WeaponModel_TwoHandAxe m_WeaponModel;
        public EquipmentAppearance_Weapon_TwoHandAxe(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            AddressableResMgr.S.InstantiateAsync("SM_Wep_Axe_01", weapon =>
            {
                m_ObjWeapon = weapon;
                m_WeaponModel = m_ObjWeapon.GetComponent<WeaponModel_TwoHandAxe>();

                //TODO 暂时用PlayerMgr.S.Role 之后换掉
                // m_WeaponModel.rightHandPos

            });
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            m_WeaponModel = null;
            AddressableResMgr.S.ReleaseInstance(m_ObjWeapon);
        }
    }

}