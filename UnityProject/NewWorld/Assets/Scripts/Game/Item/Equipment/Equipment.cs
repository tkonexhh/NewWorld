/************************
	FileName:/Scripts/Game/Equipment/Equipment.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 7:23:28 PM
	Tip:7/2/2020 7:23:28 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{


    public class Equipment : Item, IEquipment
    {
        public override ItemType itemType => ItemType.Equipment;
        public virtual EquipmentType equipmentType => EquipmentType.None;

        public EquipmentAppearance m_Appearance;
        private EquipmentStatus m_Status;

        public Equipment(long id) : base(id)
        {

        }

        #region IEquip
        public void Equip(Role character)
        {
            m_Appearance.ApplyAppearance(character.appearance);
        }

        public void UnEquip(Role character)
        {
            //m_Appearance.ApplyAppearance(character.appearance);
        }
        #endregion


        #region abstractItem
        #endregion

    }

}