/************************
	FileName:/Scripts/Data/InventoryData.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 11:37:42 AM
	Tip:8/18/2020 11:37:42 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerInventoryViewData : InventoryViewData
    {
        public PlayerInventoryViewData(int capacityWidth, int capacityHeight)
                           : this(new IInventoryCellData[capacityWidth * capacityHeight], capacityWidth, capacityHeight)
        {
        }

        public PlayerInventoryViewData(IInventoryCellData[] cellData, int capacityWidth, int capacityHeight) : base(cellData, capacityWidth, capacityHeight)
        {

        }
    }

}