/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateCharacterPanel.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 3:15:42 PM
	Tip:7/3/2020 3:15:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class CreateCharacterPanel : AbstractPanel
    {
        [SerializeField] private Setup_ArrowChange m_Hair;
        [SerializeField] private Setup_ArrowChange m_Face;
        [SerializeField] private Setup_ArrowChange m_FacialHair;
        [SerializeField] private Setup_ArrowChange m_EyeBrows;

        private Sex m_CurrentSex = Sex.Male;

        protected override void OnUIInit()
        {
            RefeshSex();
        }

        private void RefeshSex()
        {
            m_Hair.SetMaxCount(m_CurrentSex);
            m_Face.SetMaxCount(m_CurrentSex);
            m_FacialHair.SetMaxCount(m_CurrentSex);
            m_EyeBrows.SetMaxCount(m_CurrentSex);
        }
    }

}