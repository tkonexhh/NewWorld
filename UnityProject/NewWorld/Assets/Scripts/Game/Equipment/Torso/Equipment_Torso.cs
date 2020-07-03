/************************
	FileName:/Scripts/Game/Equipment/Equipment_Torso.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 10:51:44 AM
	Tip:7/3/2020 10:51:44 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Equipment_Torso : Equipment
    {
        public Equipment_Torso() : base()
        {
            m_Appearance = new EquipmentAppearance_Torso(4);
        }
    }

}