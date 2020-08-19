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
    public class PlayerInventoryView : InventoryView
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
        #endregion


    }

}