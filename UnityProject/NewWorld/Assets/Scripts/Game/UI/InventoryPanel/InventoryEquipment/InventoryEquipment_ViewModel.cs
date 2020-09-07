/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryEquipment/InventoryEquipment_ViewModel.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 8:03:49 PM
	Tip:9/1/2020 8:03:49 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryEquipment_ViewModel
    {
        private PlayerEquipmentViewData m_EquipmentViewData = new PlayerEquipmentViewData();

        public PlayerEquipmentViewData viewData => m_EquipmentViewData;

        public void Init()
        {
            PlayerEquipmentCellData cellData_Helmet = new PlayerEquipmentCellData(new Equipment_Helmet(4));
            PlayerEquipmentCellData cellData_Torso = new PlayerEquipmentCellData(new Equipment_Torso(5));
            PlayerEquipmentCellData cellData_Hands = new PlayerEquipmentCellData(new Equipment_Hands(7));
            PlayerEquipmentCellData cellData_Legs = new PlayerEquipmentCellData(new Equipment_Legs(8));

            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Helmet, cellData_Helmet);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Torso, cellData_Torso);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Hands, cellData_Hands);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Legs, cellData_Legs);
        }
    }

}