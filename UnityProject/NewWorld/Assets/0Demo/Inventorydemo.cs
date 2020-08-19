/************************
	FileName:/0Demo/Inventorydemo.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 7:41:36 PM
	Tip:8/18/2020 7:41:36 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Inventorydemo : MonoBehaviour
    {
        [SerializeField] private PlayerInventoryView m_InventoryView;

        void Start()
        {
            m_InventoryView.SetCellCallback(OnCellClick, onCellOptionClick, onCellEnter, onCellExit);
            PlayerInventoryViewData viewData = new PlayerInventoryViewData(10, 10);

            for (int i = 0; i < 10; i++)
            {
                var item = new Equipment(Random.Range(4, 5));
                PlayerInventoryCellData cellData = new PlayerInventoryCellData(item);
                viewData.InsertInventoryItem(viewData.GetInsertableId(cellData).Value, cellData);
            }

            m_InventoryView.Apply(viewData);

            Debug.LogError(viewData.CellData.Length);

        }


        private void OnCellClick(IInventoryCellView cell)
        {

        }

        private void onCellOptionClick(IInventoryCellView cell)
        {

        }

        private void onCellEnter(IInventoryCellView cell)
        {

        }

        private void onCellExit(IInventoryCellView cell)
        {

        }

    }

}