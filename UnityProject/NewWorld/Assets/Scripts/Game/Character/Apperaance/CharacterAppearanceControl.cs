/************************
	FileName:/Scripts/Game/Character/Apperaance/CharacterAppearanceControl.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:49:23 PM
	Tip:8/7/2020 5:49:23 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class CharacterAppearanceControl : EntityControl
    {
        private CharacterAppearance m_View = null;
        private CharacterAppearanceModel m_Model = null;

        public CharacterAppearance view { get => m_View; }
        public CharacterAppearanceModel model { get => m_Model; }

        public CharacterAppearanceControl(CharacterAppearance view)
        {
            m_View = view;

            m_Model = new CharacterAppearanceModel();
        }



    }

}