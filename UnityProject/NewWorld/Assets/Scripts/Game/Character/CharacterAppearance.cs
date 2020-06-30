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
        Hips,
        ArmUpper,
        ArmLower,
        Hand,
        Leg
    }

    public class CharacterAppearance : MonoBehaviour
    {

        public SkinnedMeshRenderer[] renders;
        // 合并后使用的材质
        public Material material;
        private SkinnedMeshRenderer m_Renderer;

        [Header("Sex")]
        [SerializeField] private Sex sex = Sex.Male;//是否是男性
        [Header("Hair")]
        [SerializeField] private SkinnedMeshRenderer m_Hair;
        //[SerializeField] private Transform m_HairRoot;

        [Header("Head")]
        [SerializeField] private SkinnedMeshRenderer m_Head;
        //[SerializeField] private Transform m_HeadRoot;
        [Header("Facial hair")]//胡子
        [SerializeField] private Transform m_FacialHairRoot;
        [Header("Eyebrows")]
        [SerializeField] private Transform m_EyebrowsRoot;
        [Header("Torso")]
        [SerializeField] private Transform m_TorsoRoot;
        [Header("Hips")]
        [SerializeField] private Transform m_HipsRoot;
        [Header("Arm Upper")]
        [SerializeField] private Transform m_ArmUpperRightRoot;
        [SerializeField] private Transform m_ArmUpperLeftRoot;
        [Header("Arm Lower")]
        [SerializeField] private Transform m_ArmLowerRightRoot;
        [SerializeField] private Transform m_ArmLowerLeftRoot;
        [Header("Hand")]
        [SerializeField] private Transform m_HandRightRoot;
        [SerializeField] private Transform m_HandLeftRoot;
        [Header("Leg")]
        [SerializeField] private Transform m_LegRightRoot;
        [SerializeField] private Transform m_LegLeftRoot;


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
        public int m_CurEyebrowsIndex;
        public int m_CurTorsoIndex;
        public int m_CurHipsIndex;
        public int m_CurArmUpperIndex;
        public int m_CurArmLowerIndex;
        public int m_CurHandIndex;

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

                    break;
            }
        }

        public void SetHair(int index)
        {
            if (m_CurHairIndex != index)
            {
                m_Hair.gameObject.SetActive(true);
                var newHair = CharacterHolder.S.GetHair(index);
                Debug.LogError(newHair.sharedMesh.name);
                m_Hair.sharedMesh = newHair.sharedMesh;

                //m_Hair = newHair;
                //m_HeadRoot.GetChild(m_CurHairIndex).gameObject.SetActive(false);
                //transform.GetChild(index).gameObject.SetActive(true);
                m_CurHairIndex = index;
            }

            CombineMeshs();
        }

        public void SetHead(int index)
        {
            if (m_CurHeadIndex != index)
            {
                m_Head.gameObject.SetActive(true);
                var head = CharacterHolder.S.GetHead(sex, index);
                Debug.LogError(head.sharedMesh.name);
                m_Head.sharedMesh = head.sharedMesh;
                //m_Head = head;
                //m_HeadRoot.GetChild(m_CurHeadIndex).gameObject.SetActive(false);
                //m_HairRoot.GetChild(index).gameObject.SetActive(true);
                m_CurHeadIndex = index;
            }

            CombineMeshs();
        }

        private void SetTorso(int index)
        {
            if (m_CurTorsoIndex != index)
            {
                m_TorsoRoot.GetChild(m_CurTorsoIndex).gameObject.SetActive(false);
                //m_TorsoRoot.GetChild(index).gameObject.SetActive(true);
                m_CurTorsoIndex = index;
            }

            CombineMeshs();
        }

        public void ApplyAppearance()
        {
            //m_HairRoot.GetChild(m_CurHairIndex).gameObject.SetActive(true);
            //m_HairRoot.GetChild(m_CurHeadIndex).gameObject.SetActive(true);
            //m_HeadRoot.GetChild(m_CurHeadIndex).gameObject.SetActive(true);
            //m_FacialHairRoot.GetChild(0).gameObject.SetActive(true);
            m_EyebrowsRoot.GetChild(m_CurEyebrowsIndex).gameObject.SetActive(true);
            m_TorsoRoot.GetChild(m_CurTorsoIndex).gameObject.SetActive(true);
            m_HipsRoot.GetChild(m_CurHipsIndex).gameObject.SetActive(true);

            m_ArmUpperRightRoot.GetChild(m_CurArmUpperIndex).gameObject.SetActive(true);
            m_ArmUpperLeftRoot.GetChild(m_CurArmUpperIndex).gameObject.SetActive(true);

            m_ArmLowerRightRoot.GetChild(m_CurArmLowerIndex).gameObject.SetActive(true);
            m_ArmLowerLeftRoot.GetChild(m_CurArmLowerIndex).gameObject.SetActive(true);

            m_HandRightRoot.GetChild(m_CurHandIndex).gameObject.SetActive(true);
            m_HandLeftRoot.GetChild(m_CurHandIndex).gameObject.SetActive(true);

            m_LegRightRoot.GetChild(m_CurHeadIndex).gameObject.SetActive(true);
            m_LegLeftRoot.GetChild(m_CurHeadIndex).gameObject.SetActive(true);

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