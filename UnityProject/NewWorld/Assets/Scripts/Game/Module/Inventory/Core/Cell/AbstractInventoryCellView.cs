/************************
	FileName:/Scripts/Data/Inventory/Core/Cell/AbstractCellView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:39:39 PM
	Tip:8/18/2020 12:39:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class AbstractInventoryCellView : MonoBehaviour, IInventoryCellView
    {
        public RectTransform RectTransform { get; }
        public IInventoryCellData CellData { get; }
    }

}