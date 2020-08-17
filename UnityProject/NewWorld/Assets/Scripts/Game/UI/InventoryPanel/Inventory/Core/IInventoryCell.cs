/************************
	FileName:/Scripts/Game/UI/InventoryPanel/Inventory/Core/IInventoryCell.cs
	CreateAuthor:neo.xu
	CreateTime:8/17/2020 12:31:53 PM
	Tip:8/17/2020 12:31:53 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
	public interface IInventoryCell
	{
		RectTransform RectTransform { get; }
	    IInventoryCellData CellData { get; }
	}
	
}