/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/TwoHandAxe/Equipment_Weapon_TwoHandAxe.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:43:34 AM
	Tip:10/15/2020 10:43:34 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Weapon_TwoHandAxe : Equipment_Weapon
    {
        public override WeaponType weaponType => WeaponType.TwoHandAxe;

        public Equipment_Weapon_TwoHandAxe(long id) : base(id)
        {
            m_Appearance = new EquipmentAppearance_Weapon_TwoHandAxe(0);
            // m_Appearance = new EquipmentAppearance_Weapon_TwoHandAxe((int)EquipmentConf.Appearance);
        }
    }

}