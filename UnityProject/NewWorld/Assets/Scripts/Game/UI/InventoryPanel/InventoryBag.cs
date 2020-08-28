/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryBag.cs
	CreateAuthor:neo.xu
	CreateTime:7/14/2020 3:49:02 PM
	Tip:7/14/2020 3:49:02 PM
************************/

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Game.Logic
{
    public class InventoryBag : MonoBehaviour
    {
        [SerializeField] private Toggle m_ToggleEquipment;
        [SerializeField] private Toggle m_ToggleMaterial;
        [SerializeField] private PlayerInventoryView m_InventoryView;
        private List<AbstractItem> m_ShowItems = new List<AbstractItem>();

        public PlayerInventoryView inventoryView => m_InventoryView;

        public void Init()
        {
            m_ToggleEquipment.onValueChanged.AddListener(ShowEquipment);
            m_ToggleMaterial.onValueChanged.AddListener(ShowSupply);

            m_ToggleEquipment.isOn = false;
            m_ToggleEquipment.Select();
        }

        private void ShowEquipment(bool ison)
        {
            if (ison)
            {
                ShowPage(InventoryItemType.Equipment);
            }
        }

        private void ShowSupply(bool ison)
        {
            if (ison)
            {
                ShowPage(InventoryItemType.Supplies);
            }
        }

        private void ShowPage(InventoryItemType type)
        {
            m_ShowItems.Clear();
            switch (type)
            {
                case InventoryItemType.Equipment:
                    m_ShowItems = PlayerMgr.S.inventoryMgr.LstEquipment.Cast<AbstractItem>().ToList();
                    break;
                case InventoryItemType.Supplies:
                    m_ShowItems = PlayerMgr.S.inventoryMgr.LstSupply.Cast<AbstractItem>().ToList();
                    break;
            }
        }

        private void OnCellRenderer(Transform root, int index)
        {
            root.GetComponent<InventoryBagItem>().SetData(m_ShowItems[index]);
        }
    }

}