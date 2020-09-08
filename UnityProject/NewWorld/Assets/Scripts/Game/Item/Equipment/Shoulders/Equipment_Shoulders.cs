/************************
	FileName:/Scripts/Game/Item/Equipment/Shoulders/Equipment_Shoulders.cs
	CreateAuthor:neo.xu
	CreateTime:9/8/2020 8:36:55 PM
	Tip:9/8/2020 8:36:55 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Shoulders : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Shoulders;

        public Equipment_Shoulders(long id) : base(id)
        {
            m_Appearance = new EquipmentAppearance_Shoulders((int)EquipmentConf.Appearance);
        }
    }

}