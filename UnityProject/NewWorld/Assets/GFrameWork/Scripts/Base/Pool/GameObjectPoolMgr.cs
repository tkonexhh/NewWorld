/************************
	FileName:/GFrameWork/Scripts/Base/Pool/GameObjectPoolMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 2:42:59 PM
	Tip:6/12/2020 2:42:59 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[GameObjectPoolMgr]")]
    public class GameObjectPoolMgr : TMonoSingleton<GameObjectPoolMgr>
    {
        private Dictionary<string, GameObjectPool> m_PoolMap = new Dictionary<string, GameObjectPool>();
        public void AddPool(string poolName, GameObject prefab, int initCount)
        {
            if (m_PoolMap.ContainsKey(poolName))
            {
                Log.w("#Already Init GameObjectPool:" + poolName);
                return;
            }
            GameObjectPool pool = new GameObjectPool();
            pool.InitPool(poolName, transform, prefab, initCount);
            // GameObject poolObj = new GameObject();
            // poolObj.transform.SetParent(transform);
            // var pool = poolObj.AddComponent<GameObjectPool>();
            // poolObj.name = poolName;
            // pool.m_PoolName = poolName;
            // pool.m_Prefab = prefab;
            // pool.m_InitialSize = initCount;
            m_PoolMap.Add(poolName, pool);
        }

        public void AddPool(GameObjectPool pool)
        {
            // if (string.IsNullOrEmpty(pool.PoolName))
            // {
            //     pool.m_PoolName = pool.prefab.name;
            // }

            m_PoolMap.Add(pool.PoolName, pool);

        }

        public void RemovePool(string poolName)
        {
            GameObjectPool pool = null;
            if (m_PoolMap.TryGetValue(poolName, out pool))
            {
                pool.RemoveAllObject();
                m_PoolMap.Remove(poolName);
            }
        }

        public void RemoveAllPool()
        {
            foreach (var pool in m_PoolMap)
            {
                pool.Value.RemoveAllObject();
            }

            m_PoolMap.Clear();
        }

        public GameObject GetObject(string poolName)
        {
            GameObjectPool cell = null;
            if (!m_PoolMap.TryGetValue(poolName, out cell))
            {
                Log.e("#Allocate Not Find Pool:" + poolName);
                return null;
            }

            return cell.GetObject();
        }

        public void Recycle(string poolName, GameObject obj)
        {
            GameObjectPool cell = null;
            if (!m_PoolMap.TryGetValue(poolName, out cell))
            {
                Log.e("#Recycle Not Find Pool:" + poolName);
                return;
            }

            cell.ReturnObject(obj);
        }

        public void Recycle(GameObject obj)
        {
            Recycle(obj.name, obj);
        }
    }

}