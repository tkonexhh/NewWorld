/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateCharacterColorSelect.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 5:14:44 PM
	Tip:7/10/2020 5:14:44 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class CreateCharacterColorSelect : MonoBehaviour
    {
        [SerializeField] private CreateSelectColorBtn m_ColorBtnPrefab;
        [SerializeField] private Transform m_ColorRoot;

        private List<CreateSelectColorBtn> m_ColorBtns = new List<CreateSelectColorBtn>();

        protected virtual List<Color> targetColors
        {
            get
            {
                return null;
            }
        }

        protected virtual AppearanceColor colorSlot
        {
            get
            {
                return AppearanceColor.Hair;
            }
        }

        private void Start()
        {
            CreateColors();
        }

        void CreateColors()
        {
            m_ColorRoot.RemoveAllChild();
            List<Color> colors = targetColors;
            for (int i = 0; i < colors.Count; i++)
            {
                var colorBtn = GameObject.Instantiate<CreateSelectColorBtn>(m_ColorBtnPrefab, m_ColorRoot, false);
                colorBtn.Init(colors[i]);
                colorBtn.RegisterListener(() =>
                {
                    Color color = colorBtn.color;
                    EventSystem.S.Send(SetupEvent.ChangeColor, colorSlot, color);
                });
                m_ColorBtns.Add(colorBtn);
            }
        }
    }

}