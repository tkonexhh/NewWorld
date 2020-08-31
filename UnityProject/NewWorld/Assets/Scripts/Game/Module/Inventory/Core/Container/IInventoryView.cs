/************************
	FileName:/Scripts/Data/Inventory/Core/View/IAbstractInventoryView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:30:19 PM
	Tip:8/18/2020 12:30:19 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Logic
{
    public interface IInventoryView
    {

        void SetCellCallback(
                   Action<IInventoryCellView> onCellClick,
                   Action<IInventoryCellView> onCellOptionClick,
                   Action<IInventoryCellView> onCellEnter,
                   Action<IInventoryCellView> onCellExit);

        void Apply(IInventoryViewData data);
        void ReApply();

        void OnPrePick(IInventoryCellView targetCell);
        bool OnPick(IInventoryCellView targetCell);
        void OnDrag(IInventoryCellView targetCell, IInventoryCellView effectCell, PointerEventData pointerEventData);
        bool OnDrop(IInventoryCellView targetCell, IInventoryCellView effectCell);
        void OnDroped(bool isDroped);

        void OnCellEnter(IInventoryCellView targetCell, IInventoryCellView effectCell);
        void OnCellExit(IInventoryCellView targetCell);
    }

}