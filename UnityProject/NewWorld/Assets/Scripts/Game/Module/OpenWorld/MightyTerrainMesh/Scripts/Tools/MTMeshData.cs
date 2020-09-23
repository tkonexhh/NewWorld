namespace MightyTerrainMesh
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MTMeshHeader
    {
        public int MeshID { get; private set; }
        public Vector3 Center { get; private set; }
        public MTMeshHeader(int id, Vector3 c)
        {
            MeshID = id;
            Center = c;
        }
    }

    public class MTQuadTreeHeader//四叉树头
    {
        public int QuadTreeDepth = 0;//深度
        public Vector3 BoundMin = Vector3.zero;//边界
        public Vector3 BoundMax = Vector3.zero;
        public int LOD = 1;
        public string DataName { get; private set; }
        public Dictionary<int, MTMeshHeader> Meshes = new Dictionary<int, MTMeshHeader>();
        //runtime materials
        public Material[] RuntimeMats;
        public MTQuadTreeHeader(string name)
        {
            DataName = name;
        }
    }

    public class MTMeshData
    {
        public class LOD
        {
            public Vector3[] vertices;
            public Vector3[] normals;
            public Vector2[] uvs;
            public int[] faces;
        }
        public int meshId { get; private set; }
        public Vector3 center { get; private set; }
        public LOD[] lods;
        public MTMeshData(int id, Vector3 c)
        {
            meshId = id;
            center = c;
        }
    }

    public class MTQuadTreeNode//四叉树Node
    {
        public Bounds Bound { get; private set; }//包围盒
        public Vector3 Offset { get; private set; }
        public int MeshID { get; private set; }
        protected MTQuadTreeNode[] m_SubNodes;//四个子Node
        public MTQuadTreeNode(int depth, Vector3 min, Vector3 max, Vector3 offset)
        {
            Vector3 center = 0.5f * (min + max);
            Vector3 size = max - min;
            Bound = new Bounds(center + offset, size);
            Offset = offset;
            if (depth > 0)
            {
                m_SubNodes = new MTQuadTreeNode[4];
                Vector3 subMin = new Vector3(center.x - 0.5f * size.x, min.y, center.z - 0.5f * size.z);
                Vector3 subMax = new Vector3(center.x, max.y, center.z);
                m_SubNodes[0] = new MTQuadTreeNode(depth - 1, subMin, subMax, offset);
                subMin = new Vector3(center.x, min.y, center.z - 0.5f * size.z);
                subMax = new Vector3(center.x + 0.5f * size.x, max.y, center.z);
                m_SubNodes[1] = new MTQuadTreeNode(depth - 1, subMin, subMax, offset);
                subMin = new Vector3(center.x - 0.5f * size.x, min.y, center.z);
                subMax = new Vector3(center.x, max.y, center.z + 0.5f * size.z);
                m_SubNodes[2] = new MTQuadTreeNode(depth - 1, subMin, subMax, offset);
                subMin = new Vector3(center.x, min.y, center.z);
                subMax = new Vector3(center.x + 0.5f * size.x, max.y, center.z + 0.5f * size.z);
                m_SubNodes[3] = new MTQuadTreeNode(depth - 1, subMin, subMax, offset);
            }
        }

        public void GetVisibleMesh(Plane[] planes, Vector3 viewCenter, float[] lodPolicy, MTArray<uint> visible)
        {
            //TODO 原理是只有这个块完全在视野内 在会显示 有问题 需要只露出一点点就显示
            if (GeometryUtility.TestPlanesAABB(planes, Bound))
            {
                if (m_SubNodes == null)
                {
                    float distance = Vector3.Distance(viewCenter, Bound.center);
                    for (uint lod = 0; lod < lodPolicy.Length; ++lod)
                    {
                        if (distance <= lodPolicy[lod])
                        {
                            uint patchId = (uint)MeshID;
                            patchId <<= 2;
                            patchId |= lod;
                            visible.Add(patchId);
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 4; ++i)//递归一下
                    {
                        m_SubNodes[i].GetVisibleMesh(planes, viewCenter, lodPolicy, visible);
                    }
                }
            }
        }

        public void AddMesh(MTMeshHeader meshh)
        {
            if (m_SubNodes == null && Bound.Contains(meshh.Center + Offset))
            {
                MeshID = meshh.MeshID;
            }
            else if (m_SubNodes != null)
            {
                for (int i = 0; i < 4; ++i)
                {
                    m_SubNodes[i].AddMesh(meshh);
                }
            }
        }
    }
}