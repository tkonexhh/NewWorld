/************************
	FileName:/Scripts/Game/Module/OpenWorld/WorldMgr.cs
	CreateAuthor:neo.xu
	CreateTime:9/23/2020 10:34:53 AM
	Tip:9/23/2020 10:34:53 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class WorldMgr : TMonoSingleton<WorldMgr>
    {
        private bool DrawGizmos = true;
        private Transform m_ForcusTrans;
        private int m_Size = WorldDefine.ChunkSize;
        private Vector2Int m_ChunkPos = new Vector2Int(0, 0);

        private List<MapChunk> m_Chunks = new List<MapChunk>();
        public override void OnSingletonInit()
        {
            m_ForcusTrans = Camera.main.transform;
            m_Chunks = new List<MapChunk>();
        }

        public void Init()
        {
            //根据位置加载四周的
            CreateChunck("demo2", Vector3.zero);

            //up
            CreateChunck("demo2", Vector3.zero + new Vector3(0, 0, m_Size));
            //down
            CreateChunck("demo2", Vector3.zero + new Vector3(0, 0, -m_Size));
            //left
            CreateChunck("demo2", Vector3.zero + new Vector3(-m_Size, 0, 0));
            //right
            CreateChunck("demo2", Vector3.zero + new Vector3(m_Size, 0, 0));
            //up left
            CreateChunck("demo2", Vector3.zero + new Vector3(-m_Size, 0, m_Size));
            //up right
            CreateChunck("demo2", Vector3.zero + new Vector3(m_Size, 0, m_Size));
            //down left
            CreateChunck("demo2", Vector3.zero + new Vector3(-m_Size, 0, -m_Size));
            //down right
            CreateChunck("demo2", Vector3.zero + new Vector3(m_Size, 0, -m_Size));
        }

        private Vector3 GetChunkPos(Vector2Int pos)
        {
            return new Vector3(pos.x * m_Size, 0, pos.y * m_Size);
        }


        private void CreateChunck(string dataName, Vector3 pos)
        {
            MapChunk chunk = new MapChunk(dataName, pos);
            chunk.Init();
            chunk.camera = Camera.main;
            chunk.forcusTrans = m_ForcusTrans;
            m_Chunks.Add(chunk);
        }


        private void Update()
        {
            m_Chunks.ForEach(chunk =>
            {
                chunk.Update();
                chunk.SetDirty();
            });
        }

        private void OnDrawGizmos()
        {
            if (!DrawGizmos) return;

            m_Chunks.ForEach(chunk => chunk.DrawGizmos());
        }

    }

}