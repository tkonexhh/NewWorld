using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MightyTerrainMesh;

internal class MTRuntimeMesh
{
    public int MeshID { get; private set; }
    private Mesh[] mLOD;
    public MTRuntimeMesh(int meshid, int lod, string dataName)
    {
        MeshID = meshid;
        mLOD = new Mesh[lod];
        MTFileUtils.LoadMesh(mLOD, dataName, meshid);
    }
    public Mesh GetMesh(int lod)
    {
        lod = Mathf.Clamp(lod, 0, mLOD.Length - 1);
        return mLOD[lod];
    }
}

public class MTLoader : MonoBehaviour
{
    public string DataName = "";
    [Header("LOD distance")]
    public float[] lodPolicy = new float[1] { 0 };
    private Camera m_Camera;
    private MTQuadTreeHeader m_Header;
    private MTQuadTreeNode m_Root;
    //patch identifier [meshid 30bit][lod 2bit]
    private MTArray<uint> mVisiblePatches;
    private Dictionary<uint, MTPatch> m_ActivePatches = new Dictionary<uint, MTPatch>();
    private Dictionary<uint, MTPatch> m_PatchesFlipBuffer = new Dictionary<uint, MTPatch>();
    //meshes
    private Dictionary<int, MTRuntimeMesh> m_MeshPool = new Dictionary<int, MTRuntimeMesh>();
    private bool mbDirty = true;
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

    public void SetDirty()
    {
        mbDirty = true;
    }

    private void Awake()
    {
        if (DataName == "")
            return;
        try
        {
            m_Header = MTFileUtils.LoadQuadTreeHeader(DataName);

            m_Root = new MTQuadTreeNode(m_Header.QuadTreeDepth, m_Header.BoundMin, m_Header.BoundMax);
            foreach (var mh in m_Header.Meshes.Values)
                m_Root.AddMesh(mh);
            int gridMax = 1 << m_Header.QuadTreeDepth;//1<< X 相当于 2的X次方
            mVisiblePatches = new MTArray<uint>(gridMax * gridMax);
            //以上其实就相当于
            // mVisiblePatches = new MTArray<uint>((int)Mathf.Pow(2, 2 * m_Header.QuadTreeDepth));

            if (lodPolicy.Length < m_Header.LOD)
            {
                float[] policy = new float[m_Header.LOD];
                for (int i = 0; i < lodPolicy.Length; ++i)
                    policy[i] = lodPolicy[i];
                lodPolicy = policy;
            }
            lodPolicy[0] = Mathf.Clamp(lodPolicy[0], 0.5f * m_Root.Bound.size.x / gridMax, lodPolicy[0]);
            lodPolicy[lodPolicy.Length - 1] = float.MaxValue;
        }
        catch
        {
            m_Header = null;
            m_Root = null;
            Debug.LogError("MTLoader load quadtree header failed");
        }
        m_Camera = GetComponent<Camera>();
    }

    private void OnDestroy()
    {
        MTPatch.Clear();
    }

    void Update()
    {
        //every 10 frame update once
        if (m_Camera == null || m_Root == null || !m_Camera.enabled || !mbDirty)
            return;
        mbDirty = false;
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(m_Camera);
        mVisiblePatches.Reset();
        m_Root.RetrieveVisibleMesh(planes, transform.position, lodPolicy, mVisiblePatches);
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
}
