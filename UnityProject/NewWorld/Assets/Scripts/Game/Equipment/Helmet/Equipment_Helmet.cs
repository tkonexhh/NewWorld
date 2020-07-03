/************************
	FileName:/Scripts/Game/Equipment/Equipment_Helmet.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 7:32:08 PM
	Tip:7/2/2020 7:32:08 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Equipment_Helmet : Equipment
    {
        private HelmetType m_Type;
        public Equipment_Helmet() : base()
        {
            m_Type = HelmetType.NoHair;

            switch (m_Type)
            {
                case HelmetType.Normal:
                    m_Appearance = new EquipmentAppearance_Helmet_Normal(1);
                    break;
                case HelmetType.NoFacialHair:
                    m_Appearance = new EquipmentAppearance_Helmet_NoFacialHair(1);
                    break;
                case HelmetType.NoHair:
                    m_Appearance = new EquipmentAppearance_Helmet_NoHair(2);
                    break;
                case HelmetType.NoHead:
                    m_Appearance = new EquipmentAppearance_Helmet_NoHead(3);
                    break;
            }
        }

    }

}