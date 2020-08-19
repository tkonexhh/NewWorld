/************************
	FileName:/Scripts/Game/Module/Inventory/Base/InventoryView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:53:53 PM
	Tip:8/18/2020 12:53:53 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryView : AbstractInventoryView
    {
        #region IInventoryView

        public override void SetCellCallback(
            Action<IInventoryCellView> onCellClick,
            Action<IInventoryCellView> onCellOptionClick,
            Action<IInventoryCellView> onCellEnter,
            Action<IInventoryCellView> onCellExit)
        {
            base.SetCellCallback(onCellClick, onCellOptionClick, onCellEnter, onCellExit);
        }

        public override void Apply(IInventoryViewData data)
        {
            base.Apply(data);
        }

        public override void ReApply()
        {
            base.ReApply();
        }
        #endregion
    }

}