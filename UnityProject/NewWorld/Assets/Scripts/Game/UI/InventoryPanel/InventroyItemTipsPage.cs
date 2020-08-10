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
    public class InventroyItemTipsPage : TMonoSingleton<InventroyItemTipsPage>
    {


        [SerializeField] private Text m_TxtName;
        [SerializeField] private Text m_TxtType;
        [SerializeField] private Text m_TxtTips;
        [SerializeField] private Text m_TxtQuality;

        public void ShowTips(AbstractItem item)
        {
            Debug.LogError("showTips");
            m_TxtName.text = item.name;
            m_TxtType.text = item.type.ToString();
        }

        public void HideTips()
        {

        }
    }

}