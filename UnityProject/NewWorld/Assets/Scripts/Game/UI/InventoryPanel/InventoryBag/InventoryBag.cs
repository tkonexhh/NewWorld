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
        private InventoryBag_ViewModel m_ViewModel;

        public PlayerInventoryView inventoryView => m_InventoryView;


        public void Init()
        {
            m_ToggleEquipment.onValueChanged.AddListener(ShowEquipment);
            m_ToggleMaterial.onValueChanged.AddListener(ShowSupply);

            m_ToggleEquipment.isOn = false;
            m_ToggleEquipment.Select();

            m_ViewModel = new InventoryBag_ViewModel();
            m_ViewModel.Init();
        }

        private void ShowEquipment(bool ison)
        {
            if (ison)
            {
                ShowPage(InventoryToggleType.Equipment);
            }
        }

        private void ShowSupply(bool ison)
        {
            if (ison)
            {
                ShowPage(InventoryToggleType.Supplies);
            }
        }

        private void ShowPage(InventoryToggleType type)
        {
            m_ShowItems.Clear();
            switch (type)
            {
                case InventoryToggleType.Equipment:
                    m_ShowItems = PlayerMgr.S.inventoryMgr.LstEquipment.Cast<AbstractItem>().ToList();
                    break;
                case InventoryToggleType.Supplies:
                    m_ShowItems = PlayerMgr.S.inventoryMgr.LstSupply.Cast<AbstractItem>().ToList();
                    break;
            }

            inventoryView.Apply(m_ViewModel.GetDataByType(type));
        }

    }

}