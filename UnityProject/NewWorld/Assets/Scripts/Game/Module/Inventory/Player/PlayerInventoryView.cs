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
        [SerializeField] Graphic condition;
        [SerializeField] RectTransform conditionTransform;

        [SerializeField] float holdScrollPadding;
        [SerializeField] float holdScrollRate;

        [SerializeField] Color defaultColor;
        [SerializeField] Color positiveColor;
        [SerializeField] Color negativeColor;

        public PlayerInventoryViewData playerInventoryviewData;

        int? originalId;
        IInventoryCellData originalCellData;
        protected CellCorner cellCorner;
        Vector3 conditionOffset;

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
            if (!playerInventoryviewData.IsDirty)
            {
                return;
            }

            Apply(playerInventoryviewData);
            playerInventoryviewData.IsDirty = false;
        }

        public override void OnPrePick(IInventoryCellView stareCell)
        {
            if (stareCell?.CellData == null)
            {
                return;
            }

            conditionTransform.sizeDelta = new Vector2(stareCell.DefaultCellSize.x * stareCell.CellData.Width, stareCell.DefaultCellSize.y * stareCell.CellData.Height);
        }
        public override bool OnPick(IInventoryCellView stareCell)
        {
            if (stareCell?.CellData == null)
            {
                return false;
            }

            var id = viewData.GetId(stareCell.CellData);
            if (id.HasValue)
            {
                originalId = id;
                originalCellData = stareCell.CellData;

                itemViews[id.Value].Apply(null);
                viewData.InsertInventoryItem(id.Value, null);
                return true;
            }

            return false;
        }
        public override void OnDrag(IInventoryCellView stareCell, IInventoryCellView effectCell, PointerEventData pointerEventData)
        {
            if (stareCell == null)
            {
                return;
            }

            // auto scroll
            var pointerViewportPosition = GetLocalPosition(m_ScrollRect.viewport, pointerEventData.position, pointerEventData.enterEventCamera);

            if (pointerViewportPosition.y < m_ScrollRect.viewport.rect.min.y + holdScrollPadding)
            {
                var scrollValue = m_ScrollRect.verticalNormalizedPosition * m_ScrollRect.viewport.rect.height;
                scrollValue -= holdScrollRate;
                m_ScrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollValue / m_ScrollRect.viewport.rect.height);
            }

            if (pointerViewportPosition.y > m_ScrollRect.viewport.rect.max.y - holdScrollPadding)
            {
                var scrollValue = m_ScrollRect.verticalNormalizedPosition * m_ScrollRect.viewport.rect.height;
                scrollValue += holdScrollRate;
                m_ScrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollValue / m_ScrollRect.viewport.rect.height);
            }

            // depends on anchor
            var pointerLocalPosition = GetLocalPosition(stareCell.RectTransform, pointerEventData.position, pointerEventData.enterEventCamera);
            var anchor = new Vector2(stareCell.DefaultCellSize.x * 0.5f, -stareCell.DefaultCellSize.y * 0.5f);
            var anchoredPosition = pointerLocalPosition + anchor;
            conditionOffset = new Vector3(
                Mathf.Floor(anchoredPosition.x / stareCell.DefaultCellSize.x) * stareCell.DefaultCellSize.x,
                Mathf.Ceil(anchoredPosition.y / stareCell.DefaultCellSize.y) * stareCell.DefaultCellSize.y);

            // cell corner
            var prevCorner = cellCorner;
            cellCorner = GetCorner((new Vector2(anchoredPosition.x % stareCell.DefaultCellSize.x, anchoredPosition.y % stareCell.DefaultCellSize.y) - anchor) * 0.5f);

            // shift the position only even number size
            int width = effectCell.CellData.Width;
            int height = effectCell.CellData.Height;
            var evenNumberOffset = GetEvenNumberOffset(width, height, stareCell.DefaultCellSize.x * 0.5f, stareCell.DefaultCellSize.y * 0.5f);
            conditionTransform.position = stareCell.RectTransform.position + ((conditionOffset + evenNumberOffset) * stareCell.RectTransform.lossyScale.x);

            // update condition
            if (prevCorner != cellCorner)
            {
                UpdateCondition(stareCell, effectCell);
            }
        }
        public override bool OnDrop(IInventoryCellView stareCell, IInventoryCellView effectCell)
        {
            if (!itemViews.Any(item => item == stareCell))
            {
                return false;
            }

            // check target;
            var index = GetIndex(stareCell, effectCell.CellData, cellCorner);
            if (!index.HasValue)
            {
                return false;
            }

            if (!viewData.CheckInsert(index.Value, effectCell.CellData))
            {
                //     // check free space in case
                //     if (stareCell.CellData != null && stareCell.CellData is VariableInventorySystem.IStandardCaseCellData caseData)
                //     {
                //         var id = caseData.CaseData.GetInsertableId(effectCell.CellData);
                //         if (id.HasValue)
                //         {
                //             caseData.CaseData.InsertInventoryItem(id.Value, effectCell.CellData);

                //             originalId = null;
                //             originalCellData = null;
                //             return true;
                //         }
                //     }
                return false;
            }

            // place
            viewData.InsertInventoryItem(index.Value, effectCell.CellData);
            itemViews[index.Value].Apply(effectCell.CellData);

            originalId = null;
            originalCellData = null;
            return true;
        }

        public override void OnDroped(bool isDroped)
        {
            conditionTransform.gameObject.SetActive(false);
            condition.color = defaultColor;

            if (!isDroped && originalId.HasValue)
            {
                // revert
                itemViews[originalId.Value].Apply(originalCellData);
                viewData.InsertInventoryItem(originalId.Value, originalCellData);
            }

            originalId = null;
            originalCellData = null;
        }

        public override void OnCellEnter(IInventoryCellView stareCell, IInventoryCellView effectCell)
        {
            conditionTransform.gameObject.SetActive(effectCell?.CellData != null);
            (stareCell as PlayerInventoryCellView).SetHighLight(false);
        }
        public override void OnCellExit(IInventoryCellView stareCell)
        {
            conditionTransform.gameObject.SetActive(false);
            condition.color = defaultColor;

            cellCorner = CellCorner.None;

            (stareCell as PlayerInventoryCellView).SetHighLight(false);
        }

        #endregion

        protected virtual int? GetIndex(IInventoryCellView stareCell)
        {
            var index = (int?)null;
            for (var i = 0; i < itemViews.Length; i++)
            {
                if (itemViews[i] == stareCell)
                {
                    index = i;
                }
            }

            return index;
        }

        protected virtual int? GetIndex(IInventoryCellView stareCell, IInventoryCellData effectCellData, CellCorner cellCorner)
        {
            var index = GetIndex(stareCell);

            // offset index
            int width = effectCellData.Width;
            int height = effectCellData.Height;
            if (width % 2 == 0)
            {
                if ((cellCorner & CellCorner.Left) != CellCorner.None)
                {
                    index--;
                }
            }

            if (height % 2 == 0)
            {
                if ((cellCorner & CellCorner.Top) != CellCorner.None)
                {
                    index -= viewData.width;
                }
            }

            index -= (width - 1) / 2;
            index -= (height - 1) / 2 * viewData.width;
            return index;
        }

        protected virtual Vector2 GetLocalPosition(RectTransform parent, Vector2 position, Camera camera)
        {
            var localPosition = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, position, camera, out localPosition);
            return localPosition;
        }

        protected virtual CellCorner GetCorner(Vector2 localPosition)
        {
            // depends on pivot
            var corner = CellCorner.None;
            if (localPosition.x < Mathf.Epsilon)
            {
                corner |= CellCorner.Left;
            }

            if (localPosition.x > Mathf.Epsilon)
            {
                corner |= CellCorner.Right;
            }

            if (localPosition.y > Mathf.Epsilon)
            {
                corner |= CellCorner.Top;
            }

            if (localPosition.y < Mathf.Epsilon)
            {
                corner |= CellCorner.Bottom;
            }

            return corner;
        }

        protected virtual Vector3 GetEvenNumberOffset(int width, int height, float widthOffset, float heightOffset)
        {
            var evenNumberOffset = Vector3.zero;

            if (width % 2 == 0)
            {
                if ((cellCorner & CellCorner.Left) != CellCorner.None)
                {
                    evenNumberOffset.x -= widthOffset;
                }

                if ((cellCorner & CellCorner.Right) != CellCorner.None)
                {
                    evenNumberOffset.x += widthOffset;
                }
            }

            if (height % 2 == 0)
            {
                if ((cellCorner & CellCorner.Top) != CellCorner.None)
                {
                    evenNumberOffset.y += heightOffset;
                }

                if ((cellCorner & CellCorner.Bottom) != CellCorner.None)
                {
                    evenNumberOffset.y -= heightOffset;
                }
            }

            return evenNumberOffset;
        }

        protected virtual void UpdateCondition(IInventoryCellView stareCell, IInventoryCellView effectCell)
        {
            var index = GetIndex(stareCell, effectCell.CellData, cellCorner);
            if ((index.HasValue && viewData.CheckInsert(index.Value, effectCell.CellData)))
            {
                condition.color = positiveColor;
            }
            else
            {
                condition.color = negativeColor;
                // // check free space in case
                // if (stareCell.CellData != null &&
                //     stareCell.CellData is VariableInventorySystem.IStandardCaseCellData caseData &&
                //     caseData.CaseData.GetInsertableId(effectCell.CellData).HasValue)
                // {
                //     condition.color = positiveColor;
                // }
                // else
                // {
                //     condition.color = negativeColor;
                // }
            }
        }

    }

}