/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryEquipment/Cell/PlayerEquipmentCellData.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 7:59:44 PM
	Tip:9/1/2020 7:59:44 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerEquipmentCellData : PlayerInventoryItemData
    {
        public Equipment equipment => item as Equipment;
        public InventoryEquipSlot slot { get; set; }
        public PlayerEquipmentCellData(InventoryEquipSlot slot, Equipment item) : base(item)
        {
            this.slot = slot;
        }
    }

}