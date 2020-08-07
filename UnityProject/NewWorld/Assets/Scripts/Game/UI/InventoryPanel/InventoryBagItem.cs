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

namespace GameWish.Game
{
    public class InventoryBagItem : IUListItemView
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
            m_TxtName.text = item.GetName();
            m_TxtNum.text = item.num.ToString();
            m_TxtNum.gameObject.SetActive(item.num > 1);
        }

        private void OnClickBg()
        {

        }
    }

}