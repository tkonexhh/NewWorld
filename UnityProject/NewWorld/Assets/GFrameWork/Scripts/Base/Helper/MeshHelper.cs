/************************
	FileName:/GFrameWork/Scripts/Base/Helper/MeshHelper.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 3:45:11 PM
	Tip:6/23/2020 3:45:11 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class MeshHelper
    {
        public static void CombineSkinnedMesh(Transform transform, Material mat, SkinnedMeshRenderer parentRenderer)
        {
            SkinnedMeshRenderer[] renders = transform.GetComponentsInChildren<SkinnedMeshRenderer>();

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
                mesh.uv = sharedMesh.uv;

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
            SkinnedMeshRenderer combinedSkinnedRenderer = parentRenderer;//transform.gameObject.AddComponent<SkinnedMeshRenderer>();
            Mesh combinedMesh = new Mesh();
            combinedMesh.CombineMeshes(combineInstances.ToArray(), true, true);
            combinedSkinnedRenderer.sharedMesh = combinedMesh;
            combinedSkinnedRenderer.bones = bones.ToArray();
            combinedSkinnedRenderer.sharedMesh.boneWeights = boneWeights.ToArray();
            combinedSkinnedRenderer.sharedMesh.bindposes = bindposes.ToArray();
            combinedSkinnedRenderer.sharedMesh.RecalculateBounds();
            combinedSkinnedRenderer.material = mat;

            // 还原自身的变换矩阵
            transform.position = l_position;
            transform.rotation = l_rotation;
            transform.localScale = l_scale;
        }
    }

}