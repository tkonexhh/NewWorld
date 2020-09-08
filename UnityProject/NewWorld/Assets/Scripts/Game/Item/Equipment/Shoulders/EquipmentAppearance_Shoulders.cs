/************************
	FileName:/Scripts/Game/Item/Equipment/Shoulders/EquipmentAppearance_Shoulders.cs
	CreateAuthor:neo.xu
	CreateTime:9/8/2020 8:37:10 PM
	Tip:9/8/2020 8:37:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    //这样不能实现单肩造型
    public class EquipmentAppearance_Shoulders : EquipmentAppearance
    {
        public EquipmentAppearance_Shoulders(int id) : base(id)
        {
        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.ShoulderRight, id);
            appearance.SetAppearance(AppearanceSlot.ShoulderLeft, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.ShoulderRight, -1);
            appearance.SetAppearance(AppearanceSlot.ShoulderLeft, -1);
        }
    }

}