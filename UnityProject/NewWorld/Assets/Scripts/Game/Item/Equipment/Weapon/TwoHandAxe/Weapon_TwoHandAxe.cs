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
            base.UnSheath(role);
            role.animComponent.SetWeapon(3);
            bool isMoving = role.animComponent.GetMoving();
            if (isMoving)
            {
                role.animComponent.animator.CrossFade("2Hand-Axe-Movement-Blend", 0.15f, 0, 0.25f);
            }
            else
            {
                role.animComponent.animator.CrossFade("2Hand-Axe-Idle", 0.6f, 0, 0.6f);
            }

            role.animComponent.animator.CrossFade("2Hand-Axe-Unsheath-Back", 0.1f, 1, 0f);
            //role.animComponent.animator.CrossFade("2Hand-Axe-Unsheath-Back", 0.2f, 1, 0.2f);
            role.iKComponent.rightHandIK.SetFocusTarget(appearance.weaponModel.rightHand);
            role.iKComponent.rightHandIK.SetHandPoser(appearance.weaponModel.rightHand);
        }

        public override void Sheath(Role role)
        {
            base.Sheath(role);
            role.animComponent.animator.CrossFade("2Hand-Axe-Sheath-Back", 0.2f, 1, 0.2f);
            role.iKComponent.rightHandIK.SetFocusTarget(null);
            role.iKComponent.rightHandIK.SetHandPoser(null);
        }

        public override void Death(Role role)
        {
            base.Death(role);
            //Block不可以移动
            role.animComponent.animator.CrossFade("2Hand-Axe-Death1", 0.25f, 0, 0.1f);
        }

        public override void Block(Role role)
        {
            base.Block(role);
            //Block不可以移动
            role.animComponent.animator.CrossFade("2Hand-Axe-Block", 0.25f, 0, 0.1f);
        }

        public override void UnBlock(Role role)
        {
            base.UnBlock(role);
            role.animComponent.animator.CrossFade("2Hand-Axe-Movement-Blend", 0.25f, 0, 0.1f);
        }

        public override void Attack(Role_Player role)
        {
            base.Attack(role);
            role.animComponent.animator.CrossFade("AttackCombo", 0.2f, 0, 0);
        }

        public override void Attack2(Role_Player role)
        {
            base.Attack2(role);
            role.animComponent.animator.CrossFade("Attack2Combo", 0.2f, 0, 0);
        }

        public override void Combo(Role_Player role)
        {
            base.Combo(role);
            if (role.controlComponent.attackType == AttackTypeEnum.Light)
            {
                role.animComponent.ComboTrigger();
            }
            else if (role.controlComponent.attackType == AttackTypeEnum.Heavy)
            {
                role.animComponent.Combo2Trigger();
            }

        }

        public override void SpecialAttackStart(Role_Player role)
        {
            role.animComponent.animator.CrossFade("Special_Start", 0.1f, 0, 0);
        }

        public override void SpecialAttackEnd(Role_Player role)
        {
            role.animComponent.animator.CrossFade("Special_End", 0.2f, 0, 0);
        }

        public override void Roll(Role_Player role, RollDir dir)
        {
            switch (dir)
            {
                case RollDir.Forward:
                    role.animComponent.animator.CrossFade("2Hand-Axe-Roll-Forward", 0.2f, 0, 0);
                    break;
                case RollDir.Backward:
                    role.animComponent.animator.CrossFade("2Hand-Axe-Roll-Backward", 0.2f, 0, 0);
                    break;
                case RollDir.Left:
                    role.animComponent.animator.CrossFade("2Hand-Axe-Roll-Left", 0.2f, 0, 0);
                    break;
                case RollDir.Right:
                    role.animComponent.animator.CrossFade("2Hand-Axe-Roll-Right", 0.2f, 0, 0);
                    break;
            }
        }

        public override void Dodge(Role_Player role, DodgeDir dir)
        {
            switch (dir)
            {
                case DodgeDir.Left:
                    role.animComponent.animator.CrossFade("2Hand-Axe-Dodge-Left", 0.2f, 0, 0);
                    break;
                case DodgeDir.Right:
                    role.animComponent.animator.CrossFade("2Hand-Axe-Dodge-Right", 0.2f, 0, 0);
                    break;
            }

        }

        public override void Hit(Role role)
        {
            var hitCollider = weaponModel.hitCollider;
            hitCollider.gameObject.SetActive(true);
            var hits = Physics.OverlapBox(hitCollider.transform.position, weaponModel.hitCollider.bounds.size, hitCollider.transform.rotation, 1 << LayerDefine.Layer_HitCollider);

            if (hits.Length > 0)
            {
                Debug.LogError(hits[0].gameObject.name);
                CalcDamage();
                role.animComponent.AnimStopFrame(10);
            }
            hitCollider.gameObject.SetActive(false);
        }

        private void CalcDamage()
        {
            int random = Random.Range(0, 100);
            DamageTextEnum type = DamageTextEnum.Normal;
            if (random < 10)
            {
                type = DamageTextEnum.Crit;
            }
            WorldUIPanel.S.ShowDamage(PlayerMgr.S.role.transform.position, new Vector3(Random.Range(-40, 40), Random.Range(-40, 40) + 60, 0), type, Random.Range(1, 200));
        }
    }

}