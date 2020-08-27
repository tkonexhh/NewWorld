/************************
	FileName:/Scripts/Game/UI/InventoryPanel/Inventory/InventoryCellData.cs
	CreateAuthor:neo.xu
	CreateTime:8/17/2020 12:43:57 PM
	Tip:8/17/2020 12:43:57 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryCellData : AbstractInventoryCellData
    {

        public InventoryCellData(AbstractItem item)
        {
            Width = item.width;
            Height = item.height;
        }
    }

}