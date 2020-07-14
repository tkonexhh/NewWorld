/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryBag.cs
	CreateAuthor:neo.xu
	CreateTime:7/14/2020 3:49:02 PM
	Tip:7/14/2020 3:49:02 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace GameWish.Game
{
    public class InventoryBag : MonoBehaviour
    {
        [SerializeField] private Toggle m_Toggle;
        [SerializeField] private IUListView m_ListView;

        private void Awake()
        {
            m_Toggle.onValueChanged.AddListener(Test);
            m_ListView.SetCellRenderer(OnCellRenderer);
            m_ListView.SetDataCount(200);
        }

        private void Test(bool ison)
        {
            Debug.LogError(ison);
        }

        private void OnCellRenderer(Transform root, int index)
        {

        }
    }

}