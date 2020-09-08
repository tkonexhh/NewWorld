/************************
	FileName:/Scripts/Game/Equipment/Torso/EquipmentAppearance_Torso.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 10:53:58 AM
	Tip:7/3/2020 10:53:58 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EquipmentAppearance_Torso : EquipmentAppearance
    {
        public EquipmentAppearance_Torso(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.Torso, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.Torso, 0);
        }
    }

}