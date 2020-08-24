/************************
	FileName:/Scripts/Game/Module/Inventory/Core/AbstractInventoryCore.cs
	CreateAuthor:neo.xu
	CreateTime:8/19/2020 1:14:54 PM
	Tip:8/19/2020 1:14:54 PM
************************/


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game.Logic
{
    public class AbstractInventoryCore : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        protected List<IInventoryView> InventoryViews { get; set; } = new List<IInventoryView>();

        protected virtual AbstractInventoryCellView CellPrefab { get; set; }
        protected virtual RectTransform EffectCellParent { get; set; }

        protected IInventoryCellView stareCell;
        protected AbstractInventoryCellView effectCell;

        Vector2 cursorPosition;

        public void Init()
        {
            var go = Instantiate(CellPrefab.gameObject, EffectCellParent);
            effectCell = go.GetComponent<AbstractInventoryCellView>();
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
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnPrePick(stareCell);
            }

            var stareData = stareCell?.CellData;
            var isHold = InventoryViews.Any(x => x.OnPick(stareCell));

            if (!isHold)
            {
                return;
            }

            effectCell.RectTransform.gameObject.SetActive(true);
            effectCell.Apply(stareData);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (effectCell?.CellData == null)
            {
                return;
            }
            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnDrag(stareCell, effectCell, eventData);
            }

            RectTransformUtility.ScreenPointToLocalPointInRectangle(EffectCellParent, eventData.position, eventData.enterEventCamera, out cursorPosition);


            effectCell.RectTransform.localPosition = cursorPosition + new Vector2(
                effectCell.DefaultCellSize.x * 0.5f,
                -1 * effectCell.DefaultCellSize.y * 0.5f);
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
            stareCell = cell;

            foreach (var inventoryView in InventoryViews)
            {
                inventoryView.OnCellEnter(stareCell, effectCell);
            }
        }

        protected virtual void OnCellExit(IInventoryCellView cell)
        {
            foreach (var inventoryView in InventoryViews)
            {
                inventoryView.OnCellExit(stareCell);
            }

            stareCell = null;
        }
    }

}