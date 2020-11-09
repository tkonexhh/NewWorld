using System.Linq;
/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/TwoHandAxe/Equipment_Weapon_TwoHandAxe.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:43:34 AM
	Tip:10/15/2020 10:43:34 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Logic
{
    public class Weapon_TwoHandAxe : Weapon
    {
        public override WeaponType weaponType => WeaponType.TwoHandAxe;

        public WeaponModel_TwoHandAxe weaponModel => appearance.weaponModel as WeaponModel_TwoHandAxe;

        public Weapon_TwoHandAxe(long id) : base(id)
        {
            m_Appearance = new WeaponAppearance_TwoHandAxe(0);
            // m_Appearance = new EquipmentAppearance_Weapon_TwoHandAxe((int)EquipmentConf.Appearance);
        }

        public override void AttachToHand(Transform hand)
        {
            float localScale = appearance.weaponModel.rightHand.transform.localScale.x;

            Vector3 pos = hand.InverseTransformPoint(appearance.weaponModel.rightHand.transform.localPosition);
            Vector3 rot = hand.InverseTransformVector(appearance.weaponModel.rightHand.transform.localPosition);
            appearance.weaponModel.weapon.transform.SetParent(hand);
            appearance.weaponModel.weapon.transform.localPosition = pos / 100;
            appearance.weaponModel.weapon.transform.localRotation = Quaternion.Euler(rot / 100);
        }

        public override void AttachToOrigin()
        {
            var model = appearance.weaponModel;
            model.weapon.transform.SetParent(model.transform);
            model.weapon.transform.localPosition = model.weaponOriginPos;
            model.weapon.transform.localRotation = Quaternion.identity;
        }

        public override void UnSheath(Role role)
        {
            role.iKComponent.rightHandIK.SetFocusTarget(appearance.weaponModel.rightHand);
            role.iKComponent.rightHandIK.SetHandPoser(appearance.weaponModel.rightHand);
        }

        public override void Sheath(Role role)
        {
            role.iKComponent.rightHandIK.SetFocusTarget(null);
            role.iKComponent.rightHandIK.SetHandPoser(null);
        }

        public override void Hit()
        {
            var hitCollider = weaponModel.hitCollider;
            hitCollider.gameObject.SetActive(true);
            var hits = Physics.OverlapBox(hitCollider.transform.position, weaponModel.hitCollider.bounds.size, hitCollider.transform.rotation);
            Debug.LogError(hits.Length);

            hitCollider.gameObject.SetActive(false);
        }


    }

}