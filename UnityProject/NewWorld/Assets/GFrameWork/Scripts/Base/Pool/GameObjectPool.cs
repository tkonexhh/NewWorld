/************************
	FileName:/GFrameWork/Scripts/Base/Pool/GameObjectPool.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 2:32:15 PM
	Tip:6/12/2020 2:32:15 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace GFrame
{
    public class GameObjectPool //: MonoBehaviour
    {
        private string m_PoolName;
        private GameObject m_Prefab;
        private int m_InitialSize;
        private Transform m_Root;

        public string PoolName
        {
            get { return m_PoolName; }
        }

        private readonly Stack<GameObject> pool = new Stack<GameObject>();

        public void InitPool(string poolName, Transform parent, GameObject prefab, int initialSize)
        {
            m_PoolName = poolName;
            m_InitialSize = initialSize;
            m_Prefab = prefab;

            GameObject container = new GameObject(poolName);
            m_Root = container.transform;
            m_Root.SetParent(parent);

            for (int i = 0; i < m_InitialSize; i++)
            {
                var obj = CreateInstance();
                obj.SetActive(false);
                pool.Push(obj);
            }
        }


        public GameObject GetObject()
        {
            var obj = pool.Count > 0 ? pool.Pop() : CreateInstance();
            obj.SetActive(true);
            return obj;
        }

        public void Recycle(GameObject obj)
        {
            var pooledObject = obj.GetComponent<PooledObject>();
            Assert.IsNotNull(pooledObject);
            Assert.IsTrue(pooledObject.pool == this);
            obj.transform.SetParent(m_Root);
            obj.SetActive(false);
            pool.Push(obj);
        }

        public void RemoveAllObject()
        {
            GameObject next = null;
            while (pool.Count > 0)
            {
                next = pool.Pop();
                GameObject.Destroy(next);
            }
        }
        private GameObject CreateInstance()
        {
            var obj = GameObject.Instantiate(m_Prefab);
            obj.name = m_PoolName;
            var pooledObject = obj.AddComponent<PooledObject>();
            pooledObject.pool = this;
            obj.transform.SetParent(m_Root);
            return obj;
        }
    }


    public class PooledObject : MonoBehaviour
    {
        public GameObjectPool pool;
    }

}