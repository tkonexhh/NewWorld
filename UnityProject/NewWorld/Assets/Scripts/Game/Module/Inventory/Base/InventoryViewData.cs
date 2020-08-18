/************************
	FileName:/Scripts/Game/Module/Inventory/Base/InventoryData.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:54:14 PM
	Tip:8/18/2020 12:54:14 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryViewData : AbstractInventoryViewData
    {
        public InventoryViewData(int capacityWidth, int capacityHeight)
                   : this(new IInventoryCellData[capacityWidth * capacityHeight], capacityWidth, capacityHeight)
        {
        }

        public InventoryViewData(IInventoryCellData[] cellData, int capacityWidth, int capacityHeight) : base(cellData, capacityWidth, capacityHeight)
        {

        }

    }

}