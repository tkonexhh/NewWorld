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

namespace Game.Logic
{
    public class CreateCharacterColorSelect : MonoBehaviour
    {
        [SerializeField] private CreateSelectColorBtn m_ColorBtnPrefab;
        [SerializeField] private Transform m_ColorRoot;
        [SerializeField] private Transform m_Selected;

        private List<CreateSelectColorBtn> m_ColorBtns = new List<CreateSelectColorBtn>();
        private int m_SelectIndex = 0;

        protected virtual List<Color> targetColors
        {
            get { return null; }
        }

        protected virtual AppearanceColor colorSlot
        {
            get { return AppearanceColor.Hair; }
        }

        public int SelectIndex
        {
            get { return m_SelectIndex; }
        }


        private void Start()
        {
            CreateColors();
            SetSelect(m_SelectIndex);
        }

        void CreateColors()
        {
            m_ColorRoot.RemoveAllChild();
            List<Color> colors = targetColors;
            for (int i = 0; i < colors.Count; i++)
            {
                var colorBtn = GameObject.Instantiate<CreateSelectColorBtn>(m_ColorBtnPrefab, m_ColorRoot, false);
                colorBtn.Init(colors[i]);
                int index = i;
                colorBtn.RegisterListener(() =>
                {
                    SetSelect(index);

                });
                m_ColorBtns.Add(colorBtn);
            }
        }

        void SetSelect(int index)
        {
            m_SelectIndex = index;
            m_Selected.SetParent(m_ColorBtns[m_SelectIndex].transform);
            m_Selected.localPosition = Vector3.zero;
            m_Selected.SetAsFirstSibling();
            EventSystem.S.Send(SetupEvent.ChangeColor, colorSlot, targetColors[m_SelectIndex]);
        }


    }

}