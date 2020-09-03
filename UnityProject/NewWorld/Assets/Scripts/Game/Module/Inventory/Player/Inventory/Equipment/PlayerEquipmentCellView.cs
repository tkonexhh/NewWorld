/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryEquipment/Cell/PlayerEquipmentCellView.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 8:00:01 PM
	Tip:9/1/2020 8:00:01 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Logic
{
    public class PlayerEquipmentCellView : InventoryCellView
    {
        [SerializeField] private InventoryEquipSlot m_Slot;
        [SerializeField] RectTransform target;
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtName;
        [SerializeField] InventoryCellButton button;

        protected override IInventoryCellActions ButtonActions => button;
        public PlayerEquipmentCellData equipmentCellData { get; protected set; }
        public InventoryEquipSlot slot => m_Slot;

        #region abstract
        protected override void OnApply()
        {
            base.OnApply();
            if (CellData == null)
            {
                target.gameObject.SetActive(false);
            }
            else
            {
                equipmentCellData = CellData as PlayerEquipmentCellData;

                target.gameObject.SetActive(true);
                m_ImgIcon.color = Color.black;
                m_ImgIcon.GetComponent<RectTransform>().sizeDelta = GetCellSize() * 0.9f;
                m_TxtName.text = equipmentCellData.item.name;
            }
        }
        #endregion 
    }

}