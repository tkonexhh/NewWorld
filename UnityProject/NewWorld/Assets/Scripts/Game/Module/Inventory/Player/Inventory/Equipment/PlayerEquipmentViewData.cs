/************************
	FileName:/Scripts/Game/Module/Inventory/Player/Equipment/PlayerEquipmentViewData.cs
	CreateAuthor:neo.xu
	CreateTime:9/2/2020 10:29:27 AM
	Tip:9/2/2020 10:29:27 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerEquipmentViewData : AbstractInventoryViewData
    {
        public PlayerEquipmentViewData() : this(new IInventoryCellData[(int)InventoryEquipSlot.Length])

        {
        }

        private PlayerEquipmentViewData(IInventoryCellData[] cellData) : base(cellData)
        {
        }

        #region IInventoryViewData
        public override int? GetId(IInventoryCellData cellData)
        {
            for (var i = 0; i < CellData.Length; i++)
            {
                if (CellData[i] == cellData)
                {
                    return i;
                }
            }
            return null;
        }
        public override int? GetInsertableId(IInventoryCellData cellData) { return null; }
        public override void InsertInventoryItem(int id, IInventoryCellData cellData)
        {
            CellData[id] = cellData;
            IsDirty = true;
        }
        public override bool CheckInsert(int id, IInventoryCellData cellData) { return false; }
        public override void Clear() { }
        #endregion

    }

}