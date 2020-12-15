/************************
	FileName:/Scripts/Game/UI/InventoryPanel/ViewModel/InventoryBag_ViewModel.cs
	CreateAuthor:neo.xu
	CreateTime:8/31/2020 12:30:13 PM
	Tip:8/31/2020 12:30:13 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryBag_ViewModel
    {
        private Dictionary<InventoryToggleType, PlayerInventoryViewData> m_ViewDataMap = new Dictionary<InventoryToggleType, PlayerInventoryViewData>();
        private PlayerInventoryViewData m_SupplyViewData = new PlayerInventoryViewData(InventoryDefine.INVENTORY_SIZE);
        private PlayerInventoryViewData m_EquipmentViewData = new PlayerInventoryViewData(InventoryDefine.INVENTORY_SIZE);

        public void Init()
        {
            var supplys = GamePlayMgr.S.playerMgr.inventoryMgr.LstSupply;
            supplys.ForEach((item) =>
            {
                PlayerInventoryCellData cellData = new PlayerInventoryCellData(item);
                m_SupplyViewData.InsertInventoryItem(m_SupplyViewData.GetInsertableId(cellData).Value, cellData);
            });

            var equips = GamePlayMgr.S.playerMgr.inventoryMgr.LstEquipment;
            equips.ForEach((item) =>
            {
                PlayerInventoryCellData cellData = new PlayerInventoryCellData(item);
                m_EquipmentViewData.InsertInventoryItem(m_EquipmentViewData.GetInsertableId(cellData).Value, cellData);
            });

            m_ViewDataMap.Add(InventoryToggleType.Supplies, m_SupplyViewData);
            m_ViewDataMap.Add(InventoryToggleType.Equipment, m_EquipmentViewData);
        }

        public PlayerInventoryViewData GetDataByType(InventoryToggleType type)
        {
            PlayerInventoryViewData viewdata;
            if (m_ViewDataMap.TryGetValue(type, out viewdata))
            {
                return viewdata;
            }
            return null;
        }
    }

}