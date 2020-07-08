/************************
	FileName:/Scripts/Game/UI/MainMenuPanel/MainMentBtn.cs
	CreateAuthor:neo.xu
	CreateTime:7/8/2020 3:27:05 PM
	Tip:7/8/2020 3:27:05 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace GameWish.Game
{
    public class MainMentBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Animator m_Anim;
        [SerializeField] private Button m_Btn;

        private System.Action m_CallBack;

        private void Awake()
        {
            m_Btn.onClick.AddListener(() =>
            {
                if (m_CallBack != null)
                    m_CallBack.Invoke();
            });
        }

        public void SetClickListerner(System.Action callback)
        {
            m_CallBack = callback;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogError("OnPointerDown");
            m_Anim.SetBool("pressed", true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.LogError("OnPointerUp");
            m_Anim.SetBool("pressed", false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.LogError("OnPointerEnter");
            m_Anim.SetBool("selected", true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.LogError("OnPointerExit");
            m_Anim.SetBool("selected", false);
        }

    }

}