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
        [SerializeField] protected AbstractInventoryCellView cellPrefab;
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
        public int CellCount => playerInventoryviewData.width * playerInventoryviewData.height;
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

        public override void OnPrePick(IInventoryCellView targetCell)
        {
            if (targetCell?.CellData == null)
            {
                return;
            }


            conditionTransform.sizeDelta = new Vector2(targetCell.DefaultCellSize.x * targetCell.CellData.Width, targetCell.DefaultCellSize.y * targetCell.CellData.Height);
        }
        public override bool OnPick(IInventoryCellView targetCell)
        {
            if (targetCell?.CellData == null)
            {
                return false;
            }


            var id = viewData.GetId(targetCell.CellData);
            if (id.HasValue)
            {
                originalId = id;
                originalCellData = targetCell.CellData;

                itemViews[id.Value].Apply(null);
                viewData.InsertInventoryItem(id.Value, null);
                return true;
            }

            return false;
        }

        public override void OnDrag(IInventoryCellView targetCell, IInventoryCellView effectCell, PointerEventData pointerEventData)
        {
            if (targetCell == null)
            {
                return;
            }

            if (!originalId.HasValue) return;

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
            var pointerLocalPosition = GetLocalPosition(targetCell.RectTransform, pointerEventData.position, pointerEventData.enterEventCamera);
            var anchor = new Vector2(targetCell.DefaultCellSize.x * 0.5f, -targetCell.DefaultCellSize.y * 0.5f);
            var anchoredPosition = pointerLocalPosition + anchor;
            conditionOffset = new Vector3(
                Mathf.Floor(anchoredPosition.x / targetCell.DefaultCellSize.x) * targetCell.DefaultCellSize.x,
                Mathf.Ceil(anchoredPosition.y / targetCell.DefaultCellSize.y) * targetCell.DefaultCellSize.y);

            // cell corner
            var prevCorner = cellCorner;
            cellCorner = GetCorner((new Vector2(anchoredPosition.x % targetCell.DefaultCellSize.x, anchoredPosition.y % targetCell.DefaultCellSize.y) - anchor) * 0.5f);

            // shift the position only even number size
            int width = effectCell.CellData.Width;
            int height = effectCell.CellData.Height;
            var evenNumberOffset = GetEvenNumberOffset(width, height, targetCell.DefaultCellSize.x * 0.5f, targetCell.DefaultCellSize.y * 0.5f);
            conditionTransform.position = targetCell.RectTransform.position + ((conditionOffset + evenNumberOffset) * targetCell.RectTransform.lossyScale.x);

            // update condition
            if (prevCorner != cellCorner)
            {
                UpdateCondition(targetCell, effectCell);
            }
        }
        public override bool OnDrop(IInventoryCellView targetCell, IInventoryCellView effectCell)
        {
            if (!itemViews.Any(item => item == targetCell))
            {
                return false;
            }

            Debug.LogError("PlayerInventoryView OnDrop");

            // check target;
            var index = GetIndex(targetCell, effectCell.CellData, cellCorner);
            Debug.LogError("OnDrop index:" + index);
            if (!index.HasValue || index.Value < 0)
            {
                return false;
            }

            if (!viewData.CheckInsert(index.Value, effectCell.CellData))
            {
                //TODO 检测是否可以合并 交换
                if (targetCell.CellData == null) return false;

                if (targetCell.CellData is PlayerInventoryCellData) //如果目标也是道具栏位
                {
                    int? targetID = viewData.GetId(targetCell.CellData);
                    Debug.LogError(index.Value + "---" + targetID.Value);
                    if (targetCell.CellData.size == effectCell.CellData.size)//大小一致 交换 并且完全盖住的时候
                    {
                        if (originalId.HasValue && originalCellData != null)
                        {
                            itemViews[targetID.Value].Apply(targetCell.CellData);
                            itemViews[originalId.Value].Apply(originalCellData);
                            viewData.InsertInventoryItem(originalId.Value, originalCellData);
                            playerInventoryviewData.ExchangeInventoryItem(targetID.Value, originalId.Value);
                            Debug.LogError("Exchange");
                            //ReApply();
                            originalId = null;
                            originalCellData = null;
                            return true;
                        }
                    }
                }

                if (targetCell.CellData is PlayerEquipmentCellData equipmentCellData)
                {

                }



                //     // check free space in case
                //     if (targetCell.CellData != null && targetCell.CellData is VariableInventorySystem.IStandardCaseCellData caseData)
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

        public override void OnCellEnter(IInventoryCellView targetCell, IInventoryCellView effectCell)
        {
            conditionTransform.gameObject.SetActive(effectCell?.CellData != null);
            if (targetCell is PlayerInventoryCellView)
                (targetCell as PlayerInventoryCellView).SetHighLight(true);
        }
        public override void OnCellExit(IInventoryCellView targetCell)
        {
            conditionTransform.gameObject.SetActive(false);
            condition.color = defaultColor;

            cellCorner = CellCorner.None;

            if (targetCell is PlayerInventoryCellView)
                (targetCell as PlayerInventoryCellView).SetHighLight(false);
        }

        #endregion

        protected virtual int? GetIndex(IInventoryCellView targetCell)
        {
            var index = (int?)null;
            for (var i = 0; i < itemViews.Length; i++)
            {
                if (itemViews[i] == targetCell)
                {
                    index = i;
                }
            }

            return index;
        }

        protected virtual int? GetIndex(IInventoryCellView targetCell, IInventoryCellData effectCellData, CellCorner cellCorner)
        {
            var index = GetIndex(targetCell);

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
                    index -= playerInventoryviewData.width;
                }
            }

            index -= (width - 1) / 2;
            index -= (height - 1) / 2 * playerInventoryviewData.width;
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

        protected virtual void UpdateCondition(IInventoryCellView targetCell, IInventoryCellView effectCell)
        {
            var index = GetIndex(targetCell, effectCell.CellData, cellCorner);
            if ((index.HasValue && viewData.CheckInsert(index.Value, effectCell.CellData)))
            {
                condition.color = positiveColor;
            }
            else
            {
                // /if(targetCell.CellData!=null)
                condition.color = negativeColor;
                // // check free space in case
                // if (targetCell.CellData != null &&
                //     targetCell.CellData is VariableInventorySystem.IStandardCaseCellData caseData &&
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