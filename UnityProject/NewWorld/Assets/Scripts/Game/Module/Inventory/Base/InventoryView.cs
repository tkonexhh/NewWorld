// /************************
// 	FileName:/Scripts/Game/Module/Inventory/Base/InventoryView.cs
// 	CreateAuthor:neo.xu
// 	CreateTime:8/18/2020 12:53:53 PM
// 	Tip:8/18/2020 12:53:53 PM
// ************************/

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;


// namespace Game.Logic
// {
//     public class InventoryView : AbstractInventoryView
//     {
//         #region IInventoryView


//         public override void Apply(IInventoryViewData data)
//         {
//             base.Apply(data);
//         }

//         public override void ReApply()
//         {
//             base.ReApply();
//         }

//         public override void OnPrePick(IInventoryCellView stareCell) { }
//         public override bool OnPick(IInventoryCellView stareCell) { return false; }
//         public override void OnDrag(IInventoryCellView stareCell, IInventoryCellView effectCell, PointerEventData pointerEventData) { }
//         public override bool OnDrop(IInventoryCellView stareCell, IInventoryCellView effectCell) { return false; }
//         public override void OnDroped(bool isDroped) { }

//         public override void OnCellEnter(IInventoryCellView stareCell, IInventoryCellView effectCell) { }
//         public override void OnCellExit(IInventoryCellView stareCell) { }
//         #endregion
//     }

// }