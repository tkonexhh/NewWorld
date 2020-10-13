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

namespace Game.Logic
{

    [System.Serializable]
    public class CharacterBone
    {
        public Transform root;
        [HideInInspector] public Transform[] bones;

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
        private RoleAppearanceData m_AppearanceData;

        [Header("骨骼信息")]
        [SerializeField] private CharacterBone m_Bones;

        [Header("各个皮肤信息")]
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
        [SerializeField] private SkinApperaance m_Hips;
        [SerializeField] private SkinApperaance m_LegRight;
        [SerializeField] private SkinApperaance m_LegLeft;

        [Header("HeadCovering")]
        [SerializeField] private SkinApperaance m_HelmetWithoutHead;
        [SerializeField] private SkinApperaance m_HelmetWithHead;
        [SerializeField] private SkinnedMeshRenderer m_HeadAttachment;//头部附属物
        [SerializeField] private SkinApperaance m_BackAttachment;
        [SerializeField] private SkinApperaance m_ShoulderRight;
        [SerializeField] private SkinApperaance m_ShoulderLeft;
        [SerializeField] private SkinApperaance m_ElbowRight;
        [SerializeField] private SkinApperaance m_ElbowLeft;
        [SerializeField] private SkinApperaance m_HipsAttachment;
        [SerializeField] private SkinApperaance m_KneeRight;
        [SerializeField] private SkinApperaance m_KneeLeft;
        [SerializeField] private SkinApperaance m_ElfEar;


        private List<SkinApperaance> m_Skins = new List<SkinApperaance>();
        public CharacterBone bone => m_Bones;
        public RoleAppearanceData data => m_AppearanceData;

        private void Awake()
        {
            m_Renderer = gameObject.AddMissingComponent<SkinnedMeshRenderer>();
            material = Instantiate(material);

            m_Bones.Init();

            m_Skins.Add(m_Hair);
            m_Skins.Add(m_Head);
            if (m_FacialHair != null)
            {
                m_Skins.Add(m_FacialHair);
            }
            m_Skins.Add(m_Eyebrows);
            m_Skins.Add(m_Torso);
            m_Skins.Add(m_ArmUpperRight);
            m_Skins.Add(m_ArmUpperLeft);
            m_Skins.Add(m_ArmLowerRight);
            m_Skins.Add(m_ArmLowerLeft);
            m_Skins.Add(m_HandRight);
            m_Skins.Add(m_HandLeft);
            m_Skins.Add(m_Hips);
            m_Skins.Add(m_LegRight);
            m_Skins.Add(m_LegLeft);
            m_Skins.Add(m_HelmetWithoutHead);
            m_Skins.Add(m_HelmetWithHead);
            m_Skins.Add(m_ShoulderLeft);
            m_Skins.Add(m_ShoulderRight);
            m_Skins.Add(m_ElbowRight);
            m_Skins.Add(m_ElbowLeft);
            m_Skins.Add(m_KneeRight);
            m_Skins.Add(m_KneeLeft);
            m_Skins.Add(m_ElfEar);
            m_Skins.Add(m_BackAttachment);

            m_Skins.ForEach(skin => skin.Init(this));

            // m_HeadCovering.gameObject.SetActive(true);
            // m_HeadNoElements.gameObject.SetActive(true);
            // m_HeadAttachment.gameObject.SetActive(true);

            // RefeshAppearance();
            // InitColor();
        }

