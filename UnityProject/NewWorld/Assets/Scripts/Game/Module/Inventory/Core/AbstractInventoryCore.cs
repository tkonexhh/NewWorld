/************************
	FileName:/Scripts/Game/Module/Inventory/Core/AbstractInventoryCore.cs
	CreateAuthor:neo.xu
	CreateTime:8/19/2020 1:14:54 PM
	Tip:8/19/2020 1:14:54 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game.Logic
{
    public class AbstractInventoryCore : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        protected List<IInventoryView> InventoryViews { get; set; } = new List<IInventoryView>();

        protected virtual AbstractInventoryView CellPrefab { get; set; }
        protected virtual RectTransform EffectCellParent { get; set; }

        protected IInventoryCellView effectCell;

        public void Init()
        {
            effectCell = Instantiate(CellPrefab.gameObject, EffectCellParent).GetComponent<IInventoryCellView>();
            effectCell.RectTransform.gameObject.SetActive(false);
            //effectCell.SetSelectable(false);
        }

        public virtual void AddInventoryView(IInventoryView variableInventoryView)
        {
            InventoryViews.Add(variableInventoryView);
            variableInventoryView.SetCellCallback(OnCellClick, OnCellOptionClick, OnCellEnter, OnCellExit);
        }

        public virtual void RemoveInventoryView(IInventoryView variableInventoryView)
        {
            InventoryViews.Remove(variableInventoryView);
        }

        #region event
        public virtual void OnBeginDrag(PointerEventData eventData)
        {

        }

        public virtual void OnDrag(PointerEventData eventData)
        {

        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {

        }
        #endregion


        protected virtual void OnCellClick(IInventoryCellView cell)
        {
        }

        protected virtual void OnCellOptionClick(IInventoryCellView cell)
        {
        }

        protected virtual void OnCellEnter(IInventoryCellView cell)
        {
            // stareCell = cell;

            // foreach (var inventoryView in InventoryViews)
            // {
            //     inventoryView.OnCellEnter(stareCell, effectCell);
            // }
        }

        protected virtual void OnCellExit(IInventoryCellView cell)
        {
            // foreach (var inventoryView in InventoryViews)
            // {
            //     inventoryView.OnCellExit(stareCell);
            // }

            // stareCell = null;
        }
    }

}