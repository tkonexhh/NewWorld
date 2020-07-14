/************************
	FileName:/GFrameWork/Scripts/Framework/UI/Component/Custom/UListView/Sample/LoopListViewDemo.cs
	CreateAuthor:neo.xu
	CreateTime:7/14/2020 7:54:22 PM
	Tip:7/14/2020 7:54:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Sample
{
    public class LoopListViewDemo : MonoBehaviour
    {
        [SerializeField] private IUListView m_ListView;

        private void Awake()
        {
            m_ListView.SetCellRenderer(CellRenderer);
            m_ListView.SetDataCount(10);
        }

        private void CellRenderer(Transform root, int index)
        {

        }
    }

}