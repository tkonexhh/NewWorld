/************************
	FileName:/Scripts/Data/Inventory/Core/View/AbstractInventoryView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 12:33:48 PM
	Tip:8/18/2020 12:33:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class AbstractInventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private AbstractInventoryCellView m_CellPrefab;

        public AbstractInventoryViewData Data { get; private set; }



    }

}