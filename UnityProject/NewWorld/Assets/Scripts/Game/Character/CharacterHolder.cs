/************************
	FileName:/Scripts/Game/Character/CharacterHolder.cs
	CreateAuthor:neo.xu
	CreateTime:6/30/2020 2:12:50 PM
	Tip:6/30/2020 2:12:50 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{




    /// <summary>
    /// 用于获取装备Mesh等相关信息
    /// </summary>
    public class CharacterHolder : MonoBehaviour// TMonoSingleton<CharacterHolder>
    {
        [Header("General")]
        [Header("HeadCovering")]
        [SerializeField] private Transform m_TrsHeadCoveringBaseHair;//有头发的帽子
        [SerializeField] private Transform m_TrsHeadCoveringNoFacialHair;//没有胡子的帽子
        [SerializeField] private Transform m_TrsHeadCoveringNoHair;//没有头发的帽子

        [SerializeField] private Transform m_TrsHair;

        [SerializeField] private Transform m_TrsHelmetAttachment;
        [SerializeField] private Transform m_TrsBackAttachment;
        [SerializeField] private Transform m_TrsShoulderAttachmentRight;
        [SerializeField] private Transform m_TrsShoulderAttachmentLeft;
        [SerializeField] private Transform m_TrsElbowAttachmentRight;
        [SerializeField] private Transform m_TrsElbowAttachmentLeft;
        [SerializeField] private Transform m_TrsHipsAttachment;
        [SerializeField] private Transform m_TrsKneeAttachmentRight;
        [SerializeField] private Transform m_TrsKneeAttachmentLeft;
        [SerializeField] private Transform m_TrsElfEar;

        [Header("Male")]
        [SerializeField] private Transform m_TrsHeadMale;
        [SerializeField] private Transform m_TrsEyebrowsMale;
        [SerializeField] private Transform m_TrsFacialHair;
        [SerializeField] private Transform m_TrsTorsoMale;
        [SerializeField] private Transform m_TrsArmUpperRightMale;
        [SerializeField] private Transform m_TrsArmUpperLeftMale;
        [SerializeField] private Transform m_TrsArmLowerRightMale;
        [SerializeField] private Transform m_TrsArmLowerLeftMale;
        [SerializeField] private Transform m_TrsHandRightMale;
        [SerializeField] private Transform m_TrsHandLeftMale;
        [SerializeField] private Transform m_TrsHipsMale;
        [SerializeField] private Transform m_TrsLegRightMale;
        [SerializeField] private Transform m_TrsLegLeftMale;

        [Space(5)]
        [Header("Equip")]
        [SerializeField] private Transform m_TrsHeadNoElementMale;


        [Header("Female")]
        [SerializeField] private Transform m_TrsHeadFemale;
        [SerializeField] private Transform m_TrsEyebrowsFemale;
        [SerializeField] private Transform m_TrsTorsoFemale;
        [SerializeField] private Transform m_TrsArmUpperRightFemale;
        [SerializeField] private Transform m_TrsArmUpperLeftFemale;
        [SerializeField] private Transform m_TrsArmLowerRightFemale;
        [SerializeField] private Transform m_TrsArmLowerLeftFemale;
        [SerializeField] private Transform m_TrsHandRightFemale;
        [SerializeField] private Transform m_TrsHandLeftFemale;
        [SerializeField] private Transform m_TrsHipsFemale;
        [SerializeField] private Transform m_TrsLegRightFemale;
        [SerializeField] private Transform m_TrsLegLeftFemale;

        [Space(5)]
        [Header("Equip")]
        [SerializeField] private Transform m_TrsHeadNoElementFemale;


        public SkinnedMeshRenderer GetHelmetWithHeadMesh(HelmetType type, int id)
        {
            switch (type)
            {
                case HelmetType.Normal:
                    return GetHeadCoveringBaseHair(id);
                case HelmetType.NoFacialHair:
                    return GetHeadCoveringNoFacialHair(id);
                case HelmetType.NoHair:
                    return GetHeadCoveringNoHair(id);
                    // case HelmetType.NoHead:
                    //     return GetHeadNoElement(sex, id);
            }
            return null;
        }

        public SkinnedMeshRenderer GetMeshBySlot(AppearanceSlot slot, Sex sex, int id, params object[] args)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return GetHair(id);
                case AppearanceSlot.Head:
                    return GetHead(sex, id);
                case AppearanceSlot.FacialHair:
                    return GetFacialHair(id);
                case AppearanceSlot.EyeBrows:
                    return GetEyebrows(sex, id);
                case AppearanceSlot.Torso:
                    return GetTorso(sex, id);
                case AppearanceSlot.ArmUpperRight:
                    return GetArmUpperRight(sex, id);
                case AppearanceSlot.ArmUpperLeft:
                    return GetArmUpperLeft(sex, id);
                case AppearanceSlot.ArmLowerRight:
                    return GetArmLowerRight(sex, id);
                case AppearanceSlot.ArmLowerLeft:
                    return GetArmLowerLeft(sex, id);
                case AppearanceSlot.HandRight:
                    return GetHandRight(sex, id);
                case AppearanceSlot.HandLeft:
                    return GetHandLeft(sex, id);
                case AppearanceSlot.Hips:
                    return GetHips(sex, id);
                case AppearanceSlot.LegRight:
                    return GetLegRight(sex, id);
                case AppearanceSlot.LegLeft:
                    return GetLegLeft(sex, id);
                case AppearanceSlot.ShoulderRight:
                    return GetShoulderRight(id);
                case AppearanceSlot.ShoulderLeft:
                    return GetShoulderLeft(id);
                case AppearanceSlot.ElbowRight:
                    return GetElbowRight(id);
                case AppearanceSlot.ElbowLeft:
                    return GetElbowLeft(id);
                case AppearanceSlot.KneeRight:
                    return GetKneeRight(id);
                case AppearanceSlot.KneeLeft:
                    return GetKneeLeft(id);
                case AppearanceSlot.Ear:
                    return GetElfEar(id);
                case AppearanceSlot.HipsAttach:
                    return GetHipsAttachment(id);
                case AppearanceSlot.BackAttach:
                    return GetBackAttachment(id);
                case AppearanceSlot.HelmetWithoutHead:
                    return GetHeadNoElement(sex, id);
                case AppearanceSlot.HelmetWithHead:
                    HelmetType type = (HelmetType)args[0];
                    return GetHelmetWithHeadMesh(type, id);
                default:
                    return null;
            }

        }

        public SkinnedMeshRenderer GetHair(int id)
        {
            return GetChild(m_TrsHair, id);
        }

        public SkinnedMeshRenderer GetHead(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsHeadMale : m_TrsHeadFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetFacialHair(int id)
        {
            return GetChild(m_TrsFacialHair, id);
        }

        public SkinnedMeshRenderer GetEyebrows(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsEyebrowsMale : m_TrsEyebrowsFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetTorso(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsTorsoMale : m_TrsTorsoFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetArmUpperRight(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsArmUpperRightMale : m_TrsArmUpperRightFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetArmUpperLeft(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsArmUpperLeftMale : m_TrsArmUpperLeftFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetArmLowerRight(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsArmLowerRightMale : m_TrsArmLowerRightFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetArmLowerLeft(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsArmLowerLeftMale : m_TrsArmLowerLeftFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetHandRight(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsHandRightMale : m_TrsHandRightFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetHandLeft(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsHandLeftMale : m_TrsHandLeftFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetHips(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsHipsMale : m_TrsHipsFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetLegRight(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsLegRightMale : m_TrsLegRightFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetLegLeft(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsLegLeftMale : m_TrsLegLeftFemale;
            return GetChild(root, id);
        }


        ////////////////

        public SkinnedMeshRenderer GetHeadNoElement(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsHeadNoElementMale : m_TrsHeadNoElementFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetHeadCoveringBaseHair(int id)
        {
            return GetChild(m_TrsHeadCoveringBaseHair, id);
        }
        public SkinnedMeshRenderer GetHeadCoveringNoFacialHair(int id)
        {
            return GetChild(m_TrsHeadCoveringNoFacialHair, id);
        }
        public SkinnedMeshRenderer GetHeadCoveringNoHair(int id)
        {
            return GetChild(m_TrsHeadCoveringNoHair, id);
        }

        public SkinnedMeshRenderer GetHelmetAttachment(int id)
        {
            return GetChild(m_TrsHelmetAttachment, id);
        }

        public SkinnedMeshRenderer GetBackAttachment(int id)
        {
            return GetChild(m_TrsBackAttachment, id);
        }

        public SkinnedMeshRenderer GetShoulderRight(int id)
        {
            return GetChild(m_TrsShoulderAttachmentRight, id);
        }

        public SkinnedMeshRenderer GetShoulderLeft(int id)
        {
            return GetChild(m_TrsShoulderAttachmentLeft, id);
        }

        public SkinnedMeshRenderer GetElbowRight(int id)
        {
            return GetChild(m_TrsElbowAttachmentRight, id);
        }

        public SkinnedMeshRenderer GetElbowLeft(int id)
        {
            return GetChild(m_TrsElbowAttachmentLeft, id);
        }

        public SkinnedMeshRenderer GetHipsAttachment(int id)
        {
            return GetChild(m_TrsHipsAttachment, id);
        }

        public SkinnedMeshRenderer GetKneeRight(int id)
        {
            return GetChild(m_TrsKneeAttachmentRight, id);
        }

        public SkinnedMeshRenderer GetKneeLeft(int id)
        {
            return GetChild(m_TrsKneeAttachmentLeft, id);
        }

        public SkinnedMeshRenderer GetElfEar(int id)
        {
            return GetChild(m_TrsElfEar, id);
        }


        private SkinnedMeshRenderer GetChild(Transform root, int index)
        {
            if (root == null)
                return null;

            var item = root.GetChild(index);
            if (item == null)
            {
                return null;
            }

            return item.GetComponent<SkinnedMeshRenderer>();
        }
    }

}