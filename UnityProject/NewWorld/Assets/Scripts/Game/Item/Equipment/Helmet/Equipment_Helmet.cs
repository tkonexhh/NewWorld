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
            //TODO 在装备信息中定义子类型
            m_Type = HelmetType.NoHead;

            switch (m_Type)
            {
                case HelmetType.Normal:
                    m_Appearance = new EquipmentAppearance_Helmet_Normal(5);
                    break;
                case HelmetType.NoFacialHair:
                    m_Appearance = new EquipmentAppearance_Helmet_NoFacialHair(2);
                    break;
                case HelmetType.NoHair:
                    m_Appearance = new EquipmentAppearance_Helmet_NoHair(9);
                    break;
                case HelmetType.NoHead:
                    m_Appearance = new EquipmentAppearance_Helmet_NoHead(5);
                    break;
                default:
                    Debug.LogError("No Correct Equipment_Helmet Appearance");
                    break;
            }
        }

    }

}