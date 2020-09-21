/************************
	FileName:/Scripts/Game/Module/OpenWorld/MightyTerrainMesh/Scripts/MTPatch.cs
	CreateAuthor:neo.xu
	CreateTime:9/21/2020 4:29:32 PM
	Tip:9/21/2020 4:29:32 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// namespace Game.Logic
// {
internal class MTPatch
{
    private static Queue<MTPatch> _qPool = new Queue<MTPatch>();
    public static MTPatch Pop(Material[] mats)
    {
        if (_qPool.Count > 0)
        {
            return _qPool.Dequeue();
        }
        return new MTPatch(mats);
    }
    public static void Push(MTPatch p)
    {
        p.m_Go.SetActive(false);
        _qPool.Enqueue(p);
    }
    public static void Clear()
    {
        while (_qPool.Count > 0)
        {
            _qPool.Dequeue().DestroySelf();
        }
    }



    public uint PatchId { get; private set; }
    private GameObject m_Go;
    private MeshFilter m_Mesh;
    public MTPatch(Material[] mats)
    {
        m_Go = new GameObject("_TerrainPatch");
        MeshRenderer meshR;
        m_Mesh = m_Go.AddComponent<MeshFilter>();
        meshR = m_Go.AddComponent<MeshRenderer>();
        meshR.materials = mats;
    }
    public void Reset(uint id, Mesh m)
    {
        m_Go.SetActive(true);
        PatchId = id;
        m_Mesh.mesh = m;
    }
    private void DestroySelf()
    {
        if (m_Go != null)
            MonoBehaviour.Destroy(m_Go);
        m_Go = null;
        m_Mesh = null;
    }
}

// }