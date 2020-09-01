/************************
	FileName:/Scripts/Game/Module/Inventory/Player/Equipment/PlayerEquipmentView.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 8:20:25 PM
	Tip:9/1/2020 8:20:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Logic
{
    public class PlayerEquipmentView : AbstractInventoryView
    {
        [SerializeField] private PlayerEquipmentCellView m_Head;




        public override void OnPrePick(IInventoryCellView targetCell) { }
        public override bool OnPick(IInventoryCellView targetCell) { return false; }
        public override void OnDrag(IInventoryCellView targetCell, IInventoryCellView effectCell, PointerEventData pointerEventData) { }
        public override bool OnDrop(IInventoryCellView targetCell, IInventoryCellView effectCell)
        {
            Debug.LogError("PlayerEquipmentView OnDrop" + effectCell.CellData);
            return false;
        }
        public override void OnDroped(bool isDroped)
        {
            Debug.LogError("PlayerEquipmentView OnDroped");
        }
        public override void OnCellEnter(IInventoryCellView targetCell, IInventoryCellView effectCell) { }
        public override void OnCellExit(IInventoryCellView targetCell) { }
    }

}