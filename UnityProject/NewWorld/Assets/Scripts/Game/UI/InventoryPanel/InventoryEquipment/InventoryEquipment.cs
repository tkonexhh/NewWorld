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

        private List<AbstractItem> m_ShowItems = new List<AbstractItem>();

        public PlayerEquipmentView equipmentView => m_EquipmentView;


        public void Init()
        {
        }
    }

}