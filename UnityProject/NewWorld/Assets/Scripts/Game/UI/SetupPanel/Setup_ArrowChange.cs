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


namespace GameWish.Game
{
    public class Setup_ArrowChange : MonoBehaviour
    {
        public int maxCount = 0;
        [SerializeField] private int m_CurIndex;
        [SerializeField] private Button m_BtnReduce;
        [SerializeField] private Button m_BtnAdd;

        System.Action<int> callback;

        private void Awake()
        {
            m_BtnReduce.onClick.AddListener(() =>
            {
                m_CurIndex--;
                if (m_CurIndex < 0)
                {
                    m_CurIndex = maxCount;
                }
                if (callback != null)
                    callback.Invoke(m_CurIndex);
            });

            m_BtnAdd.onClick.AddListener(() =>
            {
                m_CurIndex++;
                if (m_CurIndex >= maxCount)
                {
                    m_CurIndex = 0;
                }
                if (callback != null)
                    callback.Invoke(m_CurIndex);
            });
        }

        public void RegisterAction(System.Action<int> callback)
        {
            this.callback = callback;
        }
    }

}