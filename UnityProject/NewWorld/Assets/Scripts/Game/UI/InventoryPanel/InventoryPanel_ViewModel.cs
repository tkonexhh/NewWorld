/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryPanel_Model.cs
	CreateAuthor:neo.xu
	CreateTime:8/28/2020 5:21:44 PM
	Tip:8/28/2020 5:21:44 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryPanel_ViewModel
    {
        private Dictionary<InventoryItemType, PlayerInventoryViewData> m_ViewDataMap = new Dictionary<InventoryItemType, PlayerInventoryViewData>();
        private PlayerInventoryViewData m_SupplyViewData = new PlayerInventoryViewData(InventoryDefine.INVENTORY_SIZE);
        private PlayerInventoryViewData m_EquipmentViewData = new PlayerInventoryViewData(InventoryDefine.INVENTORY_SIZE);

        public void Init()
        {

        }

        public PlayerInventoryViewData GetDataByType(InventoryItemType type)
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