/************************
	FileName:/Scripts/Game/UI/SetupPanel/Setup_ArrowChange.cs
	CreateAuthor:neo.xu
	CreateTime:6/30/2020 5:12:21 PM
	Tip:6/30/2020 5:12:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace GameWish.Game
{
    public class Setup_ArrowChange : MonoBehaviour
    {
        public int maxCount = 0;
        [SerializeField] AppearanceSlot m_Slot;
        [SerializeField] private Text m_TxtName;
        [SerializeField] private Text m_TxtID;
        [SerializeField] private Button m_BtnReduce;
        [SerializeField] private Button m_BtnAdd;

        private int m_CurIndex;
        System.Action<int> callback;

        public int CurIndex
        {
            get { return m_CurIndex; }
        }

        private void Start()
        {
            m_TxtName.text = m_Slot.ToString();
            m_TxtID.text = m_CurIndex.ToString();
            m_BtnReduce.onClick.AddListener(() =>
            {
                m_CurIndex--;
                if (m_CurIndex < 0)
                {
                    m_CurIndex = maxCount - 1;
                }

                CallBack();
            });

            m_BtnAdd.onClick.AddListener(() =>
            {
                m_CurIndex++;
                if (m_CurIndex >= maxCount)
                {
                    m_CurIndex = 0;
                }

                CallBack();
            });
        }

        void CallBack()
        {
            m_TxtID.text = m_CurIndex.ToString();
            EventSystem.S.Send(SetupEvent.ChangeAppearance, m_Slot, m_CurIndex);
        }

        public void SetMaxCount(Sex sex)
        {
            maxCount = TDCharacterAppearanceTable.GetAppearanceCount(m_Slot, sex);
        }
    }

}