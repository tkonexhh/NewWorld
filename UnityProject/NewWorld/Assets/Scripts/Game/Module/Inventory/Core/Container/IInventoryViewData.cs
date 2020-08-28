/************************
	FileName:/Scripts/Data/Inventory/IAbstactInventoryViewData.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 11:39:23 AM
	Tip:8/18/2020 11:39:23 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IInventoryViewData
    {
        bool IsDirty { get; set; }

        int? GetId(IInventoryCellData cellData);
        int? GetInsertableId(IInventoryCellData cellData);
        void InsertInventoryItem(int id, IInventoryCellData cellData);
        bool CheckInsert(int id, IInventoryCellData cellData);
        void Clear();
    }

}