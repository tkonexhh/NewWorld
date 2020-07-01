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
        EyeBrow,

        Torso,
        ArmUpperRight,
        ArmUpperLeft,
        ArmLowerRight,
        ArmLowerLeft,
        Hips,

        Hand,
        Leg
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
        [SerializeField] private SkinnedMeshRenderer m_Head;
        [SerializeField] private SkinnedMeshRenderer m_FacialHair;
        [SerializeField] private SkinnedMeshRenderer m_Eyebrows;
        [SerializeField] private SkinnedMeshRenderer m_Torso;
        [SerializeField] private SkinnedMeshRenderer m_ArmUpperRight;
        [SerializeField] private SkinnedMeshRenderer m_ArmUpperLeft;
        [SerializeField] private SkinnedMeshRenderer m_ArmLowerRight;
        [SerializeField] private SkinnedMeshRenderer m_ArmLowerLeft;
        [SerializeField] private SkinnedMeshRenderer m_HandRight;
        [SerializeField] private SkinnedMeshRenderer m_HandLeft;
        [SerializeField] private SkinnedMeshRenderer m_Hips;
        [SerializeField] private SkinnedMeshRenderer m_LegRight;
        [SerializeField] private SkinnedMeshRenderer m_LegLeft;

        [Header("Head Attachment")]//头盔
        [Header("Attachment")]
        [SerializeField] private Transform m_HeadAttachmentRoot;
        [Header("Head Back Attachment")]//头盔装饰
        [SerializeField] private Transform m_HeadBackAttachmentRoot;
        [Header("Back Attachment")]
        [SerializeField] private Transform m_BackAttachmentRoot;
        [Header("Shoulder Right Attachment")]
        [SerializeField] private Transform m_ShoulderRightAttachmentRoot;
        [Header("Shoulder Left Attachment")]
        [SerializeField] private Transform m_ShoulderLeftAttachmentRoot;
        [Header("Elbow Right Attachment")]
        [SerializeField] private Transform m_ElbowRightAttachmentRoot;
        [Header("Elbow Left Attachment")]
        [SerializeField] private Transform m_ElbowLeftAttachmentRoot;
        [Header("Hips Attachment")]
        [SerializeField] private Transform m_HipsAttachmentRoot;
        [Header("Knee Right Attachment")]
        [SerializeField] private Transform m_KneeRightAttachmentRoot;
        [Header("Knee Left Attachment")]
        [SerializeField] private Transform m_KneeLeftAttachmentRoot;


        [Header("基础外貌")]
        public int m_CurHairIndex;
        public int m_CurHeadIndex;
        public int m_FacialID;
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

        private void Start()
        {
            m_Renderer = gameObject.AddMissingComponent<SkinnedMeshRenderer>();
            material = Instantiate(material);

            CombineMeshs();
        }

        public void SetAppearance(AppearanceSlot slot, int id)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    SetHair(id);
                    break;
            }
        }

        #region SetPart
        public void SetHair(int id)
        {
            if (m_CurHairIndex != id)
            {
                var newHair = CharacterHolder.S.GetHair(id);
                Debug.LogError(newHair.sharedMesh.name);
                m_Hair.sharedMesh = newHair.sharedMesh;
                m_CurHairIndex = id;
            }
            CombineMeshs();
        }

        public void SetHead(int id)
        {
            if (m_CurHeadIndex != id)
            {
                var head = CharacterHolder.S.GetHead(sex, id);
                m_Head.sharedMesh = head.sharedMesh;
                m_CurHeadIndex = id;
            }
            CombineMeshs();
        }

        public void SetFacialHair(int id)
        {
            if (m_FacialID != id)
            {
                var facialHair = CharacterHolder.S.GetFacialHair(id);
                m_FacialHair.sharedMesh = facialHair.sharedMesh;
                m_FacialID = id;
            }
            CombineMeshs();
        }

        public void SetEyebrows(int id)
        {
            if (m_EyebrowsID != id)
            {
                var newSkin = CharacterHolder.S.GetEyebrows(sex, id);
                m_Eyebrows.sharedMesh = newSkin.sharedMesh;
                m_EyebrowsID = id;
            }
            CombineMeshs();
        }

        public void SetTorso(int id)
        {
            if (m_TorsoID != id)
            {
                var newSkin = CharacterHolder.S.GetTorso(sex, id);
                m_Torso.sharedMesh = newSkin.sharedMesh;
                m_TorsoID = id;
            }
            CombineMeshs();
        }

        public void SetArmUpperRight(int id)
        {
            if (m_ArmUpperRightID != id)
            {
                var newSkin = CharacterHolder.S.GetArmUpperRight(sex, id);
                m_ArmUpperRight.sharedMesh = newSkin.sharedMesh;
                m_ArmUpperRightID = id;
            }
            CombineMeshs();
        }

        public void SetArmUpperLeft(int id)
        {
            if (m_ArmUpperLeftID != id)
            {
                var newSkin = CharacterHolder.S.GetArmUpperLeft(sex, id);
                m_ArmUpperLeft.sharedMesh = newSkin.sharedMesh;
                m_ArmUpperLeftID = id;
            }
            CombineMeshs();
        }

        public void SetArmLowerRight(int id)
        {
            if (m_ArmLowerRightID != id)
            {
                var newSkin = CharacterHolder.S.GetArmLowerRight(sex, id);
                m_ArmLowerRight.sharedMesh = newSkin.sharedMesh;
                m_ArmLowerRightID = id;
            }
            CombineMeshs();
        }

        public void SetArmLowerLeft(int id)
        {
            if (m_ArmLowerLeftID != id)
            {
                var newSkin = CharacterHolder.S.GetArmLowerLeft(sex, id);
                m_ArmLowerLeft.sharedMesh = newSkin.sharedMesh;
                m_ArmLowerLeftID = id;
            }
            CombineMeshs();
        }

        public void SetHandRight(int id)
        {
            if (m_HandRightID != id)
            {
                var newSkin = CharacterHolder.S.GetHandRight(sex, id);
                m_HandRight.sharedMesh = newSkin.sharedMesh;
                m_HandRightID = id;
            }
            CombineMeshs();
        }

        public void SetHandLeft(int id)
        {
            if (m_HandLeftID != id)
            {
                var newSkin = CharacterHolder.S.GetHandLeft(sex, id);
                m_HandLeft.sharedMesh = newSkin.sharedMesh;
                m_HandLeftID = id;
            }
            CombineMeshs();
        }

        public void SetHips(int id)
        {
            if (m_HipsID != id)
            {
                var newSkin = CharacterHolder.S.GetHips(sex, id);
                m_Hips.sharedMesh = newSkin.sharedMesh;
                m_HipsID = id;
            }
            CombineMeshs();
        }

        public void SetLegRight(int id)
        {
            if (m_LegRightID != id)
            {
                var newSkin = CharacterHolder.S.GetLefRight(sex, id);
                m_LegRight.sharedMesh = newSkin.sharedMesh;
                m_LegRightID = id;
            }
            CombineMeshs();
        }

        public void SetLegLeft(int id)
        {
            if (m_LegLeftID != id)
            {
                var newSkin = CharacterHolder.S.GetLefLeft(sex, id);
                m_LegLeft.sharedMesh = newSkin.sharedMesh;
                m_LegLeftID = id;
            }
            CombineMeshs();
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

            //attachment
            // m_HeadAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_HeadBackAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_BackAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_ShoulderRightAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_ShoulderLeftAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_ElbowRightAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_ElbowLeftAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_HipsAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_HeadBackAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_KneeRightAttachmentRoot.GetChild(0).gameObject.SetActive(true);
            // m_KneeLeftAttachmentRoot.GetChild(0).gameObject.SetActive(true);
        }

        /// <summary>
        /// 带上头盔 ，隐藏面部
        /// </summary>
        private void HideFace()
        {

        }

        private void CombineMeshs()
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
                // 记录骨骼
                bones.AddRange(oneRender.bones);
                // 记录权重
                BoneWeight[] meshBoneweight = oneRender.sharedMesh.boneWeights;
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