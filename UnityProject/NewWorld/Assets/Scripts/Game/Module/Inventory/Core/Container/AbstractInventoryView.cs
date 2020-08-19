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


namespace Game.Logic
{
    public class AbstractInventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] protected AbstractInventoryCellView cellPrefab;

        public AbstractInventoryViewData viewData { get; private set; }
        public int CellCount => viewData.width * viewData.height;
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
        #endregion

    }

}