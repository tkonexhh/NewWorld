/************************
	FileName:/Scripts/Data/Inventory/Core/View/AbstractInventoryView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:33:48 PM
	Tip:8/18/2020 12:33:48 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Game.Logic
{
    public abstract class AbstractInventoryView : MonoBehaviour, IInventoryView
    {
        public AbstractInventoryViewData viewData { get; private set; }

        protected IInventoryCellView[] itemViews;

        protected Action<IInventoryCellView> onCellClick;
        protected Action<IInventoryCellView> onCellOptionClick;
        protected Action<IInventoryCellView> onCellEnter;
        protected Action<IInventoryCellView> onCellExit;


        #region IInventoryView

        public virtual void SetCellCallback(
            Action<IInventoryCellView> onCellClick,
            Action<IInventoryCellView> onCellOptionClick,
            Action<IInventoryCellView> onCellEnter,
            Action<IInventoryCellView> onCellExit)
        {
            this.onCellClick = onCellClick;
            this.onCellOptionClick = onCellOptionClick;
            this.onCellEnter = onCellEnter;
            this.onCellExit = onCellExit;
        }

        public virtual void Apply(IInventoryViewData data)
        {
            viewData = (AbstractInventoryViewData)data;
        }
        public virtual void ReApply()
        {

        }

        public abstract void OnPrePick(IInventoryCellView targetCell);
        public abstract bool OnPick(IInventoryCellView targetCell);
        public abstract void OnPicked(IInventoryCellView effectCell);
        public abstract void OnDrag(IInventoryCellView targetCell, IInventoryCellView effectCell, PointerEventData pointerEventData);
        public abstract bool OnDrop(IInventoryCellView targetCell, IInventoryCellView effectCell);
        public abstract void OnDroped(bool isDroped);
        public abstract void OnCellEnter(IInventoryCellView targetCell, IInventoryCellView effectCell);
        public abstract void OnCellExit(IInventoryCellView targetCell);

        #endregion

    }

}