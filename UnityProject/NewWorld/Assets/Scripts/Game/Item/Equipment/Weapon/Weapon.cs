/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/Weapon.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:40:10 AM
	Tip:10/15/2020 10:40:10 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Weapon : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Weapon;
        public virtual WeaponType weaponType => WeaponType.TwoHandAxe;
        public WeaponAppearance appearance => m_Appearance as WeaponAppearance;

        public Weapon(long id) : base(id)
        {

        }

        public virtual void UnSheath(Role role)
        {

        }

        public virtual void Sheath(Role role)
        {

        }

        public virtual void AttachToHand(Transform hand)
        {

        }

        public virtual void AttachToOrigin()
        {

        }

        public virtual void Hit()
        {

        }
    }

}