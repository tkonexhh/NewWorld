/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryBag/IInventoryCellData.cs
	CreateAuthor:neo.xu
	CreateTime:8/17/2020 12:27:18 PM
	Tip:8/17/2020 12:27:18 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IInventoryCellData
    {
        Vector2Int size { get; }
        int Width { get; }
        int Height { get; }
    }

}