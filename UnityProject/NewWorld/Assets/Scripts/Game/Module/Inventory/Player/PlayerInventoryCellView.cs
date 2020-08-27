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
using GFrame;

namespace Game.Logic
{
    public class PlayerInventoryCellView : InventoryCellView
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Sprite m_SpTest;
        [SerializeField] InventoryCellButton button;
        [SerializeField] private Text m_TxtName;
        [SerializeField] private Text m_TxtNum;
        [SerializeField] Graphic highlight;


        protected override IInventoryCellActions ButtonActions => button;
        public PlayerInventoryCellData inventoryCellData { get; protected set; }


        public virtual void SetHighLight(bool value)
        {
            highlight.gameObject.SetActive(value);
        }

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
                inventoryCellData = CellData as PlayerInventoryCellData;
                m_ImgIcon.gameObject.SetActive(true);
                m_ImgIcon.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
                m_ImgIcon.GetComponent<RectTransform>().sizeDelta = GetCellSize();
                // m_ImgIcon.sprite = m_SpTest;
                // m_ImgIcon.SetNativeSize();
                m_TxtName.text = inventoryCellData.item.name;
                if (inventoryCellData.item is StackableItem)
                {
                    m_TxtNum.gameObject.SetActive(true);
                    m_TxtNum.text = (inventoryCellData.item as StackableItem).num.ToString();
                }
                else
                {
                    m_TxtNum.gameObject.SetActive(false);
                }
                m_TxtName.GetComponent<RectTransform>().SetSize(button.GetComponent<RectTransform>().sizeDelta);
            }
        }
        #endregion
    }

}