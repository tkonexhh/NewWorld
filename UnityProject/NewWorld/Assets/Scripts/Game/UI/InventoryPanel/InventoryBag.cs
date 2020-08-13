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
        [SerializeField] private IUListView m_ListView;

        private List<AbstractItem> m_ShowItems = new List<AbstractItem>();
        public void Init()
        {
            m_ToggleEquipment.onValueChanged.AddListener(ShowEquipment);
            m_ToggleMaterial.onValueChanged.AddListener(ShowSupply);
            m_ListView.SetCellRenderer(OnCellRenderer);

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
                    m_ShowItems = InventoryMgr.S.LstEquipment.Cast<AbstractItem>().ToList();
                    break;
                case InventoryItemType.Supplies:
                    m_ShowItems = InventoryMgr.S.LstSupply.Cast<AbstractItem>().ToList();
                    break;
            }

            m_ListView.SetDataCount(m_ShowItems.Count);
        }

        private void OnCellRenderer(Transform root, int index)
        {
            root.GetComponent<InventoryBagItem>().SetData(m_ShowItems[index]);
        }
    }

}