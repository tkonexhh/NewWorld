/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryPanel.cs
	CreateAuthor:neo.xu
	CreateTime:7/13/2020 11:39:18 AM
	Tip:7/13/2020 11:39:18 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class InventoryPanel : AbstractPanel
    {
        [SerializeField] private InventoryBag m_Bag;
        [SerializeField] private InventroyItemTipsPage m_ItemTips;

        [SerializeField] private AbstractInventoryCore m_InventoryCore;


        private InventoryPanel_ViewModel m_ViewModel;

        protected override void OnUIInit()
        {
            base.OnUIInit();

            m_InventoryCore.Init();
            m_InventoryCore.AddInventoryView(m_Bag.inventoryView);

            m_ViewModel = new InventoryPanel_ViewModel();
            m_ViewModel.Init();

            PlayerMgr.S.inventoryMgr.AddItem(1);
            PlayerMgr.S.inventoryMgr.AddItem(1, 10);
            PlayerMgr.S.inventoryMgr.AddItem(2, 3);
            PlayerMgr.S.inventoryMgr.AddItem(2, 3);
            PlayerMgr.S.inventoryMgr.AddItem(3);
            PlayerMgr.S.inventoryMgr.AddItem(4);
            PlayerMgr.S.inventoryMgr.AddItem(4);
            PlayerMgr.S.inventoryMgr.AddItem(4);
            PlayerMgr.S.inventoryMgr.AddItem(4);

            PlayerInventoryViewData viewData = new PlayerInventoryViewData(12, 12);

            var supplys = PlayerMgr.S.inventoryMgr.LstSupply;
            supplys.ForEach((item) =>
            {
                //Debug.LogError(item.name);
                PlayerInventoryCellData cellData = new PlayerInventoryCellData(item);
                int insertID = viewData.GetInsertableId(cellData).Value;
                Debug.LogError(insertID);
                viewData.InsertInventoryItem(insertID, cellData);
            });

            var equips = PlayerMgr.S.inventoryMgr.LstEquipment;
            equips.ForEach((item) =>
            {
                //Debug.LogError(item.name);
                PlayerInventoryCellData cellData = new PlayerInventoryCellData(item);
                int insertID = viewData.GetInsertableId(cellData).Value;
                Debug.LogError(insertID);
                viewData.InsertInventoryItem(insertID, cellData);
            });

            m_Bag.inventoryView.Apply(viewData);



            m_Bag.Init();
        }

        protected override void OnOpen()
        {
            base.OnOpen();
        }


        public void ShowItemTip(AbstractItem item)
        {
            m_ItemTips.ShowTips(item);
        }

        public void HideItemTip()
        {
            m_ItemTips.HideTips();
        }
    }

}