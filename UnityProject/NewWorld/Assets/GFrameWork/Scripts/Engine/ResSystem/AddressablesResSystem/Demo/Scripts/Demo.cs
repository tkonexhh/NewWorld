using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

namespace GFrame
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] Image m_ImgDemo;
        AddressableGameObjectRes handle;
        //AddressableRes handle_Icon;

        private List<GameObject> m_objs = new List<GameObject>();

        void Start()
        {
            AddressableResMgr.S.LoadAssetAsync<Sprite>("Cursor", OnAssetLoaded1);
            //handle_Icon = AddressableResMgr.S.LoadAssetAsync<Sprite>("folder_icon", OnAssetLoaded1);
            //handle = AddressableResMgr.S.InstantiateAsync("CellNode");
        }

        UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle handle_scene;
        bool sc = false;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                for (int i = 0; i < 50; i++)
                    SpawnCube();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject obj = m_objs[m_objs.Count - 1];
                AddressableResMgr.S.ReleaseInstance(obj);
                m_objs.RemoveAt(m_objs.Count - 1);
                //AddressableResMgr.S.ReleaseAllAsset();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                handle.ReleaseAll();
                //AddressableResMgr.S.ReleaseRes(handle_Icon);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (sc)
                {
                    Addressables.Release(handle_scene);
                }
                else
                {
                    handle_scene = AddressableResMgr.S.LoadSceneAsync("AddressDemo", null);
                    sc = true;
                }


            }
        }

        void SpawnCube()
        {
            Debug.LogError("SpawnCube");
            handle = AddressableResMgr.S.InstantiateAsync("CellNode", OnAssetLoaded);

            // if (handle != null)
            //     (handle).InstantiateAsync(OnAssetLoaded);
        }

        private void OnAssetLoaded1(Sprite handle)
        {
            m_ImgDemo.sprite = handle;
        }

        private void OnAssetLoaded(GameObject handle)
        {
            GameObject gameObject = handle;
            Vector3 pos = Random.insideUnitSphere * 10;
            gameObject.SetPos(pos);
            m_objs.Add(gameObject);
        }
    }

}