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
    public abstract class AbstractInventoryCore : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        protected List<IInventoryView> InventoryViews { get; set; } = new List<IInventoryView>();
        private Dictionary<string, IInventoryView> inventoryViewMap = new Dictionary<string, IInventoryView>();

        protected virtual AbstractInventoryCellView CellPrefab { get; set; }
        protected virtual RectTransform EffectCellParent { get; set; }

        protected IInventoryCellView targetCell;
        protected IInventoryCellView effectCell;

        Vector2 cursorPosition;

        public void Init()
        {
            //TODO 从资源加载
            var go = Instantiate(CellPrefab.gameObject, EffectCellParent);
            effectCell = go.GetComponent<AbstractInventoryCellView>();
            effectCell.RectTransform.gameObject.SetActive(false);
            effectCell.SetSelectable(false);
        }

        public void AddInventoryView(IInventoryView variableInventoryView)
        {
            variableInventoryView.Init();
            InventoryViews.Add(variableInventoryView);
            variableInventoryView.SetCellCallback(OnCellClick, OnCellOptionClick, OnCellEnter, OnCellExit);
        }

        public void RemoveInventoryView(IInventoryView variableInventoryView)
        {
            InventoryViews.Remove(variableInventoryView);
        }

        #region event
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnPrePick(targetCell);
            }

            var stareData = targetCell?.CellData;
            var isHold = InventoryViews.Any(x => x.OnPick(targetCell));

            if (!isHold)
            {
                return;
            }

            effectCell.RectTransform.gameObject.SetActive(true);
            effectCell.Apply(stareData);

            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnPicked(effectCell);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (effectCell?.CellData == null)
            {
                return;
            }
            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnDrag(targetCell, effectCell, eventData);
            }

            RectTransformUtility.ScreenPointToLocalPointInRectangle(EffectCellParent, eventData.position, eventData.enterEventCamera, out cursorPosition);

            effectCell.RectTransform.localPosition = cursorPosition + new Vector2(
                effectCell.DefaultCellSize.x * 0.5f,
                -1 * effectCell.DefaultCellSize.y * 0.5f);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (effectCell.CellData == null)
            {
                return;
            }

            var isRelease = InventoryViews.Any(x => x.OnDrop(targetCell, effectCell));

            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnDroped(isRelease);
            }

            effectCell.RectTransform.gameObject.SetActive(false);
            effectCell.Apply(null);
        }
        #endregion


        protected virtual void OnCellClick(IInventoryCellView cell)
        {
            if (cell.CellData == null)
            {
                return;
            }
            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnCellClick(cell);
            }
        }

        protected virtual void OnCellOptionClick(IInventoryCellView cell)
        {
            if (cell.CellData == null)
            {
                return;
            }

            foreach (var inventoryViews in InventoryViews)
            {
                inventoryViews.OnCellOptionClick(cell);
            }
        }

        protected virtual void OnCellEnter(IInventoryCellView cell)
        {
            targetCell = cell;

            foreach (var inventoryView in InventoryViews)
            {
                inventoryView.OnCellEnter(targetCell, effectCell);
            }
        }

        protected virtual void OnCellExit(IInventoryCellView cell)
        {
            foreach (var inventoryView in InventoryViews)
            {
                inventoryView.OnCellExit(targetCell);
            }

            targetCell = null;
        }

    }

}