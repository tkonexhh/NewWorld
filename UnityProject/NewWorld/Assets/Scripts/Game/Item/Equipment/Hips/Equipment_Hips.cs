/************************
	FileName:/Scripts/Game/Item/Equipment/Hips/Equipment_Hips.cs
	CreateAuthor:neo.xu
	CreateTime:9/8/2020 8:28:45 PM
	Tip:9/8/2020 8:28:45 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Hips : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Hips;

        public Equipment_Hips(long id) : base(id)
        {
            m_Appearance = new EquipmentAppearance_Hips((int)EquipmentConf.Appearance);
        }
    }

}