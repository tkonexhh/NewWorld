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
    public class AbstractPanel : AbstractPage
    {

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


        protected override void OnPageEvent(int key, params object[] args)
        {
            base.OnPageEvent(key, args);
            ViewEvent e = (ViewEvent)args[0];
            switch (e)
            {
                case ViewEvent.Action_ClosePanel:
                    UIMgr.S.ClosePanel(this);
                    break;
            }
        }


        #region 
        protected virtual void OnPanelOpen(params object[] args) { }
        #endregion
    }

}