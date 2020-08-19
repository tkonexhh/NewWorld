/************************
	FileName:/Scripts/Game/Module/Inventory/Player/PlayerInventoryCellView.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 1:07:33 PM
	Tip:8/18/2020 1:07:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Logic
{
    public class PlayerInventoryCellView : InventoryCellView
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Sprite m_SpTest;
        [SerializeField] InventoryCellButton button;

        #region abstract
        protected override void OnApply()
        {
            base.OnApply();
            this.rootRectTrans.gameObject.SetActive(CellData != null);
            this.ApplySize();


            if (CellData == null)
            {
                m_ImgIcon.gameObject.SetActive(false);
            }
            else
            {
                m_ImgIcon.gameObject.SetActive(true);

                m_ImgIcon.sprite = m_SpTest;
                m_ImgIcon.SetNativeSize();
                Debug.LogError(m_ImgIcon.sprite);
            }
        }
        #endregion
    }

}