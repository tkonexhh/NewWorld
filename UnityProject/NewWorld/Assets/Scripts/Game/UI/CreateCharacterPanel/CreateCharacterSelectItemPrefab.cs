/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateCharacterSelectItemPrefab.cs
	CreateAuthor:neo.xu
	CreateTime:1/9/2021 10:43:34 AM
	Tip:1/9/2021 10:43:34 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using DG.Tweening;

namespace Game.Logic
{
    public class CreateCharacterSelectItemPrefab : IUListItemView
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private GameObject m_ObjSelected;
        [SerializeField] private Button m_BtnSelected;

        private TDCharacterAppearance m_Conf;
        private void Awake()
        {
            m_BtnSelected.onClick.AddListener(OnClickSelect);
        }

        public void SetItem(TDCharacterAppearance conf)
        {
            m_Conf = conf;
        }

        private void OnClickSelect()
        {
            if (m_Conf == null)
            {
                return;
            }

            EventSystem.S.Send(SetupEvent.ChangeAppearance, m_Conf.slot, (int)m_Conf.Appearance);
        }
    }

}