using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace GFrame
{
    public class AddressableResMgr : TSingleton<AddressableResMgr>
    {
        private List<BaseAddressableRes> m_LstHandle;
        private Dictionary<string, BaseAddressableRes> m_ResMap;

        public override void OnSingletonInit()
        {
            m_LstHandle = new List<BaseAddressableRes>();
            m_ResMap = new Dictionary<string, BaseAddressableRes>();
        }

        public AsyncOperationHandle LoadSceneAsync(string name, Action<SceneInstance> callback = null, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var handle = Addressables.LoadSceneAsync(name, mode).AddCompleteCallback(
                   (result) =>
                   {
                       if (callback != null)
                           callback.Invoke(result.Result);
                   });

            return handle;
        }

        public AddressableGameObjectRes InstantiateAsync(string assetName, Action<GameObject> completeCallback = null, string label = "")
        {
            BaseAddressableRes res = null;
            if (!m_ResMap.TryGetValue(assetName, out res))
            {
                res = new AddressableGameObjectRes();
                res.assetName = assetName;
                m_LstHandle.Add(res);
                m_ResMap.Add(assetName, res);
            }
            (res as AddressableGameObjectRes).InstantiateAsync(completeCallback);
            return res as AddressableGameObjectRes;
        }

        public AddressableRes LoadAssetAsync<T>(string assetName, Action<T> completeCallback = null, string label = "")
        {
            BaseAddressableRes res = null;
            if (!m_ResMap.TryGetValue(assetName, out res))
            {
                res = new AddressableRes();
                res.assetName = assetName;
                m_LstHandle.Add(res);
                m_ResMap.Add(assetName, res);
            }
            (res as AddressableRes).LoadAssetAsync<T>(assetName, completeCallback);
            return res as AddressableRes;
        }

        public void ReleaseInstance(GameObject obj)
        {
            BaseAddressableRes res = null;
            if (obj.name.EndsWith("(Clone)"))
                obj.name = obj.name.Replace("(Clone)", "");

            if (m_ResMap.TryGetValue(obj.name, out res))
            {
                if (res is AddressableGameObjectRes)
                {
                    (res as AddressableGameObjectRes).Release(obj);
                }
                else
                {
                    Log.e("#Check assetname");
                }
            }
            else
                Log.e("#GameObject not create by ResMgr");
        }

        public void ReleaseRes(BaseAddressableRes res)
        {
            if (res == null) return;
            if (m_LstHandle.Contains(res))
                res.ReleaseAll();
        }

        public void ReleaseAllAsset()
        {
            for (int i = m_LstHandle.Count - 1; i >= 0; --i)
            {
                m_LstHandle[i].ReleaseAll();
            }
        }
    }

    public static class AddressableResMgrExtension
    {
        public static AsyncOperationHandle AddCompleteCallback(this AsyncOperationHandle<GameObject> handle, Action<AsyncOperationHandle<GameObject>> completedCallBack)
        {
            handle.Completed += completedCallBack;
            return handle;
        }

        public static AsyncOperationHandle<T> AddCompleteCallback<T>(this AsyncOperationHandle<T> handle, Action<AsyncOperationHandle<T>> completedCallBack)
        {
            handle.Completed += completedCallBack;
            return handle;
        }
    }


    public class AddressableGameObjectRes : BaseAddressableRes
    {
        protected List<AsyncOperationHandle<GameObject>> m_LstInstanceHandler;

        public AsyncOperationHandle<GameObject> InstantiateAsync(Action<GameObject> instanceCallback = null, string label = "")
        {
            Assert.IsNotNull(assetName);

            var handle = Addressables.InstantiateAsync(assetName);

            handle.AddCompleteCallback((result) =>
            {
                if (instanceCallback != null)
                    instanceCallback.Invoke(result.Result);

                //OnInstanceDone(result.Result);
            });
            if (m_LstInstanceHandler == null) m_LstInstanceHandler = new List<AsyncOperationHandle<GameObject>>();
            m_LstInstanceHandler.Add(handle);

            return handle;
        }

        // private void OnInstanceDone(GameObject obj)
        // {
        //     //m_LstInstanceHandler.
        // }

        public override void ReleaseAll()
        {
            if (m_LstInstanceHandler == null) return;
            for (int i = m_LstInstanceHandler.Count - 1; i >= 0; i--)
            {
                Addressables.Release(m_LstInstanceHandler[i]);
                m_LstInstanceHandler.RemoveAt(i);
            }
            m_LstInstanceHandler = null;

        }

        public override void Release<GameObject>(GameObject target)
        {
            if (m_LstInstanceHandler == null) return;
            for (int i = m_LstInstanceHandler.Count - 1; i >= 0; i--)
            {
                if (m_LstInstanceHandler[i].Result.Equals(target))
                {
                    Addressables.Release(m_LstInstanceHandler[i]);
                    m_LstInstanceHandler.RemoveAt(i);
                }
            }
        }
    }

    public class AddressableRes : BaseAddressableRes
    {
        protected AsyncOperationHandle m_loadHandler;
        public AsyncOperationHandle LoadAssetAsync<T>(string assetName, Action<T> completeCallback, string label = "")
        {
            this.assetName = assetName;
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetName);
            handle.AddCompleteCallback((result) =>
            {
                if (completeCallback != null)
                    completeCallback.Invoke(result.Result);
            });

            m_loadHandler = handle;

            return handle;
        }

        public override void Release<T>(T targe)
        {
            Addressables.Release(m_loadHandler);
        }

    }

    public class BaseAddressableRes : IAddressableRes
    {

        public string assetName = "";

        public virtual void ReleaseAll()
        {
        }

        public virtual void Release<T>(T targe)
        {

        }
    }

    public interface IAddressableRes
    {
        void ReleaseAll();
        void Release<T>(T target);
    }


}