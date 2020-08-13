/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryBagItem.cs
	CreateAuthor:neo.xu
	CreateTime:7/14/2020 8:10:10 PM
	Tip:7/14/2020 8:10:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using UnityEngine.EventSystems;

namespace GameWish.Game
{
    public class InventoryBagItem : IUListItemView, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtName;
        [SerializeField] private Text m_TxtNum;
        [SerializeField] private Button m_BtnBg;

        private AbstractItem m_Item;

        private void Awake()
        {
            m_BtnBg.onClick.AddListener(OnClickBg);
        }

        public void SetData(AbstractItem item)
        {
            m_Item = item;
            m_TxtName.text = item.name;
            if (item is StackableItem)
            {
                m_TxtNum.text = (item as StackableItem).num.ToString();
                m_TxtNum.gameObject.SetActive((item as StackableItem).num > 1);
            }
            else
            {
                m_TxtNum.gameObject.SetActive(false);
            }

        }

        private void OnClickBg()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (m_Item == null) return;

            //InventroyItemTipsPage.S.ShowTips(m_Item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //InventroyItemTipsPage.S.HideTips();
        }

        public void OnPointerUp(PointerEventData eventData)
        {

        }
    }

}