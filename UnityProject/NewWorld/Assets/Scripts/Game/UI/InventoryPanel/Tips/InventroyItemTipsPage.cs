/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventroyItemTipsPage.cs
	CreateAuthor:xuhonghua
	CreateTime:8/10/2020 9:55:01 PM
	Tip:8/10/2020 9:55:01 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace GameWish.Game
{
    public class InventroyItemTipsPage : AbstractPage
    {
        [SerializeField] private Image m_ImgTitle;
        [SerializeField] private Text m_TxtName;
        [SerializeField] private Text m_TxtType;

        [SerializeField] private Transform m_MainRoot;
        [SerializeField] private Text m_TxtWeight;

        [SerializeField] private Animator m_Anim;

        public void ShowTips(AbstractItem item)
        {

            Color qualityColor = GetColorByQuality(item.quality);
            m_TxtName.color = qualityColor;
            m_ImgTitle.color = qualityColor * 0.8f;

            m_TxtWeight.text = item.weight.ToString();
            m_TxtName.text = item.name;
            m_TxtType.text = item.type.ToString();
            m_Anim.Play("Show");
        }

        public void HideTips()
        {
            m_Anim.Play("Hide");
        }


        private Color GetColorByQuality(ItemQuality quality)
        {
            switch (quality)
            {
                case ItemQuality.Common:
                    return new Color(1, 1, 1, 1);
                case ItemQuality.UnCommon:
                    return new Color(1, 1, 1, 1);
                case ItemQuality.Rare:
                    return new Color(40 / 255.0f, 144 / 255.0f, 42 / 255.0f, 1);
                case ItemQuality.Lengend:
                    return new Color(130 / 255.0f, 76 / 255.0f, 35 / 255.0f, 1);
                default:
                    return Color.white;
            }
        }
    }

}