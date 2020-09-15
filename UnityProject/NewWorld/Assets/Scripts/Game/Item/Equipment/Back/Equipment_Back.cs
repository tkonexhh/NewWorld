/************************
	FileName:/Scripts/Game/Item/Equipment/Back/Equipment_Back.cs
	CreateAuthor:neo.xu
	CreateTime:9/15/2020 3:59:05 PM
	Tip:9/15/2020 3:59:05 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Equipment_Back : Equipment
    {
        public override EquipmentType equipmentType => EquipmentType.Back;

        public Equipment_Back(long id) : base(id)
        {
            m_Appearance = new EquipmentAppearance_Back((int)EquipmentConf.Appearance);
        }
    }

}