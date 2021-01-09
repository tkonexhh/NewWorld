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
    public enum SetupEvent
    {
        ChangeAppearance = 101001,
        ChangeColor,
    }

    public class CreateCharacterPanel : AbstractPanel
    {

        [SerializeField] private CreateCharacterColorSelect m_HairColor;
        [SerializeField] private CreateCharacterColorSelect m_SkinColor;
        [SerializeField] private CreateCharacterColorSelect m_BodyArtColor;

        [SerializeField] private Button m_BtnCreate;

        [SerializeField] private Image m_ImgSelected;
        [SerializeField] private Toggle[] m_Toggles;
        [SerializeField] private IUListView m_ListView;

        private CreateCharacterAppearanceSlot m_Slot;
        private BasicAppearance m_BasicAppearance;
        private TDCharacterAppearanceData m_SelectAppearanceData;
        private MainMenuScene m_Scene;

        protected override void OnUIInit()
        {
            m_BtnCreate.onClick.AddListener(OnClickCreate);
            m_BasicAppearance = new BasicAppearance();
            m_BasicAppearance.sex = Sex.Male;

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
            m_ListView.SetCellRenderer(OnCellRenderer);
        }

        protected override void OnOpen()
        {
            SelectPage(0);
        }

        public void InitMainScene(MainMenuScene scene)
        {
            m_Scene = scene;
        }

        private void OnCellRenderer(Transform root, int key)
        {
            int curID = -1;
            switch (m_Slot)
            {
                case CreateCharacterAppearanceSlot.Hair:
                    curID = m_BasicAppearance.hairID;
                    break;
                case CreateCharacterAppearanceSlot.Head:
                    curID = m_BasicAppearance.headID;
                    break;
                case CreateCharacterAppearanceSlot.FacialHair:
                    curID = m_BasicAppearance.facialHairID;
                    break;
                case CreateCharacterAppearanceSlot.EyeBrows:
                    curID = m_BasicAppearance.eyeBrows;
                    break;
            }

            root.GetComponent<CreateCharacterSelectItemPrefab>().SetItem(m_SelectAppearanceData.GetAppearanceByIndex(m_BasicAppearance.sex, key));
        }

        private void SelectPage(int index)
        {
            m_Slot = (CreateCharacterAppearanceSlot)index;
            m_Toggles[index].Select();
            m_ImgSelected.transform.DOKill();
            m_ImgSelected.transform.DOLocalMoveX(m_Toggles[index].transform.localPosition.x, 0.2f);
            RefreshListView();
            m_Scene?.cameraControl.LookCreateFace();
        }

        private void RefreshListView()
        {

            switch (m_Slot)
            {
                case CreateCharacterAppearanceSlot.Hair:
                    m_SelectAppearanceData = TDCharacterAppearanceTable.GetAppearanceDataGroup(AppearanceSlot.Hair, m_BasicAppearance.sex);
                    break;
                case CreateCharacterAppearanceSlot.Head:
                    m_SelectAppearanceData = TDCharacterAppearanceTable.GetAppearanceDataGroup(AppearanceSlot.Head, m_BasicAppearance.sex);
                    break;
                case CreateCharacterAppearanceSlot.FacialHair:
                    m_SelectAppearanceData = TDCharacterAppearanceTable.GetAppearanceDataGroup(AppearanceSlot.FacialHair, m_BasicAppearance.sex);
                    break;
                case CreateCharacterAppearanceSlot.EyeBrows:
                    m_SelectAppearanceData = TDCharacterAppearanceTable.GetAppearanceDataGroup(AppearanceSlot.EyeBrows, m_BasicAppearance.sex);
                    break;
            }

            m_ListView.SetDataCount(m_SelectAppearanceData != null ? m_SelectAppearanceData.GetDataCount(m_BasicAppearance.sex) : 0);
        }


        private void OnClickCreate()
        {
            // BasicAppearance basicAppearance = new BasicAppearance();
            // basicAppearance.headID = m_Face.CurIndex;
            // basicAppearance.facialHairID = m_FacialHair.CurIndex;
            // basicAppearance.eyeBrows = m_EyeBrows.CurIndex;

            // basicAppearance.hairColor = CharacterColorConfig.hairColors[m_HairColor.SelectIndex];
            // basicAppearance.skinColor = CharacterColorConfig.skinColors[m_SkinColor.SelectIndex];
            // basicAppearance.bodyArtColor = CharacterColorConfig.bodyColors[m_BodyArtColor.SelectIndex];
            m_Scene?.cameraControl.LookNormal();
            m_Scene?.ResetRoleRotation();
            CloseSelfPanel();
            Timer.S.Post2Really(i =>
            {
                // m_Scene?.
                SceneMgr.S.OpenScene(SceneID.GameScene);
            }, 2);
        }
    }

}