/************************
	FileName:/Scripts/Game/Equipment/Hands/EquipmentAppearance_Hands.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 11:15:32 AM
	Tip:7/3/2020 11:15:32 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class EquipmentAppearance_Hands : EquipmentAppearance
    {
        int m_HandID;
        int m_ElbowID;
        public EquipmentAppearance_Hands(int id) : base(id)
        {
            m_HandID = 10;
            m_ElbowID = 3;
        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.ArmLowerRight, id);
            appearance.SetAppearance(AppearanceSlot.ArmLowerLeft, id);
            appearance.SetAppearance(AppearanceSlot.HandRight, id);
            appearance.SetAppearance(AppearanceSlot.HandLeft, id);
            appearance.SetAppearance(AppearanceSlot.ElbowRight, m_ElbowID);
            appearance.SetAppearance(AppearanceSlot.ElbowLeft, m_ElbowID);
        }
    }

}