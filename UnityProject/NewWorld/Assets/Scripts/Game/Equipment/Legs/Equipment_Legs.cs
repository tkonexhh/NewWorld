/************************
	FileName:/Scripts/Game/Equipment/Leg/Equipment_Leg.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 11:05:40 AM
	Tip:7/3/2020 11:05:40 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Equipment_Legs : Equipment
    {
        public Equipment_Legs() : base()
        {
            m_Appearance = new EquipmentAppearance_Legs(10);
        }
    }

}