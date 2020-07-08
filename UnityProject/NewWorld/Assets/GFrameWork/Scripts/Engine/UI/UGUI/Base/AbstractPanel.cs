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
    public class AbstractPanel : MonoBehaviour
    {
        private bool m_HasInitUI = false;
        private bool m_HasOpen = false;

        #region life
        protected void Awake()
        {
            if (!m_HasInitUI)
            {
                m_HasInitUI = true;
                OnUIInit();
            }
        }

        protected void OnDestroy()
        {
            ClosePage();
        }
        #endregion


        private void ClosePage()
        {
            if (m_HasOpen)
            {
                m_HasOpen = false;
            }
        }

        private void OpenPage()
        {
            if (!m_HasOpen)
            {
                m_HasOpen = true;
            }
        }

        public void CloseSelfPanel()
        {

        }



        #region 子类需重载
        //初始化面板
        protected virtual void OnUIInit()
        {

        }

        /************************************************************************/
        /* 面板开启进入，可重入界面会多次进入*/
        /************************************************************************/
        protected virtual void OnOpen()
        {

        }

        //面板被关闭的时候进入
        protected virtual void OnClose()
        {

        }

        protected virtual void OnSortingLayerUpdate()
        {

        }

        protected virtual void OnParamUpdate()
        {

        }

        #endregion
    }

}