/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/WeaponAppearance.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:46:47 AM
	Tip:10/15/2020 10:46:47 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class WeaponAppearance : EquipmentAppearance
    {
        protected WeaponModel m_WeaponModel;
        public WeaponModel weaponModel => m_WeaponModel;
        public WeaponAppearance(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {

        }
        public override void Removeppearance(CharacterAppearance appearance)
        {

        }
    }

}