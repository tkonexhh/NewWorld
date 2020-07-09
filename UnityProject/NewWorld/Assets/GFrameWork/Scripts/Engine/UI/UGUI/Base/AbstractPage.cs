/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UGUI/Base/AbstractPage.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 11:11:27 AM
	Tip:7/9/2020 11:11:27 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    //面板管理的内部事件
    public enum ViewEvent
    {
        MIN = 0,
        Action_ClosePanel,
        Action_HidePanel,
        Action_ShowPanel,
        OnPanelOpen,
        OnPanelClose,
        OnParamUpdate,
        OnSortingLayerUpdate,
        DumpTest,
    }

    public class AbstractPage : MonoBehaviour
    {
        protected int m_SortingOrder = -1;
        protected int m_PanelID = -1;
        protected int m_UIID;

        private bool m_HasInitUI = false;
        private bool m_HasOpen = false;



        #region setter getter
        public int sortingOrder
        {
            get { return m_SortingOrder; }
        }

        public int panelID
        {
            get { return m_PanelID; }
            set { m_PanelID = value; }
        }

        public int uiID
        {
            get { return m_UIID; }
            set { m_UIID = value; }
        }
        #endregion

        #region life
        protected void Awake()
        {
            if (!m_HasInitUI)
            {
                m_HasInitUI = true;
                RegisterPageEvent();
                OnUIInit();
            }
        }

        protected void OnDestroy()
        {
            if (UIMgr.isApplicationQuit) return;

            ClosePage();

            BeforeDestory();

        }

        protected virtual void BeforeDestory()
        {
        }

        #endregion

        private void RegisterPageEvent()
        {
            if (m_PanelID > 0)
            {
                UIMgr.S.uiEventSystem.Register(m_PanelID, OnPageEvent);
            }
        }

        private void UnRegisterPageEvent()
        {
            if (m_PanelID > 0)
            {
                UIMgr.S.uiEventSystem.UnRegister(m_PanelID, OnPageEvent);
            }
        }

        protected virtual void OnPageEvent(int key, params object[] args)
        {
            if (args == null || args.Length <= 0) return;

            ViewEvent e = (ViewEvent)args[0];
            //默认事件已经处理了
            switch (e)
            {
                case ViewEvent.OnPanelClose:
                    ClosePage();
                    break;
                case ViewEvent.OnPanelOpen:
                    OpenPage();
                    break;
                // case ViewEvent.OnParamUpdate:
                //     ERunner.Run(OnParamUpdate);
                //     break;
                // case ViewEvent.OnSortingLayerUpdate:
                //     ERunner.Run(OnSortingLayerUpdate);
                //     break;
                default:
                    break;
            }
        }





        public void SendViewEvent(ViewEvent key, params object[] args)
        {
            if (m_PanelID > 0)
            {
                UIMgr.S.uiEventSystem.Send(m_PanelID, key, args);
            }
        }


        private void ClosePage()
        {
            if (m_HasOpen)
            {
                m_HasOpen = false;
                UnRegisterPageEvent();
                OnClose();
            }
        }

        private void OpenPage()
        {
            if (!m_HasOpen)
            {
                m_HasOpen = true;
                OnOpen();
            }
        }


        #region 子类需重载
        //初始化面板
        protected virtual void OnUIInit() { }
        //面板开启进入，可重入界面会多次进入
        protected virtual void OnOpen() { }
        //面板被关闭的时候进入
        protected virtual void OnClose() { }
        protected virtual void OnSortingLayerUpdate() { }
        protected virtual void OnParamUpdate() { }
        #endregion
    }

}