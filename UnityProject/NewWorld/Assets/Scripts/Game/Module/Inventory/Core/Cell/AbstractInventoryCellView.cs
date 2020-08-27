/************************
	FileName:/Scripts/Data/Inventory/Core/Cell/AbstractCellView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:39:39 PM
	Tip:8/18/2020 12:39:39 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public abstract class AbstractInventoryCellView : MonoBehaviour, IInventoryCellView
    {
        protected virtual IInventoryCellActions ButtonActions { get; set; }
        public virtual void SetCellCallback(
                    Action<IInventoryCellView> onPointerClick,
                    Action<IInventoryCellView> onPointerOptionClick,
                    Action<IInventoryCellView> onPointerEnter,
                    Action<IInventoryCellView> onPointerExit,
                    Action<IInventoryCellView> onPointerDown,
                    Action<IInventoryCellView> onPointerUp)
        {
            ButtonActions.SetCallback(
                () => onPointerClick?.Invoke(this),
                () => onPointerOptionClick?.Invoke(this),
                () => onPointerEnter?.Invoke(this),
                () => onPointerExit?.Invoke(this),
                () => onPointerDown?.Invoke(this),
                () => onPointerUp?.Invoke(this));
        }


        #region IInventoryCellView
        public RectTransform RectTransform => (RectTransform)transform;
        public IInventoryCellData CellData { get; protected set; }
        public virtual Vector2 DefaultCellSize { get; set; }
        public virtual Vector2 MargineSpace { get; set; }

        public void Apply(IInventoryCellData cellData)
        {
            CellData = cellData;
            OnApply();
        }

        public abstract void SetSelectable(bool isSelectable);


        #endregion
        protected abstract void OnApply();
    }

}