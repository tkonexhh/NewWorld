/************************
	FileName:/Scripts/Game/Equipment/Leg/Equipment_Leg.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 11:05:40 AM
	Tip:7/3/2020 11:05:40 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Legs : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Leg;

        public Equipment_Legs(int id) : base(id)
        {
            m_Appearance = new EquipmentAppearance_Legs(10);
        }
    }

}