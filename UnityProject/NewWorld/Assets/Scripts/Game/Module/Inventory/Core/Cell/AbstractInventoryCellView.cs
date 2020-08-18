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
    public abstract class AbstractInventoryCellView : MonoBehaviour, IInventoryCellView
    {
        #region IInventoryCellView
        public RectTransform RectTransform { get; }
        public IInventoryCellData CellData { get; protected set; }
        public virtual Vector2 DefaultCellSize { get; set; }
        public virtual Vector2 MargineSpace { get; set; }

        public void Apply(IInventoryCellData cellData)
        {
            CellData = cellData;
            OnApply();
        }

        protected abstract void OnApply();
        #endregion

    }

}