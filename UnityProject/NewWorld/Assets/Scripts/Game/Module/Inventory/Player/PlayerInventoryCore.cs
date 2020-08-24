/************************
	FileName:/Scripts/Game/Module/Inventory/Player/PlayerInventoryCore.cs
	CreateAuthor:neo.xu
	CreateTime:8/24/2020 12:49:49 PM
	Tip:8/24/2020 12:49:49 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerInventoryCore : AbstractInventoryCore
    {
        [SerializeField] private AbstractInventoryCellView cellPrefab;
        [SerializeField] private RectTransform effectCellParent;

        protected override AbstractInventoryCellView CellPrefab => cellPrefab;
        protected override RectTransform EffectCellParent => effectCellParent;
    }

}