/************************
	FileName:/Scripts/Game/Module/OpenWorld/MapChunk.cs
	CreateAuthor:neo.xu
	CreateTime:9/23/2020 11:01:57 AM
	Tip:9/23/2020 11:01:57 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using MightyTerrainMesh;

namespace Game.Logic
{
    public class MapChunk
    {
        private string m_DataName = "";
        public float[] lodPolicy = new float[1] { 0 };
        private MTQuadTreeHeader m_Header;
        private MTQuadTreeNode m_Root;
        // patch identifier [meshid 30bit][lod 2bit]
        private MTArray<uint> mVisiblePatches;
        private Dictionary<uint, MTPatch> m_ActivePatches = new Dictionary<uint, MTPatch>();
        private Dictionary<uint, MTPatch> m_PatchesFlipBuffer = new Dictionary<uint, MTPatch>();
        //meshes
        private Dictionary<int, MTRuntimeMesh> m_MeshPool = new Dictionary<int, MTRuntimeMesh>();
        private GameObject m_Go;
        private bool m_Dirty = true;

        public Camera camera { set; get; }
        public Transform forcusTrans { set; get; }


        public MapChunk(string dataName, Vector3 pos)
        {
            m_DataName = dataName;
            m_Go = new GameObject("MapChunk");
            var collider = m_Go.AddComponent<BoxCollider>();
            collider.center = m_Go.transform.position + new Vector3(WorldDefine.ChunkSize / 2, 0, WorldDefine.ChunkSize / 2);
            collider.size = new Vector3(WorldDefine.ChunkSize * 2, WorldDefine.ChunkSize, WorldDefine.ChunkSize * 2);
            m_Go.Reset();
            m_Go.transform.position = pos;
            if (m_DataName == "")
                return;

            try
            {
                m_Header = MTFileUtils.LoadQuadTreeHeader(m_DataName);

                m_Root = new MTQuadTreeNode(m_Header.QuadTreeDepth, m_Header.BoundMin, m_Header.BoundMax, pos);

                foreach (var mh in m_Header.Meshes.Values)
                    m_Root.AddMesh(mh);
                int gridMax = 1 << m_Header.QuadTreeDepth;//1<< X 相当于 2的X次方
                mVisiblePatches = new MTArray<uint>(gridMax * gridMax);//(int)Mathf.Pow(2, 2 * m_Header.QuadTreeDepth)

                if (lodPolicy.Length < m_Header.LOD)
                {
                    float[] policy = new float[m_Header.LOD];
                    for (int i = 0; i < lodPolicy.Length; ++i)
                        policy[i] = lodPolicy[i];
                    lodPolicy = policy;
                }
                lodPolicy[0] = 300;
                lodPolicy[0] = Mathf.Clamp(lodPolicy[0], 0.5f * m_Root.Bound.size.x / gridMax, lodPolicy[0]);
                lodPolicy[lodPolicy.Length - 1] = float.MaxValue;
            }
            catch
            {
                m_Header = null;
                m_Root = null;
                Debug.LogError("MTLoader load quadtree header failed");
            }
        }

        public void Init()
        {
            // Debug.LogError(m_Go.transform.position);
            // m_Root.SetBoundOffset(m_Go.transform.position);//.center += m_Go.transform.position;
            // Debug.LogError(m_Root.Bound);
        }

        public void SetDirty()
        {
            m_Dirty = true;
        }

        private Mesh GetMesh(uint patchId)
        {
            int mId = (int)(patchId >> 2);
            int lod = (int)(patchId & 0x00000003);
            if (m_MeshPool.ContainsKey(mId))
            {
                return m_MeshPool[mId].GetMesh(lod);
            }
            MTRuntimeMesh rm = new MTRuntimeMesh(mId, m_Header.LOD, m_Header.DataName);
            m_MeshPool.Add(mId, rm);
            return rm.GetMesh(lod);
        }


        public void Update()
        {
            //every 10 frame update once
            if (camera == null || m_Root == null || forcusTrans == null || !camera.enabled || !m_Dirty)
                return;
            m_Dirty = false;
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);//视景平面 得到摄像机视锥
            mVisiblePatches.Reset();
            //transform 为玩家中心点
            m_Root.GetVisibleMesh(planes, forcusTrans.position, lodPolicy, mVisiblePatches);

            m_PatchesFlipBuffer.Clear();
            for (int i = 0; i < mVisiblePatches.Length; ++i)
            {
                uint pId = mVisiblePatches.Data[i];

                if (m_ActivePatches.ContainsKey(pId))
                {
                    m_PatchesFlipBuffer.Add(pId, m_ActivePatches[pId]);
                    m_ActivePatches.Remove(pId);
                }
                else
                {
                    //new patches
                    Mesh m = GetMesh(pId);
                    if (m != null)
                    {
                        MTPatch patch = MTPatch.Pop(m_Header.RuntimeMats);
                        patch.gameObject.transform.SetParent(m_Go.transform);
                        patch.gameObject.Reset();
                        patch.Reset(pId, m);
                        m_PatchesFlipBuffer.Add(pId, patch);
                    }
                }
            }
            Dictionary<uint, MTPatch>.Enumerator iPatch = m_ActivePatches.GetEnumerator();
            while (iPatch.MoveNext())
            {
                MTPatch.Push(iPatch.Current.Value);
            }
            m_ActivePatches.Clear();
            Dictionary<uint, MTPatch> temp = m_PatchesFlipBuffer;
            m_PatchesFlipBuffer = m_ActivePatches;
            m_ActivePatches = temp;
        }

        public void DrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.7f);
            Gizmos.DrawWireCube(m_Root.Bound.center, m_Root.Bound.extents * 2);
        }
    }

}