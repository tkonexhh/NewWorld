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
        ElfEar,
    }

    public class CharacterAppearance : MonoBehaviour
    {
        // 合并后使用的材质
        public Material material;
        private SkinnedMeshRenderer[] renders;
        private SkinnedMeshRenderer m_Renderer;

        [Header("Sex")]
        [SerializeField] private Sex sex = Sex.Male;//是否是男性
        [SerializeField] private SkinnedMeshRenderer m_Hair;
        [SerializeField] private SkinApperaance m_Head;
        [SerializeField] private SkinnedMeshRenderer m_FacialHair;
        [SerializeField] private SkinApperaance m_Eyebrows;
        [SerializeField] private SkinnedMeshRenderer m_Torso;
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
        [SerializeField] private SkinnedMeshRenderer m_HeadCovering;//帽子
        [SerializeField] private SkinnedMeshRenderer m_HeadNoElements;//头盔
        [SerializeField] private SkinnedMeshRenderer m_HeadAttachment;//头部附属物
        [SerializeField] private SkinnedMeshRenderer m_BackAttachment;
        [SerializeField] private SkinApperaance m_ShoulderRight;
        [SerializeField] private SkinApperaance m_ShoulderLeft;
        [SerializeField] private SkinApperaance m_ElbowRight;
        [SerializeField] private SkinApperaance m_ElbowLeft;
        [SerializeField] private SkinnedMeshRenderer m_HipsAttachment;
        [SerializeField] private SkinApperaance m_KneeRight;
        [SerializeField] private SkinApperaance m_KneeLeft;
        [SerializeField] private SkinApperaance m_ElfEar;


        [Header("基础外貌")]
        public int m_HairID;//0为光头
        public int m_HeadID;
        public int m_FacialHairID;//0为无胡须
        public int m_EyebrowsID;
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
        public int m_EarID;

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
                case AppearanceSlot.ElfEar:
                    SetElfEar(id);
                    break;
            }

        }

        #region SetPart
        public void SetHair(int id)
        {
            if (m_HairID != id)
            {
                var newHair = CharacterHolder.S.GetHair(id);
                m_Hair.sharedMesh = newHair.sharedMesh;

                m_HairID = id;
            }
        }

        public void SetHead(int id)
        {
            m_HeadID = m_Head.SetSkin(sex, id);
        }

        public void SetFacialHair(int id)
        {
            if (m_FacialHairID != id)
            {
                var facialHair = CharacterHolder.S.GetFacialHair(id);
                m_FacialHair.sharedMesh = facialHair.sharedMesh;

                m_FacialHairID = id;
            }
        }

        public void SetEyebrows(int id)
        {
            m_EyebrowsID = m_Eyebrows.SetSkin(sex, id);
        }

        public void SetTorso(int id)
        {

            if (m_TorsoID != id)
            {
                var newSkin = CharacterHolder.S.GetTorso(sex, id);
                m_Torso.sharedMesh = newSkin.sharedMesh;
                m_TorsoID = id;
            }
        }

        public void SetArmUpperRight(int id)
        {
            m_ArmUpperRightID = m_ArmUpperRight.SetSkin(sex, id);
        }

        public void SetArmUpperLeft(int id)
        {
            m_ArmUpperLeftID = m_ArmUpperLeft.SetSkin(sex, id);
        }

        public void SetArmLowerRight(int id)
        {
            m_ArmLowerRightID = m_ArmLowerRight.SetSkin(sex, id);
        }

        public void SetArmLowerLeft(int id)
        {
            m_ArmLowerLeftID = m_ArmLowerLeft.SetSkin(sex, id);
        }

        public void SetHandRight(int id)
        {
            m_HandRightID = m_HandRight.SetSkin(sex, id);
        }

        public void SetHandLeft(int id)
        {
            m_HandLeftID = m_HandLeft.SetSkin(sex, id);
        }

        public void SetHips(int id)
        {
            if (m_HipsID != id)
            {
                var newSkin = CharacterHolder.S.GetHips(sex, id);
                m_Hips.sharedMesh = newSkin.sharedMesh;
                m_HipsID = id;
            }
        }

        public void SetLegRight(int id)
        {
            m_LegRightID = m_LegRight.SetSkin(sex, id);
        }

        public void SetLegLeft(int id)
        {
            m_LegLeftID = m_LegLeft.SetSkin(sex, id);
        }

        void SetShoulderRight(int id)
        {
            m_ShoulderRightID = m_ShoulderRight.SetSkin(sex, id);
        }

        void SetShoulderLeft(int id)
        {
            m_ShoulderLeftID = m_ShoulderLeft.SetSkin(sex, id);
        }

        void SetElbowRight(int id)
        {
            m_ElbowRightID = m_ElbowRight.SetSkin(sex, id);
        }

        void SetElbowLeft(int id)
        {
            m_ElbowLeftID = m_ElbowLeft.SetSkin(sex, id);
        }

        void SetKneeRight(int id)
        {
            m_KneeRightID = m_KneeRight.SetSkin(sex, id);
        }

        void SetKneeLeft(int id)
        {
            m_KneeLeftID = m_KneeLeft.SetSkin(sex, id);
        }

        public void SetElfEar(int id)
        {
            m_EarID = m_ElfEar.SetSkin(sex, id);
        }

        #endregion

        public void ApplyAppearance()
        {
            m_Hair.gameObject.SetActive(true);
            m_Head.gameObject.SetActive(true);
            if (m_FacialHair)
            {
                m_FacialHair.gameObject.SetActive(true);
            }
            m_Eyebrows.gameObject.SetActive(true);
            m_Torso.gameObject.SetActive(true);

            m_ArmUpperRight.gameObject.SetActive(true);
            m_ArmUpperLeft.gameObject.SetActive(true);
            m_ArmLowerRight.gameObject.SetActive(true);
            m_ArmLowerLeft.gameObject.SetActive(true);
            m_HandRight.gameObject.SetActive(true);
            m_HandLeft.gameObject.SetActive(true);
            m_Hips.gameObject.SetActive(true);
            m_LegRight.gameObject.SetActive(true);
            m_LegLeft.gameObject.SetActive(true);

            // m_HeadCovering.gameObject.SetActive(true);
            // m_HeadNoElements.gameObject.SetActive(true);
            // m_HeadAttachment.gameObject.SetActive(true);
            // m_BackAttachment.gameObject.SetActive(true);
            // m_ShoulderRight.gameObject.SetActive(true);
            // m_ShoulderLeft.gameObject.SetActive(true);
            // m_ElbowRight.gameObject.SetActive(true);
            // m_ElbowLeft.gameObject.SetActive(true);
            // m_HipsAttachment.gameObject.SetActive(true);
            // m_KneeRight.gameObject.SetActive(true);
            // m_KneeLeft.gameObject.SetActive(true);
            // m_ElfEar.gameObject.SetActive(true);
        }

        /// <summary>
        /// 带上头盔 ，隐藏面部
        /// </summary>
        private void HideFace()
        {

        }

        public void CombineMeshs()
        {
            ApplyAppearance();
            renders = transform.GetChild(0).GetComponentsInChildren<SkinnedMeshRenderer>();
            // 先记录当前预制件的变换矩阵，合并之后再赋值回来
            Vector3 l_position = transform.position;
            Quaternion l_rotation = transform.rotation;
            Vector3 l_scale = transform.localScale;

            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;

            // 待合并的skinnedrender需要记录的信息
            List<Transform> bones = new List<Transform>();
            List<BoneWeight> boneWeights = new List<BoneWeight>();
            List<CombineInstance> combineInstances = new List<CombineInstance>();

            int length = renders.Length;
            int boneOffset = 0;
            for (int i = 0; i < length; i++)
            {
                SkinnedMeshRenderer oneRender = renders[i];
                Mesh sharedMesh = oneRender.sharedMesh;
                if (sharedMesh == null)
                    continue;
                // 记录骨骼
                bones.AddRange(oneRender.bones);

                // 记录权重

                BoneWeight[] meshBoneweight = sharedMesh.boneWeights;
                for (int j = 0; j < meshBoneweight.Length; ++j)
                {
                    BoneWeight bw = meshBoneweight[j];
                    BoneWeight bWeight = bw;
                    bWeight.boneIndex0 += boneOffset;
                    bWeight.boneIndex1 += boneOffset;
                    bWeight.boneIndex2 += boneOffset;
                    bWeight.boneIndex3 += boneOffset;
                    boneWeights.Add(bWeight);
                }
                // offset是为了合并之后BoneWeight.boneIndex还能正确定向骨骼
                boneOffset += oneRender.bones.Length;
                // 记录网格相关信息
                CombineInstance combineInstance = new CombineInstance();
                Mesh mesh = new Mesh();
                oneRender.BakeMesh(mesh);
                mesh.uv = oneRender.sharedMesh.uv;
                combineInstance.mesh = mesh;
                combineInstance.transform = oneRender.localToWorldMatrix;
                combineInstances.Add(combineInstance);
                oneRender.gameObject.SetActive(false);
            }

            // 将所有的骨骼变换矩阵从自身转换到当前预制件下
            List<Matrix4x4> bindposes = new List<Matrix4x4>();
            int boneLength = bones.Count;
            for (int i = 0; i < boneLength; i++)
            {
                bindposes.Add(bones[i].worldToLocalMatrix * transform.worldToLocalMatrix);
            }

            // 在当前预制下创建新的蒙皮渲染器,设置属性
            SkinnedMeshRenderer combinedSkinnedRenderer = m_Renderer;//gameObject.AddMissingComponent<SkinnedMeshRenderer>();
            Mesh combinedMesh = new Mesh();
            combinedMesh.CombineMeshes(combineInstances.ToArray(), true, true);
            combinedSkinnedRenderer.sharedMesh = combinedMesh;
            combinedSkinnedRenderer.bones = bones.ToArray();
            combinedSkinnedRenderer.sharedMesh.boneWeights = boneWeights.ToArray();
            combinedSkinnedRenderer.sharedMesh.bindposes = bindposes.ToArray();
            combinedSkinnedRenderer.sharedMesh.RecalculateBounds();
            combinedSkinnedRenderer.material = material;

            // 还原自身的变换矩阵
            transform.position = l_position;
            transform.rotation = l_rotation;
            transform.localScale = l_scale;
        }
    }

}