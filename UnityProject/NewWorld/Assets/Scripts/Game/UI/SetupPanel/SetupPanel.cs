/************************
	FileName:/Scripts/UIScripts/SetupPanel/SetupPanel.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 3:21:15 PM
	Tip:6/23/2020 3:21:15 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;


namespace GameWish.Game
{
    public enum SetupEvent
    {
        ChangeHair = 101001,
        ChangeHead,
    }
    public class SetupPanel : AbstractPanel
    {
        [SerializeField] Button m_BtnHairLeft;
        [SerializeField] Button m_BtnHairRight;
        [SerializeField] Button m_BtnHeadLeft;
        [SerializeField] Button m_BtnHeadRight;

        private int m_HairIndex;
        private int m_HeadIndex;
        private int Max_Hair = 22;
        private int Max_Head = 20;

        protected override void OnUIInit()
        {
            m_BtnHairLeft.onClick.AddListener(() =>
            {
                m_HairIndex--;
                if (m_HairIndex < 0)
                {
                    m_HairIndex = Max_Hair;
                }
                ChangeHair(m_HairIndex);
            });

            m_BtnHairRight.onClick.AddListener(() =>
            {
                m_HairIndex++;
                if (m_HairIndex > Max_Hair)
                {
                    m_HairIndex = 0;
                }
                ChangeHair(m_HairIndex);
            });

            m_BtnHeadLeft.onClick.AddListener(() =>
            {
                m_HeadIndex--;
                if (m_HeadIndex < 0)
                {
                    m_HeadIndex = Max_Head;
                }
                ChangeHead(m_HeadIndex);
            });

            m_BtnHeadRight.onClick.AddListener(() =>
            {
                m_HeadIndex++;
                if (m_HeadIndex > Max_Head)
                {
                    m_HeadIndex = 0;
                }
                ChangeHead(m_HeadIndex);
            });
        }

        private void ChangeHair(int headIndex)
        {
            EventSystem.S.Send(SetupEvent.ChangeHair, headIndex);
        }

        private void ChangeHead(int headIndex)
        {
            EventSystem.S.Send(SetupEvent.ChangeHead, headIndex);
        }
    }

}