/************************
	FileName:/Scripts/Game/Module/OpenWorld/WorldMgr.cs
	CreateAuthor:neo.xu
	CreateTime:9/23/2020 10:34:53 AM
	Tip:9/23/2020 10:34:53 AM
************************/

using System.Linq;
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
        private Vector2Int m_CurChunkPos = new Vector2Int(2, 2);
        private int m_Range = 1;
        private List<MapChunk> m_Chunks = new List<MapChunk>();
        private List<MapChunk> m_DelChunk = new List<MapChunk>();

        private float m_CheckTimer;

        public override void OnSingletonInit()
        {
            m_ForcusTrans = Camera.main.transform;
            m_Chunks = new List<MapChunk>();
        }

        public void Init()
        {
            m_CurChunkPos = CheckCurrentChunck();
            var chunks = GetRangeChunck(m_CurChunkPos);
            foreach (var chunk in chunks)
            {
                CreateChunck(chunk);
            }
            // CreateRangeChunck();
        }

        private Vector2Int CheckCurrentChunck()
        {
            return new Vector2Int((int)(m_ForcusTrans.position.x / WorldDefine.ChunkSize), (int)(m_ForcusTrans.position.z / WorldDefine.ChunkSize));
        }

        private void CreateChunck(Vector2Int pos)
        {
            if (pos.x < 0 || pos.x > WorldDefine.WorldSize.x || pos.y < 0 || pos.y > WorldDefine.WorldSize.y)
                return;
            MapChunk chunk = new MapChunk(GetDataName(pos), GetChunkPos(pos));
            chunk.pos = pos;
            chunk.Init();
            chunk.camera = Camera.main;
            chunk.forcusTrans = m_ForcusTrans;
            m_Chunks.Add(chunk);
        }

        private Vector3 GetChunkPos(Vector2Int pos)
        {
            return new Vector3(pos.x * WorldDefine.ChunkSize, 0, pos.y * WorldDefine.ChunkSize);
        }

        private string GetDataName(Vector2Int pos)
        {
            return "demo2";
        }

        /// <summary>
        /// 获得某个点范围内的所有点
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private List<Vector2Int> GetRangeChunck(Vector2Int pos)
        {
            List<Vector2Int> chunks = new List<Vector2Int>();
            chunks.Add(pos);
            for (int i = 1; i < m_Range + 1; i++)
            {
                for (int x = pos.x - i; x <= pos.x + i; x++)
                {
                    if (x < 0 || x > WorldDefine.WorldSize.x)
                        continue;

                    if (pos.y + i <= WorldDefine.WorldSize.y)
                        chunks.Add(new Vector2Int(x, pos.y + i));
                    if (pos.y - i >= 0)
                        chunks.Add(new Vector2Int(x, pos.y - i));
                }

                for (int y = pos.y - (i - 1); y <= pos.y + (i - 1); y++)
                {
                    if (y < 0 || y > WorldDefine.WorldSize.y)
                        continue;

                    if (pos.x - i >= 0)
                        chunks.Add(new Vector2Int(pos.x - i, y));

                    if (pos.x + i <= WorldDefine.WorldSize.x)
                        chunks.Add(new Vector2Int(pos.x + i, y));
                }
            }

            return chunks;
        }

        private void CreateRangeChunck()
        {
            //根据位置加载四周的
            CreateChunck(m_CurChunkPos);

            for (int i = 1; i < m_Range + 1; i++)
            {
                for (int x = m_CurChunkPos.x - i; x <= m_CurChunkPos.x + i; x++)
                {
                    if (x < 0 || x > WorldDefine.WorldSize.x)
                        continue;

                    if (m_CurChunkPos.y + i <= WorldDefine.WorldSize.y)
                        CreateChunck(new Vector2Int(x, m_CurChunkPos.y + i));
                    if (m_CurChunkPos.y - i >= 0)
                        CreateChunck(new Vector2Int(x, m_CurChunkPos.y - i));
                }

                for (int y = m_CurChunkPos.y - (i - 1); y <= m_CurChunkPos.y + (i - 1); y++)
                {
                    if (y < 0 || y > WorldDefine.WorldSize.y)
                        continue;

                    if (m_CurChunkPos.x - i >= 0)
                        CreateChunck(new Vector2Int(m_CurChunkPos.x - i, y));

                    if (m_CurChunkPos.x + i <= WorldDefine.WorldSize.x)
                        CreateChunck(new Vector2Int(m_CurChunkPos.x + i, y));
                }
            }
        }

        private void Update()
        {
            m_CheckTimer += Time.deltaTime;
            if (m_CheckTimer >= WorldDefine.CheckTime)
            {
                m_CheckTimer = 0;
                var nowChunckPos = CheckCurrentChunck();
                if (!Vector2Int.Equals(nowChunckPos, m_CurChunkPos))
                {
                    CreateNewChunk(m_CurChunkPos, nowChunckPos);
                    m_CurChunkPos = nowChunckPos;
                    MarkReleaseChunk();

                    // CreateRangeChunck();
                }
            }


            if (m_DelChunk.Count > 0)
            {
                for (int i = m_DelChunk.Count - 1; i >= 0; i--)
                {
                    var chunk = m_DelChunk[0];
                    m_Chunks.Remove(chunk);
                    m_DelChunk.Remove(chunk);
                    chunk.Release();
                }
            }

            m_Chunks.ForEach(chunk =>
            {
                if (chunk.CheckClear)
                {
                    float distance = Vector2Int.Distance(chunk.pos, m_CurChunkPos);
                    if (distance > WorldDefine.ChunckMaxDistance)
                    {
                        //等待一段时间后 依旧在范围外就可以真正移除了
                        m_DelChunk.Add(chunk);
                    }
                    else
                    {
                        chunk.ClearFlag = false;
                    }
                }

                chunk.Update();
                chunk.SetDirty();
            });




        }

        private void MarkReleaseChunk()
        {
            m_Chunks.ForEach(chunk =>
            {
                float distance = Vector2Int.Distance(chunk.pos, m_CurChunkPos);
                if (distance > WorldDefine.ChunckMaxDistance)
                {
                    chunk.ClearFlag = true;
                }
            });
        }

        private void CreateNewChunk(Vector2Int oldPos, Vector2Int newPos)
        {
            var oldRange = GetRangeChunck(oldPos);
            var newRange = GetRangeChunck(newPos);

            //两个范围之间去重
            foreach (var item in oldRange)
            {
                if (newRange.Contains(item))
                {
                    newRange.Remove(item);
                }
            }

            //与现有的去重
            foreach (var chunk in m_Chunks)
            {
                if (newRange.Contains(chunk.pos))
                {
                    newRange.Remove(chunk.pos);
                }
            }

            foreach (var pos in newRange)
            {
                CreateChunck(pos);
            }


        }

        private void OnDrawGizmos()
        {
            if (!DrawGizmos) return;

            m_Chunks.ForEach(chunk => chunk.DrawGizmos());
        }
    }

}