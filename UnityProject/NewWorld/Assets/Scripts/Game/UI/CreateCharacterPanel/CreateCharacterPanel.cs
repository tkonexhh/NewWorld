/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateCharacterPanel.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 3:15:42 PM
	Tip:7/3/2020 3:15:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;
using DG.Tweening;


namespace Game.Logic
{
    public class CreateCharacterPanel : AbstractPanel
    {
        [SerializeField] private Setup_ArrowChange m_Hair;
        [SerializeField] private Setup_ArrowChange m_Face;
        [SerializeField] private Setup_ArrowChange m_FacialHair;
        [SerializeField] private Setup_ArrowChange m_EyeBrows;

        [SerializeField] private CreateCharacterColorSelect m_HairColor;
        [SerializeField] private CreateCharacterColorSelect m_SkinColor;
        [SerializeField] private CreateCharacterColorSelect m_BodyArtColor;

        [SerializeField] private Button m_BtnCreate;


        [SerializeField] private Image m_ImgSelected;
        [SerializeField] private Toggle[] m_Toggles;

        private Sex m_CurrentSex = Sex.Male;

        protected override void OnUIInit()
        {
            m_BtnCreate.onClick.AddListener(OnClickCreate);
            RefeshSex();

            m_ImgSelected.rectTransform.sizeDelta = m_Toggles[0].rectTransform().sizeDelta;
            m_ImgSelected.transform.localPosition = m_Toggles[0].transform.localPosition;
            for (int i = 0; i < m_Toggles.Length; i++)
            {
                int index = i;
                m_Toggles[i].onValueChanged.AddListener((isOn) =>
                {
                    if (isOn)
                    {
                        SelectPage(index);
                    }
                });
            }
            SelectPage(0);
        }

        private void SelectPage(int index)
        {
            m_Toggles[index].Select();
            m_ImgSelected.transform.DOKill();
            m_ImgSelected.transform.DOLocalMoveX(m_Toggles[index].transform.localPosition.x, 0.2f);
        }

        private void RefeshSex()
        {
            m_Hair.SetMaxCount(m_CurrentSex);
            m_Face.SetMaxCount(m_CurrentSex);
            m_FacialHair.SetMaxCount(m_CurrentSex);
            m_EyeBrows.SetMaxCount(m_CurrentSex);
        }

        private void OnClickCreate()
        {

            BasicAppearance basicAppearance = new BasicAppearance();
            basicAppearance.hairID = m_Hair.CurIndex;
            basicAppearance.headID = m_Face.CurIndex;
            basicAppearance.facialHairID = m_FacialHair.CurIndex;
            basicAppearance.eyeBrows = m_EyeBrows.CurIndex;

            basicAppearance.hairColor = CharacterColorConfig.hairColors[m_HairColor.SelectIndex];
            basicAppearance.skinColor = CharacterColorConfig.skinColors[m_SkinColor.SelectIndex];
            basicAppearance.bodyArtColor = CharacterColorConfig.bodyColors[m_BodyArtColor.SelectIndex];

            SceneMgr.S.OpenScene(SceneID.GameScene);
            CloseSelfPanel();
        }
    }

}