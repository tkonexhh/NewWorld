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
    }

}