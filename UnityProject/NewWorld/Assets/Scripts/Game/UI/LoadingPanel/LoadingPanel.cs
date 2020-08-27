/************************
	FileName:/Scripts/Game/UI/LoadingPanel/LoadingPanel.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 5:05:48 PM
	Tip:7/9/2020 5:05:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class LoadingPanel : AnimatorPanel
    {
        protected bool m_ShowComplete = false;
        private float m_MinStayTime = 3.5f;
        private float m_StayTimer = 0;
        private System.Action m_ShowOverCallback;

        protected override void OnUIInit()
        {
            base.OnUIInit();
        }

        public void RegisterShowOverListener(System.Action callback)
        {
            m_ShowOverCallback = callback;

        }

        protected override void AfterShowComplete()
        {
            m_ShowComplete = true;
            if (m_ShowOverCallback != null)
            {
                m_ShowOverCallback.Invoke();
                m_ShowOverCallback = null;
            }
            StartCoroutine(StartHidePanel());
        }



        IEnumerator StartHidePanel()
        {
            yield return new WaitForSeconds(m_MinStayTime);
            HidePanel();
        }
    }

}