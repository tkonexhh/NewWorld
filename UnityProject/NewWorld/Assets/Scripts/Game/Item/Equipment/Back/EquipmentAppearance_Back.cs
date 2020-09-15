/************************
	FileName:/Scripts/Game/Item/Equipment/Back/EquipmentAppearance_Back.cs
	CreateAuthor:neo.xu
	CreateTime:9/15/2020 3:59:21 PM
	Tip:9/15/2020 3:59:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EquipmentAppearance_Back : EquipmentAppearance
    {
        public EquipmentAppearance_Back(int id) : base(id)
        {
        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.BackAttach, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.BackAttach, -1);
        }
    }

}