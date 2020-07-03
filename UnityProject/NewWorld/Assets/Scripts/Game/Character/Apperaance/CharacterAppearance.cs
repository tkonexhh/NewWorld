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
    public enum AppearanceSlot
    {
        Hair,
        Head,
        FacialHair,//胡子
        EyeBrows,
        Torso,
        ArmUpperRight,
        ArmUpperLeft,
        ArmLowerRight,
        ArmLowerLeft,
        HandRight,
        HandLeft,
        Hips,
        LegRight,
        LegLeft,

        ShoulderRight,
        ShoulderLeft,
        ElbowRight,
        ElbowLeft,
        KneeRight,
        KneeLeft,
        Ear,
        HipsAttach,
        HelmetWithoutHead,
        HelmetWithHead
    }

    [System.Serializable]
    public class BasicAppearance
    {
        public Sex sex;
        public int hairID;//发型
        public int faceID;//面部
        public int facialHairID;//胡子
        public int eyeBrows;//眉毛
        public int ear;
        //一些颜色

    }


    public class CharacterAppearance : MonoBehaviour
    {
        // 合并后使用的材质
        public Material material;
        private SkinnedMeshRenderer m_Renderer;

        [Header("基础外貌")]
        public BasicAppearance m_BasicApperance;

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

        public int m_TorsoID;
        public int m_ArmUpperRightID;
        public int m_ArmUpperLeftID;
        public int m_ArmLowerRightID;
        public int m_ArmLowerLeftID;
        public int m_HandRightID;
        public int m_HandLeftID;
        public int m_HipsID;
        public int m_LegRightID;
        public int m_LegLeftID;
        public int m_ShoulderRightID;
        public int m_ShoulderLeftID;
        public int m_ElbowRightID;
        public int m_ElbowLeftID;
        public int m_KneeRightID;
        public int m_KneeLeftID;
        public int m_HipsAttachID;
        public int m_HelmetWithHeadID;
        public int m_HelmetWithoutHeadID;

        private void Start()
        {
            m_Renderer = gameObject.AddMissingComponent<SkinnedMeshRenderer>();
            material = Instantiate(material);

            RefeshAppearance();
        }

        void RefeshAppearance()
        {
            // SetAppearance(AppearanceSlot.Hair, m_HairID);
            // SetAppearance(AppearanceSlot.Head, m_HeadID);
            // SetAppearance(AppearanceSlot.FacialHair, m_FacialHairID);
            // SetAppearance(AppearanceSlot.EyeBrows, m_EyebrowsID);
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
            m_BasicApperance.hairID = m_Hair.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHead(int id)
        {
            m_BasicApperance.faceID = m_Head.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetFacialHair(int id)
        {
            m_BasicApperance.facialHairID = m_FacialHair.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetEyebrows(int id)
        {
            m_BasicApperance.eyeBrows = m_Eyebrows.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetTorso(int id)
        {
            m_TorsoID = m_Torso.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetArmUpperRight(int id)
        {
            m_ArmUpperRightID = m_ArmUpperRight.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetArmUpperLeft(int id)
        {
            m_ArmUpperLeftID = m_ArmUpperLeft.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetArmLowerRight(int id)
        {
            m_ArmLowerRightID = m_ArmLowerRight.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetArmLowerLeft(int id)
        {
            m_ArmLowerLeftID = m_ArmLowerLeft.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHandRight(int id)
        {
            m_HandRightID = m_HandRight.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHandLeft(int id)
        {
            m_HandLeftID = m_HandLeft.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHips(int id)
        {
            if (m_HipsID != id)
            {
                var newSkin = CharacterHolder.S.GetHips(m_BasicApperance.sex, id);
                m_Hips.sharedMesh = newSkin.sharedMesh;
                m_HipsID = id;
            }
        }

        public void SetLegRight(int id)
        {
            m_LegRightID = m_LegRight.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetLegLeft(int id)
        {
            m_LegLeftID = m_LegLeft.SetSkin(m_BasicApperance.sex, id);
        }

        void SetShoulderRight(int id)
        {
            m_ShoulderRightID = m_ShoulderRight.SetSkin(m_BasicApperance.sex, id);
        }

        void SetShoulderLeft(int id)
        {
            m_ShoulderLeftID = m_ShoulderLeft.SetSkin(m_BasicApperance.sex, id);
        }

        void SetElbowRight(int id)
        {
            m_ElbowRightID = m_ElbowRight.SetSkin(m_BasicApperance.sex, id);
        }

        void SetElbowLeft(int id)
        {
            m_ElbowLeftID = m_ElbowLeft.SetSkin(m_BasicApperance.sex, id);
        }

        void SetKneeRight(int id)
        {
            m_KneeRightID = m_KneeRight.SetSkin(m_BasicApperance.sex, id);
        }

        void SetKneeLeft(int id)
        {
            m_KneeLeftID = m_KneeLeft.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetElfEar(int id)
        {
            m_BasicApperance.ear = m_ElfEar.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHipsAttach(int id)
        {
            m_HipsAttachID = m_HipsAttachment.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHelmetWithoutHead(int id)
        {
            m_HelmetWithoutHeadID = m_HelmetWithoutHead.SetSkin(m_BasicApperance.sex, id);
        }

        public void SetHelmetWithHead(int id)
        {
            m_HelmetWithHeadID = m_HelmetWithHead.SetSkin(m_BasicApperance.sex, id);
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
            m_Torso.gameObject.SetActive(true);

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