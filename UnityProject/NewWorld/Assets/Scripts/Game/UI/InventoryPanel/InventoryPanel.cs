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

namespace GameWish.Game
{
    public class InventoryPanel : AbstractPanel
    {
        [SerializeField] private InventoryBag m_Bag;
        [SerializeField] private InventroyItemTipsPage m_ItemTips;


        protected override void OnUIInit()
        {
            base.OnUIInit();
            Debug.LogError("UIInit");

            InventoryMgr.S.AddItem(1);
            InventoryMgr.S.AddItem(1, 10);
            InventoryMgr.S.AddItem(2, 3);
            InventoryMgr.S.AddItem(2, 3);
            InventoryMgr.S.AddItem(3);
            InventoryMgr.S.AddItem(4);
            InventoryMgr.S.AddItem(4);
            InventoryMgr.S.AddItem(4);
            InventoryMgr.S.AddItem(4);


            m_Bag.Init();
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            Debug.LogError("OnOpen");
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