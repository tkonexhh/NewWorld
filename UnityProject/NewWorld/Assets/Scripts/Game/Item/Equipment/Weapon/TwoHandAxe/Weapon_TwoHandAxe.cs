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
    public class Weapon_TwoHandAxe : Weapon
    {
        public override WeaponType weaponType => WeaponType.TwoHandAxe;

        public Weapon_TwoHandAxe(long id) : base(id)
        {
            m_Appearance = new WeaponAppearance_TwoHandAxe(0);
            // m_Appearance = new EquipmentAppearance_Weapon_TwoHandAxe((int)EquipmentConf.Appearance);
        }

        public override void AttachToHand(Transform hand)
        {
            // var dis = appearance.weaponModel.rightHand.transform.localPosition;
            // appearance.weaponModel.weapon.transform.SetParent(hand, false);
            // appearance.weaponModel.weapon.transform.localPosition = dis - appearance.weaponModel.weaponOriginPos;
            // appearance.weaponModel.weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        public override void AttachToOrigin()
        {
            var model = appearance.weaponModel;
            model.weapon.transform.SetParent(model.transform);
            model.weapon.transform.localPosition = model.weaponOriginPos;
            model.weapon.transform.localRotation = Quaternion.identity;
        }
    }

}