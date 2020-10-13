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

            PlayerEquipmentCellData cellData_Helmet = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Helmet));
            PlayerEquipmentCellData cellData_Torso = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Torso));
            PlayerEquipmentCellData cellData_Hands = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Hands));
            PlayerEquipmentCellData cellData_Legs = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Legs));
            PlayerEquipmentCellData cellData_Hips = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Hips));
            PlayerEquipmentCellData cellData_Shoulders = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Shoulders));
            PlayerEquipmentCellData cellData_Back = new PlayerEquipmentCellData(PlayerMgr.S.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Back));

            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Helmet, cellData_Helmet);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Torso, cellData_Torso);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Hands, cellData_Hands);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Legs, cellData_Legs);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Hips, cellData_Hips);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Shoulders, cellData_Shoulders);
            m_EquipmentViewData.InsertInventoryItem((int)InventoryEquipSlot.Back, cellData_Back);
        }
    }

}