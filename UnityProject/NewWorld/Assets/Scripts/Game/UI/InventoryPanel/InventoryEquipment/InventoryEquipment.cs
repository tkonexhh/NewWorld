/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryEquipment/InventoryEquipment.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 7:58:22 PM
	Tip:9/1/2020 7:58:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class InventoryEquipment : MonoBehaviour
    {
        [SerializeField] private PlayerEquipmentView m_EquipmentView;

        private InventoryEquipment_ViewModel m_ViewModel;

        public PlayerEquipmentView equipmentView => m_EquipmentView;


        public void Init()
        {
            m_ViewModel = new InventoryEquipment_ViewModel();
            m_ViewModel.Init();

            m_EquipmentView.Apply(m_ViewModel.viewData);
        }
    }

}