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
        #region IInventoryCellData
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Vector2Int size { get => new Vector2Int(Width, Height); }
        #endregion

        public AbstractInventoryCellData(AbstractItem item)
        {
            Width = item.width;
            Height = item.height;
        }
    }

}