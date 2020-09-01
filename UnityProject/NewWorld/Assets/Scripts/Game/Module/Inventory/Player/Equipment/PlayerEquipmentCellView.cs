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

        [SerializeField] private Image m_ImgIcon;
        [SerializeField] InventoryCellButton button;

        protected override IInventoryCellActions ButtonActions => button;
        public PlayerEquipmentCellData equipmentCellData { get; protected set; }


        #region abstract
        protected override void OnApply()
        {
            base.OnApply();


            if (CellData == null)
            {
                m_ImgIcon.gameObject.SetActive(false);
            }
            else
            {
                m_ImgIcon.gameObject.SetActive(true);
            }
        }
        #endregion 
    }

}