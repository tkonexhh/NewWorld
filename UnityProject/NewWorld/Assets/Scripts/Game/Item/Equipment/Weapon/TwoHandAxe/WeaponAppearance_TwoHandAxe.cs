/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/TwoHandAxe/WeaponAppearance_TwoHandAxe.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:47:09 AM
	Tip:10/15/2020 10:47:09 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class WeaponAppearance_TwoHandAxe : WeaponAppearance
    {
        protected override string weaponResName => "Axe";

        public WeaponAppearance_TwoHandAxe(int id) : base(id)
        {

        }

    }

}