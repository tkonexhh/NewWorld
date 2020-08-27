/************************
	FileName:/GFrameWork/Scripts/Engine/UI/PanelInfo.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 5:24:54 PM
	Tip:7/7/2020 5:24:54 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace GFrame
{
    public class PanelInfo : IPoolAble
    {

        private enum ePanelState : byte
        {
            UnInit,
            Loading,
            Ready,
        }

        private AbstractPanel m_Panel;
        private int m_PanelID;
        private int m_UIID;
        private int m_SortingOrder = -1;
        private ePanelState m_PanelState = ePanelState.UnInit;

        private Action<AbstractPanel> m_OpenCallback;

        #region setter getter
        public int panelID => m_PanelID;

        public int uiID => m_UIID;

        public int sortingOrder
        {
            set
            {
                m_SortingOrder = value;
            }
            get
            {
                if (m_Panel != null && m_Panel.sortingOrder > 0)
                {
                    return m_Panel.sortingOrder;
                }
                return m_SortingOrder;
            }
        }

        public AbstractPanel abstractPanel
        {
            get { return m_Panel; }
            set
            {
                m_Panel = value;
                if (m_Panel != null)
                {
                    m_Panel.panelID = m_PanelID;
                    m_Panel.uiID = m_UIID;
                }
            }
        }

        public bool isReady => m_Panel != null;
        #endregion

        #region cache
        public bool cacheFlag
        {
            get;
            set;
        }

        public void OnCacheReset()
        {
            m_Panel = null;
            m_PanelState = ePanelState.UnInit;
            m_PanelID = -1;
            m_UIID = -1;
            m_SortingOrder = -1;
            m_OpenCallback = null;
        }
        #endregion

        public void Init(int uiID, int panelID)
        {
            m_UIID = uiID;
            m_PanelID = panelID;
        }

        public void LoadPanelRes()
        {
            if (m_PanelState != ePanelState.UnInit) return;


            m_PanelState = ePanelState.Loading;
            UIData data = UIDataTable.Get(m_UIID);

            if (data == null)
            {
                return;
            }

            GameObject prefab = ResMgr.S.GetRes(data.fullPath).asset as GameObject;
            LoadResSuccess(prefab);
        }

        public void LoadResSuccess(GameObject prefab)
        {
            if (prefab == null)
            {
                Log.e("#Failed To Load PanelRes:" + m_PanelID);
                return;
            }

            //默认先挂到hide下面 不触发awake
            GameObject panelGo = GameObject.Instantiate(prefab, UIMgr.S.uiRoot.hideRoot, false);
            panelGo.SetActive(false);
            AbstractPanel panel = panelGo.GetComponent<AbstractPanel>();

            UIMgr.S.InitPanel(panelGo);
            abstractPanel = panel;

            if (panel == null)
            {
                panelGo.SetActive(true);
                Log.e("Not Find Panel Class In Prefab For Panel:" + m_UIID);
                return;
            }
            m_PanelState = ePanelState.Ready;
        }

        public void SetActive(bool visible)
        {
            if (m_Panel == null) return;

            if (visible)
            {
                if (!m_Panel.gameObject.activeSelf)
                {
                    m_Panel.gameObject.SetActive(true);
                }
                m_Panel.gameObject.SetAllLayer(LayerDefine.LAYER_UI);
            }
            else
            {
                if (m_Panel.gameObject.activeSelf)
                {
                    m_Panel.gameObject.SetActive(false);
                }
            }
        }

        public void AddOpenCallback(Action<AbstractPanel> callback)
        {
            if (callback == null) return;

            m_OpenCallback += callback;
        }

        private void CallOpenCallback()
        {
            if (m_OpenCallback != null)
            {
                m_OpenCallback(m_Panel);
                m_OpenCallback = null;
            }
        }

        public void OpenPanel()
        {
            m_Panel.OnPanelOpen(true);
            CallOpenCallback();
        }

        public void ClosePanel(bool destory)
        {
            if (m_Panel == null) return;

            m_Panel.OnPanelClose(destory);
            if (destory)
            {
                GameObject.Destroy(m_Panel.gameObject);
                m_Panel = null;
            }
            else
            {
                //TODO 改为移动到外部
                m_Panel.gameObject.SetActive(false);
            }
        }
    }

}