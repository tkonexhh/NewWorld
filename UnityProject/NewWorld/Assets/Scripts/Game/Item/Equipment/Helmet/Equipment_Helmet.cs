/************************
	FileName:/Scripts/Game/Equipment/Equipment_Helmet.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 7:32:08 PM
	Tip:7/2/2020 7:32:08 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Helmet : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Helmet;

        private HelmetType m_Type;
        public Equipment_Helmet(long id) : base(id)
        {
            m_Type = HelmetType.NoHair;

            switch (m_Type)
            {
                case HelmetType.Normal:
                    m_Appearance = new EquipmentAppearance_Helmet_Normal(5);
                    break;
                case HelmetType.NoFacialHair:
                    m_Appearance = new EquipmentAppearance_Helmet_NoFacialHair(5);
                    break;
                case HelmetType.NoHair:
                    m_Appearance = new EquipmentAppearance_Helmet_NoHair(5);
                    break;
                case HelmetType.NoHead:
                    m_Appearance = new EquipmentAppearance_Helmet_NoHead(5);
                    break;
            }
        }

    }

}