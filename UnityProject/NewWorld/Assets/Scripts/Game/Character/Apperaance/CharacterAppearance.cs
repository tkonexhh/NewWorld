/************************
	FileName:/Scripts/Game/Character/CharacterA.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 3:29:42 PM
	Tip:6/23/2020 3:29:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{

    [System.Serializable]
    public class CharacterBone
    {
        public Transform root;
        public Transform[] bones;

        public void Init()
        {
            bones = root.GetComponentsInChildren<Transform>();
        }
    }

    public partial class CharacterAppearance : MonoBehaviour
    {
        // 合并后使用的材质
        public Material material;
        private SkinnedMeshRenderer m_Renderer;

        [Header("外貌信息")]
        public CharacterAppearanceData m_AppearanceData;

        [Header("骨骼信息")]
        public CharacterBone m_Bones;

        [SerializeField] private SkinApperaance m_Hair;
        [SerializeField] private SkinApperaance m_Head;
        [SerializeField] private SkinApperaance m_FacialHair;
        [SerializeField] private SkinApperaance m_Eyebrows;
        [SerializeField] private SkinApperaance m_Torso;
        [SerializeField] private SkinApperaance m_ArmUpperRight;
        [SerializeField] private SkinApperaance m_ArmUpperLeft;
        [SerializeField] private SkinApperaance m_ArmLowerRight;
        [SerializeField] private SkinApperaance m_ArmLowerLeft;
        [SerializeField] private SkinApperaance m_HandRight;
        [SerializeField] private SkinApperaance m_HandLeft;
        [SerializeField] private SkinnedMeshRenderer m_Hips;
        [SerializeField] private SkinApperaance m_LegRight;
        [SerializeField] private SkinApperaance m_LegLeft;

        [Header("HeadCovering")]
        [SerializeField] private SkinApperaance m_HelmetWithoutHead;
        [SerializeField] private SkinApperaance m_HelmetWithHead;
        [SerializeField] private SkinnedMeshRenderer m_HeadAttachment;//头部附属物
        [SerializeField] private SkinnedMeshRenderer m_BackAttachment;
        [SerializeField] private SkinApperaance m_ShoulderRight;
        [SerializeField] private SkinApperaance m_ShoulderLeft;
        [SerializeField] private SkinApperaance m_ElbowRight;
        [SerializeField] private SkinApperaance m_ElbowLeft;
        [SerializeField] private SkinApperaance m_HipsAttachment;
        [SerializeField] private SkinApperaance m_KneeRight;
        [SerializeField] private SkinApperaance m_KneeLeft;
        [SerializeField] private SkinApperaance m_ElfEar;


        private void Start()
        {
            m_Renderer = gameObject.AddMissingComponent<SkinnedMeshRenderer>();
            material = Instantiate(material);

            m_Bones.Init();

            m_Hair.Init(this);
            m_Head.Init(this);
            if (m_FacialHair)
                m_FacialHair.Init(this);

            m_Eyebrows.Init(this);
            m_Torso.Init(this);

            m_ArmUpperRight.Init(this);
            m_ArmUpperLeft.Init(this);
            m_ArmLowerRight.Init(this);
            m_ArmLowerLeft.Init(this);
            m_HandRight.Init(this);
            m_HandLeft.Init(this);
            m_Hips.gameObject.SetActive(true);
            m_LegRight.Init(this);
            m_LegLeft.Init(this);
            m_HelmetWithoutHead.Init(this);
            m_HelmetWithHead.Init(this);


            // m_HeadCovering.gameObject.SetActive(true);
            // m_HeadNoElements.gameObject.SetActive(true);
            // m_HeadAttachment.gameObject.SetActive(true);
            // m_BackAttachment.gameObject.SetActive(true);
            m_ShoulderLeft.Init(this);
            m_ShoulderRight.Init(this);
            m_ElbowRight.Init(this);
            m_ElbowLeft.Init(this);
            m_KneeRight.Init(this);
            m_KneeLeft.Init(this);
            m_ElfEar.Init(this);
            RefeshAppearance();
        }

        void RefeshAppearance()
        {
            SetAppearance(AppearanceSlot.Hair, m_AppearanceData.basicAppearance.hairID);
            SetAppearance(AppearanceSlot.Head, m_AppearanceData.basicAppearance.faceID);
            SetAppearance(AppearanceSlot.FacialHair, m_AppearanceData.basicAppearance.facialHairID);
            SetAppearance(AppearanceSlot.EyeBrows, m_AppearanceData.basicAppearance.eyeBrows);
            SetAppearance(AppearanceSlot.ShoulderRight, m_AppearanceData.shoulderRightID);
            SetAppearance(AppearanceSlot.ShoulderLeft, m_AppearanceData.shoulderLeftID);
            SetAppearance(AppearanceSlot.KneeRight, m_AppearanceData.kneeRightID);
            SetAppearance(AppearanceSlot.KneeLeft, m_AppearanceData.kneeLeftID);
            SetAppearance(AppearanceSlot.ElbowRight, m_AppearanceData.elbowRightID);
            SetAppearance(AppearanceSlot.ElbowLeft, m_AppearanceData.elbowLeftID);
            // SetAppearance(AppearanceSlot.Torso, m_TorsoID);
            // SetAppearance(AppearanceSlot.ArmUpperRight, m_ArmUpperRightID);

            CombineMeshs();
        }

        public void HideSlot(AppearanceSlot slot)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    m_Hair.SetHide(true);
                    break;
                case AppearanceSlot.Head:
                    m_Head.SetHide(true);
                    break;
                case AppearanceSlot.FacialHair:
                    if (m_FacialHair)
                        m_FacialHair.SetHide(true);
                    break;
                case AppearanceSlot.EyeBrows:
                    m_Eyebrows.SetHide(true);
                    break;
                case AppearanceSlot.Ear:
                    m_ElfEar.SetHide(true);
                    break;
                case AppearanceSlot.HelmetWithHead:
                    m_HelmetWithHead.SetHide(true);
                    break;
                case AppearanceSlot.HelmetWithoutHead:
                    m_HelmetWithoutHead.SetHide(true);
                    break;
            }
        }

        public void SetAppearance(AppearanceSlot slot, int id)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    SetHair(id);
                    break;
                case AppearanceSlot.Head:
                    SetHead(id);
                    break;
                case AppearanceSlot.FacialHair:
                    SetFacialHair(id);
                    break;
                case AppearanceSlot.EyeBrows:
                    SetEyebrows(id);
                    break;
                case AppearanceSlot.Torso:
                    SetTorso(id);
                    break;
                case AppearanceSlot.ArmUpperRight:
                    SetArmUpperRight(id);
                    break;
                case AppearanceSlot.ArmUpperLeft:
                    SetArmUpperLeft(id);
                    break;
                case AppearanceSlot.ArmLowerRight:
                    SetArmLowerRight(id);
                    break;
                case AppearanceSlot.ArmLowerLeft:
                    SetArmLowerLeft(id);
                    break;
                case AppearanceSlot.HandRight:
                    SetHandRight(id);
                    break;
                case AppearanceSlot.HandLeft:
                    SetHandLeft(id);
                    break;
                case AppearanceSlot.Hips:
                    SetHips(id);
                    break;
                case AppearanceSlot.LegRight:
                    SetLegRight(id);
                    break;
                case AppearanceSlot.LegLeft:
                    SetLegLeft(id);
                    break;
                case AppearanceSlot.ShoulderRight:
                    SetShoulderRight(id);
                    break;
                case AppearanceSlot.ShoulderLeft:
                    SetShoulderLeft(id);
                    break;
                case AppearanceSlot.ElbowRight:
                    SetElbowRight(id);
                    break;
                case AppearanceSlot.ElbowLeft:
                    SetElbowLeft(id);
                    break;
                case AppearanceSlot.KneeRight:
                    SetKneeRight(id);
                    break;
                case AppearanceSlot.KneeLeft:
                    SetKneeLeft(id);
                    break;
                case AppearanceSlot.Ear:
                    SetElfEar(id);
                    break;
                case AppearanceSlot.HipsAttach:
                    break;
                case AppearanceSlot.HelmetWithoutHead:
                    HideSlot(AppearanceSlot.HelmetWithHead);
                    SetHelmetWithoutHead(id);
                    break;
                case AppearanceSlot.HelmetWithHead:
                    HideSlot(AppearanceSlot.HelmetWithoutHead);
                    SetHelmetWithHead(id);
                    break;
            }

        }

        #region SetPart
        public void SetHair(int id)
        {
            TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.Hair, m_AppearanceData.sex, id);
            m_AppearanceData.basicAppearance.hairID = m_Hair.SetSkin(m_AppearanceData.sex, (int)data.appearance);
        }

        public void SetHead(int id)
        {
            TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.Head, m_AppearanceData.sex, id);
            m_AppearanceData.basicAppearance.faceID = m_Head.SetSkin(m_AppearanceData.sex, (int)data.appearance);
        }

        public void SetFacialHair(int id)
        {
            TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.FacialHair, m_AppearanceData.sex, id);
            m_AppearanceData.basicAppearance.facialHairID = m_FacialHair.SetSkin(m_AppearanceData.sex, (int)data.appearance);
        }

        public void SetEyebrows(int id)
        {
            TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.EyeBrows, m_AppearanceData.sex, id);
            m_AppearanceData.basicAppearance.eyeBrows = m_Eyebrows.SetSkin(m_AppearanceData.sex, (int)data.appearance);
        }

        public void SetTorso(int id)
        {
            m_AppearanceData.torsoID = m_Torso.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetArmUpperRight(int id)
        {
            m_AppearanceData.armUpperRightID = m_ArmUpperRight.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetArmUpperLeft(int id)
        {
            m_AppearanceData.armUpperLeftID = m_ArmUpperLeft.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetArmLowerRight(int id)
        {
            m_AppearanceData.armLowerRightID = m_ArmLowerRight.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetArmLowerLeft(int id)
        {
            m_AppearanceData.armLowerLeftID = m_ArmLowerLeft.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetHandRight(int id)
        {
            m_AppearanceData.handRightID = m_HandRight.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetHandLeft(int id)
        {
            m_AppearanceData.handLeftID = m_HandLeft.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetHips(int id)
        {
            if (m_AppearanceData.hipsID != id)
            {
                var newSkin = CharacterHolder.S.GetHips(m_AppearanceData.sex, id);
                m_Hips.sharedMesh = newSkin.sharedMesh;
                m_AppearanceData.hipsID = id;
            }
        }

        public void SetLegRight(int id)
        {
            m_AppearanceData.legRightID = m_LegRight.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetLegLeft(int id)
        {
            m_AppearanceData.legLeftID = m_LegLeft.SetSkin(m_AppearanceData.sex, id);
        }

        void SetShoulderRight(int id)
        {
            m_AppearanceData.shoulderRightID = m_ShoulderRight.SetSkin(m_AppearanceData.sex, id);
        }

        void SetShoulderLeft(int id)
        {
            m_AppearanceData.shoulderLeftID = m_ShoulderLeft.SetSkin(m_AppearanceData.sex, id);
        }

        void SetElbowRight(int id)
        {
            m_AppearanceData.elbowRightID = m_ElbowRight.SetSkin(m_AppearanceData.sex, id);
        }

        void SetElbowLeft(int id)
        {
            m_AppearanceData.elbowLeftID = m_ElbowLeft.SetSkin(m_AppearanceData.sex, id);
        }

        void SetKneeRight(int id)
        {
            m_AppearanceData.kneeRightID = m_KneeRight.SetSkin(m_AppearanceData.sex, id);
        }

        void SetKneeLeft(int id)
        {
            m_AppearanceData.kneeLeftID = m_KneeLeft.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetElfEar(int id)
        {
            m_AppearanceData.basicAppearance.ear = m_ElfEar.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetHipsAttach(int id)
        {
            m_AppearanceData.hipsAttachID = m_HipsAttachment.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetHelmetWithoutHead(int id)
        {
            m_AppearanceData.helmetWithoutHeadID = m_HelmetWithoutHead.SetSkin(m_AppearanceData.sex, id);
        }

        public void SetHelmetWithHead(int id)
        {
            m_AppearanceData.helmetWithHeadID = m_HelmetWithHead.SetSkin(m_AppearanceData.sex, id);
        }

        #endregion



        public void ApplyAppearance()
        {
            m_Hair.BeforeCombine();
            m_Head.BeforeCombine();
            if (m_FacialHair)
            {
                m_FacialHair.BeforeCombine();
            }
            m_Eyebrows.BeforeCombine();
            m_Torso.BeforeCombine();//.gameObject.SetActive(true);

            m_ArmUpperRight.BeforeCombine();
            m_ArmUpperLeft.BeforeCombine();
            m_ArmLowerRight.BeforeCombine();
            m_ArmLowerLeft.BeforeCombine();
            m_HandRight.BeforeCombine();
            m_HandLeft.BeforeCombine();
            m_Hips.gameObject.SetActive(true);
            m_LegRight.BeforeCombine();
            m_LegLeft.BeforeCombine();
            m_HelmetWithoutHead.BeforeCombine();
            m_HelmetWithHead.BeforeCombine();

            m_HelmetWithHead.gameObject.SetActive(false);
            m_HelmetWithoutHead.gameObject.SetActive(false);
            // m_HeadCovering.gameObject.SetActive(true);
            // m_HeadNoElements.gameObject.SetActive(true);
            // m_HeadAttachment.gameObject.SetActive(true);
            // m_BackAttachment.gameObject.SetActive(true);
            m_ShoulderLeft.BeforeCombine();
            m_ShoulderRight.BeforeCombine();
            m_ElbowRight.BeforeCombine();
            m_ElbowLeft.BeforeCombine();
            m_KneeRight.BeforeCombine();
            m_KneeLeft.BeforeCombine();
            m_ElfEar.BeforeCombine();
            // m_HipsAttachment.gameObject.SetActive(true);
        }


        #region 装备穿戴
        public void Equip(EquipmentAppearance equipment)
        {

        }
        #endregion

        /// <summary>
        /// 带上头盔 ，隐藏面部
        /// </summary>
        private void ToggleShowFace()
        {

        }

        public void CombineMeshs()
        {
            ApplyAppearance();
            MeshHelper.CombineSkinnedMesh(transform.GetChild(0), material, m_Renderer);
        }
    }

}