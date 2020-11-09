/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UGUI/Base/AbstractPanel.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 1:59:42 PM
	Tip:6/23/2020 1:59:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{

    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractPanel : AbstractPage
    {
        protected int m_SortingOrder = -1;
        protected int m_MaxSortingOrder = -1;
        protected bool m_IsOrderDirty = false;


        public int sortingOrder => m_SortingOrder;
        public int maxSortingOrder
        {
            get { return m_MaxSortingOrder; }
            set { m_MaxSortingOrder = value; }
        }

        protected void Start()
        {
            m_IsOrderDirty = true;
            UIMgr.S.SetPanelSortingOrderDirty();
        }

        public void OnPanelOpen(bool firstOpen, params object[] args)
        {
            SendViewEvent(ViewEvent.OnPanelOpen);
            OnPanelOpen(args);
        }

        public void OnPanelClose(bool destroy)
        {
            SendViewEvent(ViewEvent.OnPanelClose);
        }

        public void CloseSelfPanel()
        {
            SendViewEvent(ViewEvent.Action_ClosePanel);
        }

        public void HideSelfPanel()
        {
            SendViewEvent(ViewEvent.Action_HidePanel);
        }


        protected override void OnPageEvent(int key, params object[] args)
        {
            base.OnPageEvent(key, args);
            ViewEvent e = (ViewEvent)args[0];
            switch (e)
            {
                case ViewEvent.Action_ClosePanel:
                    UIMgr.S.ClosePanel(this);
                    break;
                case ViewEvent.Action_HidePanel:
                    UIMgr.S.HidePanel(this);
                    break;
            }
        }


        #region sorting order
        public void SetSortingOrderDirty()
        {
            m_IsOrderDirty = true;
        }

        public void SetSiblingIndexAndSortingOrder(int siblingIndex, int sortingOrder)
        {
            if (m_IsOrderDirty || m_SortingOrder != sortingOrder)
            {

                m_SortingOrder = sortingOrder;
                transform.SetSiblingIndex(siblingIndex);
                UpdateCanvasSortingOrder();
            }
        }

        protected void UpdateCanvasSortingOrder()
        {
            m_MaxSortingOrder = m_SortingOrder;

            Canvas[] canvas = GetComponentsInChildren<Canvas>(true);

            int offset = 0;
            if (canvas != null)
            {
                for (int i = 0; i < canvas.Length; ++i)
                {

                    canvas[i].overrideSorting = true;
                    canvas[i].pixelPerfect = false;
                    canvas[i].sortingOrder = m_SortingOrder + offset;
                    offset += UIMgr.CANVAS_OFFSET;
                }

                m_MaxSortingOrder += offset;
            }

            SendViewEvent(ViewEvent.OnSortingLayerUpdate);

            m_IsOrderDirty = false;
        }

        #endregion

        #region 子类需重载
        protected virtual void OnPanelOpen(params object[] args) { }
        #endregion



    }

}