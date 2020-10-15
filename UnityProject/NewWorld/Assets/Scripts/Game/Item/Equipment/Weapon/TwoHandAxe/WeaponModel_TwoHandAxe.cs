/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/TwoHandAxe/WeaponModel_TwoHandAxe.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:59:06 AM
	Tip:10/15/2020 10:59:06 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class WeaponModel_TwoHandAxe : WeaponModel
    {
        public Transform rightHandPos;
        public Transform leftHandPos;



        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0, 1.0f);
            if (rightHandPos)
            {
                Gizmos.DrawWireSphere(rightHandPos.position, 0.05f);
                Gizmos.DrawLine(rightHandPos.position, rightHandPos.position + rightHandPos.up * 0.15f);
            }
        }
    }

}