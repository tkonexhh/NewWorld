/************************
	FileName:/Scripts/Game/Module/Inventory/Base/InventoryCellView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:52:16 PM
	Tip:8/18/2020 12:52:16 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryCellView : AbstractInventoryCellView
    {
        [SerializeField] private Vector2 defaultCellSize;
        [SerializeField] private Vector2 margineSpace;
        [SerializeField] protected RectTransform sizeRoot;

        #region IInventoryCellView

        public override Vector2 DefaultCellSize => defaultCellSize;
        public override Vector2 MargineSpace => margineSpace;
        #endregion

        #region abstract
        protected override void OnApply()
        {
        }

        public override void SetSelectable(bool value)
        {

        }
        #endregion

        #region public func
        public Vector2 GetCellSize()
        {
            var width = ((CellData?.Width ?? 1) * (defaultCellSize.x + margineSpace.x)) - margineSpace.x;
            var height = ((CellData?.Height ?? 1) * (defaultCellSize.y + margineSpace.y)) - margineSpace.y;
            return new Vector2(width, height);
        }

        protected virtual void ApplySize()
        {
            sizeRoot.sizeDelta = GetCellSize();
        }
        #endregion
    }

}