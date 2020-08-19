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
        protected virtual IInventoryCellView CellPrefab { get; set; }

        public void Init()
        {

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
    }

}