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
    public class WeaponAppearance_TwoHandSword : WeaponAppearance
    {
        protected override string weaponResName => "Large";

        public WeaponAppearance_TwoHandSword(int id) : base(id)
        {

        }


    }

}