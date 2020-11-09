/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/WeaponModel.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:58:48 AM
	Tip:10/15/2020 10:58:48 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

namespace Game.Logic
{
    public class WeaponModel : MonoBehaviour
    {
        [Header("武器模型")]
        public GameObject weapon;
        public Transform rightHand;

        public Vector3 weaponOriginPos
        {
            get;
            private set;
        }

        public virtual void Init() { }

        public void AttachWeapon()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            weaponOriginPos = weapon.transform.localPosition;
        }
    }

}