        void RefeshAppearance()
        {
            SetAppearance(AppearanceSlot.Hair, m_AppearanceData.basicAppearance.hairID);
            SetAppearance(AppearanceSlot.Head, m_AppearanceData.basicAppearance.headID);
            SetAppearance(AppearanceSlot.FacialHair, m_AppearanceData.basicAppearance.facialHairID);
            SetAppearance(AppearanceSlot.EyeBrows, m_AppearanceData.basicAppearance.eyeBrows);
            SetAppearance(AppearanceSlot.Hips, m_AppearanceData.hipsID);
            SetAppearance(AppearanceSlot.ShoulderRight, m_AppearanceData.shoulderRightID);
            SetAppearance(AppearanceSlot.ShoulderLeft, m_AppearanceData.shoulderLeftID);
            SetAppearance(AppearanceSlot.KneeRight, m_AppearanceData.kneeRightID);
            SetAppearance(AppearanceSlot.KneeLeft, m_AppearanceData.kneeLeftID);
            SetAppearance(AppearanceSlot.ElbowRight, m_AppearanceData.elbowRightID);
            SetAppearance(AppearanceSlot.ElbowLeft, m_AppearanceData.elbowLeftID);
            SetAppearance(AppearanceSlot.BackAttach, m_AppearanceData.backAttachID);
            SetAppearance(AppearanceSlot.Ear, m_AppearanceData.basicAppearance.ear);
            SetAppearance(AppearanceSlot.LegLeft, m_AppearanceData.legLeftID);
            SetAppearance(AppearanceSlot.LegRight, m_AppearanceData.legRightID);
            SetAppearance(AppearanceSlot.Torso, m_AppearanceData.torsoID);
            SetAppearance(AppearanceSlot.ArmLowerLeft, m_AppearanceData.armLowerLeftID);
            SetAppearance(AppearanceSlot.ArmLowerRight, m_AppearanceData.armLowerRightID);
            SetAppearance(AppearanceSlot.ArmUpperLeft, m_AppearanceData.armUpperLeftID);
            SetAppearance(AppearanceSlot.ArmUpperRight, m_AppearanceData.armUpperRightID);
            SetAppearance(AppearanceSlot.HelmetWithHead, m_AppearanceData.helmetWithHeadID);
            SetAppearance(AppearanceSlot.HelmetWithoutHead, m_AppearanceData.helmetWithoutHeadID);

            CombineMeshs();
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
                    SetHelmetWithoutHead(id);
                    break;
                case AppearanceSlot.HelmetWithHead:
                    SetHelmetWithHead(id);
                    break;
                case AppearanceSlot.BackAttach:
                    SetBackAttach(id);
                    break;
            }

        }

        #region SetPart
        public void SetHair(int id)
        {
            TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.Hair, m_AppearanceData.sex, id);
            if (data != null)
            {
                m_Hair.SetSkin(m_AppearanceData.sex, (int)data.Appearance);
                m_AppearanceData.basicAppearance.hairID = id;
            }
        }

        public void SetHead(int id)
        {
            if (id == -1)
            {
                m_AppearanceData.basicAppearance.headID = m_Head.SetSkin(m_AppearanceData.sex, -1);
            }
            else
            {
                TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.Head, m_AppearanceData.sex, id);
                if (data != null)
                    m_AppearanceData.basicAppearance.headID = m_Head.SetSkin(m_AppearanceData.sex, (int)data.Appearance);
            }
        }

        public void SetFacialHair(int id)
        {
            TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.FacialHair, m_AppearanceData.sex, id);
            if (data != null)
            {
                m_FacialHair.SetSkin(m_AppearanceData.sex, (int)data.Appearance);
                m_AppearanceData.basicAppearance.facialHairID = id;
            }
        }

        public void SetEyebrows(int id)
        {
            if (id == -1)
            {
                m_AppearanceData.basicAppearance.eyeBrows = m_Eyebrows.SetSkin(m_AppearanceData.sex, -1);
            }
            else
            {
                TDCharacterAppearance data = TDCharacterAppearanceTable.GetAppearanceByIndex(AppearanceSlot.EyeBrows, m_AppearanceData.sex, id);
                if (data != null)
                    m_AppearanceData.basicAppearance.eyeBrows = m_Eyebrows.SetSkin(m_AppearanceData.sex, (int)data.Appearance);
            }
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
            m_AppearanceData.hipsID = m_Hips.SetSkin(m_AppearanceData.sex, id);
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

        public void SetBackAttach(int id)
        {
            m_AppearanceData.backAttachID = m_BackAttachment.SetSkin(m_AppearanceData.sex, id);
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
            m_AppearanceData.helmetWithHeadID = m_HelmetWithHead.SetSkin(m_AppearanceData.sex, id, m_AppearanceData.helmetWithoutHeadType);
        }

        #endregion

        public void SetAppearanceData(RoleAppearanceData data)
        {
            m_AppearanceData = data;
            RefeshAppearance();
            InitColor();
        }


        public void CombineMeshs()
        {
            m_Skins.ForEach(skin => { skin.BeforeCombine(); });
            MeshHelper.CombineSkinnedMesh(transform.GetChild(0), material, m_Renderer);
        }
    }

}