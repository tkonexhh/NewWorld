/************************
	FileName:/Scripts/Game/Equipment/Leg/EquipmentAppearance_Legs.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 11:05:59 AM
	Tip:7/3/2020 11:05:59 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class EquipmentAppearance_Legs : EquipmentAppearance
    {
        int m_KneeID;
        public EquipmentAppearance_Legs(int id) : base(id)
        {
            m_KneeID = 1;
        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.LegRight, id);
            appearance.SetAppearance(AppearanceSlot.LegLeft, id);
            appearance.SetAppearance(AppearanceSlot.KneeRight, m_KneeID);
            appearance.SetAppearance(AppearanceSlot.KneeLeft, m_KneeID);
        }
    }

}