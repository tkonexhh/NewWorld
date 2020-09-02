/************************
	FileName:/Scripts/Game/Module/Inventory/Player/PlayerInventoryEffectCell.cs
	CreateAuthor:neo.xu
	CreateTime:9/2/2020 1:51:52 PM
	Tip:9/2/2020 1:51:52 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Logic
{
    public class InventoryEffectCell : InventoryCellView
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtName;
        protected override void OnApply()
        {
            base.OnApply();
            this.ApplySize();

            if (CellData == null)
            {
                m_ImgIcon.gameObject.SetActive(false);
            }
            else
            {
                m_ImgIcon.gameObject.SetActive(true);

                m_ImgIcon.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
                m_ImgIcon.GetComponent<RectTransform>().sizeDelta = GetCellSize() * 0.9f;

                m_TxtName.text = (CellData as PlayerInventoryItemData).item.name;
            }
        }
    }

}