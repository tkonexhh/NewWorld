/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateColorBtn.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 4:16:49 PM
	Tip:7/10/2020 4:16:49 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GameWish.Game
{
    public class CreateSelectColorBtn : MonoBehaviour
    {
        [SerializeField] private Image m_Image;
        [SerializeField] private Button m_BtnBg;

        private Color m_Color;
        private System.Action m_ClickCallback;

        public Color color
        {
            get { return m_Color; }
        }

        private void Awake()
        {
            m_BtnBg.onClick.AddListener(() =>
            {
                if (m_ClickCallback != null)
                {
                    m_ClickCallback.Invoke();
                }
            });
        }

        public void Init(Color color)
        {
            color.a = 1;
            m_Color = color;
            m_Image.color = m_Color;
        }

        public void RegisterListener(System.Action callback)
        {
            m_ClickCallback = callback;
        }
    }

}