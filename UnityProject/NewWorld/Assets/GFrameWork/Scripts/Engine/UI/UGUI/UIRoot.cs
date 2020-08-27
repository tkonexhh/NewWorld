/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UGUI/UIRoot.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 11:57:13 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GFrame
{

    public class UIRoot : MonoBehaviour
    {

        public const int TOP_PANEL_INDEX = 10000000;

        [SerializeField] private Camera m_UICamera;
        [SerializeField] private Canvas m_UICanvas;
        [SerializeField] private UnityEngine.EventSystems.EventSystem m_EventSystem;
        [SerializeField] private Transform m_PanelRoot;
        [SerializeField] private Transform m_HideRoot;

        public Camera uiCamera => m_UICamera;
        public Canvas uiCanvas => m_UICanvas;
        public UnityEngine.EventSystems.EventSystem eventSystem => m_EventSystem;
        public Transform panelRoot => m_PanelRoot;
        public Transform hideRoot => m_HideRoot;

        private int m_AutoPanelOrder = 0;
        private int m_TopPanelOrder = TOP_PANEL_INDEX;


        public int RequireNextPanelSortingOrder(PanelType type)
        {
            switch (type)
            {
                case PanelType.Auto:
                    m_AutoPanelOrder += 10;
                    return m_AutoPanelOrder;
                case PanelType.Top:
                    m_TopPanelOrder += 10;
                    return m_TopPanelOrder;
                case PanelType.Bottom:
                    return 0;
                default:
                    break;
            }

            return m_AutoPanelOrder;
        }

        public void ReleasePanelSortingOrder(int sortingIndex)
        {
            if (m_AutoPanelOrder == sortingIndex)
            {
                m_AutoPanelOrder -= 10;
            }
            else if (m_TopPanelOrder == sortingIndex)
            {
                m_TopPanelOrder -= 10;
            }
        }
    }

}