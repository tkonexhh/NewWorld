/************************
	FileName:/Scripts/Game/Equipment/Hands/Equipment_Hands.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 11:15:17 AM
	Tip:7/3/2020 11:15:17 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Equipment_Hands : Equipment
    {
        public Equipment_Hands(int id) : base(id)
        {
            m_Appearance = new EquipmentAppearance_Hands(10);
        }
    }

}