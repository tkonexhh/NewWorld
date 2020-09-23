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
        p.gameObject.SetActive(false);
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
    public GameObject gameObject { get; private set; }
    private MeshFilter m_Mesh;

    public MTPatch(Material[] mats)
    {
        gameObject = new GameObject("_TerrainPatch");
        MeshRenderer meshR;
        m_Mesh = gameObject.AddComponent<MeshFilter>();
        meshR = gameObject.AddComponent<MeshRenderer>();
        meshR.materials = mats;
    }
    public void Reset(uint id, Mesh m)
    {
        gameObject.SetActive(true);
        PatchId = id;
        m_Mesh.mesh = m;
    }
    private void DestroySelf()
    {
        if (gameObject != null)
            MonoBehaviour.Destroy(gameObject);
        gameObject = null;
        m_Mesh = null;
    }

}

// }