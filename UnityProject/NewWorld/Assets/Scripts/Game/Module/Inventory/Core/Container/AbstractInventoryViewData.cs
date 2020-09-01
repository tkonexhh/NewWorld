/************************
	FileName:/Scripts/Data/InventoryViewData.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 11:38:47 AM
	Tip:8/18/2020 11:38:47 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public abstract class AbstractInventoryViewData : IInventoryViewData
    {
        public bool IsDirty { get; set; }

        public IInventoryCellData[] CellData { get; protected set; }


        public AbstractInventoryViewData(IInventoryCellData[] cellData)
        {
            IsDirty = true;
            CellData = cellData;
        }

        #region IInventoryViewData
        public abstract int? GetId(IInventoryCellData cellData);
        public abstract int? GetInsertableId(IInventoryCellData cellData);
        public abstract void InsertInventoryItem(int id, IInventoryCellData cellData);
        public abstract bool CheckInsert(int id, IInventoryCellData cellData);
        public abstract void Clear();
        #endregion




    }

}