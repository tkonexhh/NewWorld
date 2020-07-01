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


namespace GameWish.Game
{
    public enum Sex
    {
        Female,
        Male,
    }
    /// <summary>
    /// 用于获取装备Mesh等相关信息
    /// </summary>
    public class CharacterHolder : TMonoSingleton<CharacterHolder>
    {
        [Header("HeadCovering")]
        [SerializeField] private Transform m_TrsHeadCoveringBaseHair;//有头发的帽子
        [SerializeField] private Transform m_TrsHeadCoveringNoFacialHair;//没有胡子的帽子
        [SerializeField] private Transform m_TrsHeadCoveringNoHair;//没有头发的帽子

        [SerializeField] private Transform m_TrsHair;

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

        public SkinnedMeshRenderer GetLefRight(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsLegRightMale : m_TrsLegRightFemale;
            return GetChild(root, id);
        }

        public SkinnedMeshRenderer GetLefLeft(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsLegLeftMale : m_TrsLegLeftFemale;
            return GetChild(root, id);
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