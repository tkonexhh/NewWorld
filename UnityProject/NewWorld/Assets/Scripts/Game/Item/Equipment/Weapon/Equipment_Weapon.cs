/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/Equipment_Weapon.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:40:10 AM
	Tip:10/15/2020 10:40:10 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Weapon : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Weapon;
        public virtual WeaponType weaponType => WeaponType.TwoHandAxe;
        public EquipmentAppearance_Weapon appearance => m_Appearance as EquipmentAppearance_Weapon;

        public Equipment_Weapon(long id) : base(id)
        {

        }
    }

}