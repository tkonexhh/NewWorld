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
        [SerializeField] private InventoryEquipment m_Equipment;
        [SerializeField] private InventroyItemTipsPage m_ItemTips;
        [SerializeField] private AbstractInventoryCore m_InventoryCore;


        protected override void OnUIInit()
        {
            base.OnUIInit();

            m_InventoryCore.Init();
            m_InventoryCore.AddInventoryView(m_Bag.inventoryView);
            m_InventoryCore.AddInventoryView(m_Equipment.equipmentView);


            m_Bag.Init();
            m_Equipment.Init();
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