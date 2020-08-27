/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UIMgr_Sorting.cs
	CreateAuthor:neo.xu
	CreateTime:8/27/2020 4:33:03 PM
	Tip:8/27/2020 4:33:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public partial class UIMgr
    {
        private bool m_PanelSortingOrderDirty = false;
        private bool m_IsPanelInfoListChange = false;


        #region Sort

        public void SetPanelSortingOrderDirty()
        {
            m_PanelSortingOrderDirty = true;
        }

        private void ReSortPanel()
        {
            m_IsPanelInfoListChange = false;
            m_PanelSortingOrderDirty = false;

            SortActivePanelInfo();

            //ProcessPanelGameObjectActiveState();

            for (int i = 0; i < m_ActivePanelInfoList.Count; ++i)
            {
                m_ActivePanelInfoList[i].OpenPanel();
                //上面的代码导致内部状态改变
                if (m_IsPanelInfoListChange || m_PanelSortingOrderDirty)
                {
                    ReSortPanel();
                    return;
                }
            }

            //EventSystem.S.Send(EngineEventID.OnPanelUpdate);
        }

        //处理面板隐藏逻辑
        // private void ProcessPanelGameObjectActiveState()
        // {
        //     int mask = (int)m_TopPanelHideMask;
        //     for (int i = m_ActivePanelInfoList.Count - 1; i >= 0; --i)
        //     {
        //         PanelInfo panelInfo = m_ActivePanelInfoList[i];

        //         if (panelInfo.sortIndex < 0)
        //         {
        //             panelInfo.SetActive(false, false);
        //             continue;
        //         }

        //         if (((mask ^ (int)PanelHideMask.Hide) & (int)PanelHideMask.Hide) == 0)
        //         {
        //             panelInfo.SetActive(false, false);
        //         }
        //         else
        //         {
        //             if (((mask ^ (int)PanelHideMask.UnInteractive) & (int)PanelHideMask.UnInteractive) == 0)
        //             {
        //                 panelInfo.SetActive(true, false);
        //             }
        //             else
        //             {
        //                 panelInfo.SetActive(true, true);
        //             }
        //         }

        //         mask |= panelInfo.hideMask;
        //     }
        // }


        private void SortActivePanelInfo()
        {
            m_ActivePanelInfoList.Sort(PanelCompare);

            int index = 0;
            int sortingOrder = 0;
            for (int i = 0; i < m_ActivePanelInfoList.Count; ++i)
            {
                if (m_ActivePanelInfoList[i].abstractPanel != null)
                {
                    m_ActivePanelInfoList[i].SetSiblingIndexAndSortingOrder(index++, sortingOrder);
                    sortingOrder = m_ActivePanelInfoList[i].maxSortingOrder;
                }
            }
        }

        private int PanelCompare(PanelInfo a, PanelInfo b)
        {
            return a.sortingOrder - b.sortingOrder;
        }

        #endregion


        #region Mono生命周期
        private void Update()
        {
            if (m_PanelSortingOrderDirty || m_IsPanelInfoListChange)
            {
                ReSortPanel();
            }
        }


        private void LateUpdate()
        {
            if (m_PanelSortingOrderDirty || m_IsPanelInfoListChange)
            {
                ReSortPanel();
            }
        }
        #endregion
    }

}