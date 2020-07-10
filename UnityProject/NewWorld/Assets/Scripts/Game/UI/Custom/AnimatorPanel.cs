/************************
	FileName:/Scripts/Game/UI/Custom/AnimatorPanel.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 5:39:08 PM
	Tip:7/9/2020 5:39:08 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class AnimatorPanel : AbstractPanel
    {
        [SerializeField] private Animator m_Anim;


        protected string ANIM_SHOW = "PanelShow";
        protected string ANIM_HIDE = "PanelHide";


        protected override void OnUIInit()
        {
            if (m_Anim == null)
                m_Anim = GetComponent<Animator>();

            //Open--> Show
            //Close--> Close
        }

        protected override void OnOpen()
        {
            if (m_Anim != null)
            {
                m_Anim.Play(ANIM_SHOW);
            }
        }

        public void HidePanel()
        {
            if (m_Anim != null)
            {
                m_Anim.SetTrigger(ANIM_HIDE);
            }
        }

        public void ShowComplete()
        {
            AfterShowComplete();
        }

        public void HideComplete()
        {
            CloseSelfPanel();
            //AfterHideComplete();
        }

        protected virtual void AfterShowComplete() { }
        //protected virtual void AfterHideComplete() { }

    }

}