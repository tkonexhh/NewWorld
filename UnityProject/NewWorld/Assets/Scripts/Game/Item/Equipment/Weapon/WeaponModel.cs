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
        [Header("武器握点")]
        public InteractionObject handleObj;

        private Vector3 m_PosOriginPos;
        public Vector3 WeaponOriginPos
        {
            get
            {
                return m_PosOriginPos;
            }
        }

        public void AttachWeapon()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            m_PosOriginPos = weapon.transform.localPosition;
        }
    }

}