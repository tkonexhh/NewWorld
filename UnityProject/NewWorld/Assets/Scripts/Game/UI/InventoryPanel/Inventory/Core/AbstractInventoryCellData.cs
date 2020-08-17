/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryBag/InventoryCellData.cs
	CreateAuthor:neo.xu
	CreateTime:8/17/2020 12:26:15 PM
	Tip:8/17/2020 12:26:15 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class AbstractInventoryCellData : IInventoryCellData
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
    }

}