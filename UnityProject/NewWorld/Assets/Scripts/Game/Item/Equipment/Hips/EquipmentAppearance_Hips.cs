/************************
	FileName:/Scripts/Game/Item/Equipment/Hips/EquipmentAppearance_Hips.cs
	CreateAuthor:neo.xu
	CreateTime:9/8/2020 8:28:57 PM
	Tip:9/8/2020 8:28:57 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EquipmentAppearance_Hips : EquipmentAppearance
    {

        public EquipmentAppearance_Hips(int id) : base(id)
        {
        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.Hips, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.Hips, 0);
        }
    }

}