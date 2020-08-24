/************************
	FileName:/Scripts/Game/Module/Inventory/PlayerInventoryView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 1:05:12 PM
	Tip:8/18/2020 1:05:12 PM
************************/


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game.Logic
{
    public class PlayerInventoryView : AbstractInventoryView
    {
        [SerializeField] private ScrollRect m_ScrollRect;
        [SerializeField] private GridLayoutGroup m_GridLayoutGroup;

        public PlayerInventoryViewData playerInventoryviewData;



        #region IInventoryView
        public override void Apply(IInventoryViewData data)
        {
            base.Apply(data);
            playerInventoryviewData = (PlayerInventoryViewData)viewData;

            if (itemViews == null || itemViews.Length != CellCount)
            {
                itemViews = new PlayerInventoryCellView[CellCount];

                for (var i = 0; i < CellCount; i++)
                {
                    var itemView = Instantiate(cellPrefab, m_GridLayoutGroup.transform).GetComponent<PlayerInventoryCellView>();
                    itemViews[i] = itemView;
                    itemView.transform.SetAsFirstSibling();
                    itemView.SetCellCallback(
                       onCellClick,
                       onCellOptionClick,
                       onCellEnter,
                       onCellExit,
                       _ => m_ScrollRect.enabled = false,
                       _ => m_ScrollRect.enabled = true);
                    itemView.Apply(null);
                }

                m_GridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                m_GridLayoutGroup.constraintCount = playerInventoryviewData.width;
                m_GridLayoutGroup.cellSize = itemViews.First().DefaultCellSize;
                m_GridLayoutGroup.spacing = itemViews.First().MargineSpace;
            }

            for (var i = 0; i < playerInventoryviewData.CellData.Length; i++)
            {
                itemViews[i].Apply(playerInventoryviewData.CellData[i]);
            }
        }

        public override void ReApply()
        {
            base.ReApply();
        }

        public override void OnPrePick(IInventoryCellView stareCell)
        {

        }
        public override bool OnPick(IInventoryCellView stareCell)
        {
            return false;
        }
        public override void OnDrag(IInventoryCellView stareCell, IInventoryCellView effectCell, PointerEventData pointerEventData)
        {
            Debug.LogError("OnDrag");
            if (stareCell == null)
            {
                return;
            }

            // auto scroll
            // var pointerViewportPosition = GetLocalPosition(m_ScrollRect.viewport, pointerEventData.position, pointerEventData.enterEventCamera);

            // if (pointerViewportPosition.y < m_ScrollRect.viewport.rect.min.y + holdScrollPadding)
            // {
            //     var scrollValue = m_ScrollRect.verticalNormalizedPosition * m_ScrollRect.viewport.rect.height;
            //     scrollValue -= holdScrollRate;
            //     m_ScrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollValue / m_ScrollRect.viewport.rect.height);
            // }

            // if (pointerViewportPosition.y > m_ScrollRect.viewport.rect.max.y - holdScrollPadding)
            // {
            //     var scrollValue = m_ScrollRect.verticalNormalizedPosition * m_ScrollRect.viewport.rect.height;
            //     scrollValue += holdScrollRate;
            //     scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollValue / scrollRect.viewport.rect.height);
            // }

            // // depends on anchor
            // var pointerLocalPosition = GetLocalPosition(stareCell.RectTransform, pointerEventData.position, pointerEventData.enterEventCamera);
            // var anchor = new Vector2(stareCell.DefaultCellSize.x * 0.5f, -stareCell.DefaultCellSize.y * 0.5f);
            // var anchoredPosition = pointerLocalPosition + anchor;
            // conditionOffset = new Vector3(
            //     Mathf.Floor(anchoredPosition.x / stareCell.DefaultCellSize.x) * stareCell.DefaultCellSize.x,
            //     Mathf.Ceil(anchoredPosition.y / stareCell.DefaultCellSize.y) * stareCell.DefaultCellSize.y);

            // // cell corner
            // var prevCorner = cellCorner;
            // cellCorner = GetCorner((new Vector2(anchoredPosition.x % stareCell.DefaultCellSize.x, anchoredPosition.y % stareCell.DefaultCellSize.y) - anchor) * 0.5f);

            // // shift the position only even number size
            // var (width, height) = GetRotateSize(effectCell.CellData);
            // var evenNumberOffset = GetEvenNumberOffset(width, height, stareCell.DefaultCellSize.x * 0.5f, stareCell.DefaultCellSize.y * 0.5f);
            // conditionTransform.position = stareCell.RectTransform.position + ((conditionOffset + evenNumberOffset) * stareCell.RectTransform.lossyScale.x);

            // // update condition
            // if (prevCorner != cellCorner)
            // {
            //     UpdateCondition(stareCell, effectCell);
            // }
        }
        public override bool OnDrop(IInventoryCellView stareCell, IInventoryCellView effectCell)
        {
            return false;
        }
        public override void OnDroped(bool isDroped)
        {

        }

        public override void OnCellEnter(IInventoryCellView stareCell, IInventoryCellView effectCell)
        {
            Debug.LogError("PlayerInventoryView:OnCellEnter");
            (stareCell as PlayerInventoryCellView).SetHighLight(false);
        }
        public override void OnCellExit(IInventoryCellView stareCell)
        {
            Debug.LogError("PlayerInventoryView:OnCellExit");
            (stareCell as PlayerInventoryCellView).SetHighLight(false);
        }

        #endregion


    }

}