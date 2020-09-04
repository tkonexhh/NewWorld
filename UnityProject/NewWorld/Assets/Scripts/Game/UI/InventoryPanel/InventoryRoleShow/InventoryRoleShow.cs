/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryRoleShow/InventoryRoleShow.cs
	CreateAuthor:neo.xu
	CreateTime:9/4/2020 5:23:39 PM
	Tip:9/4/2020 5:23:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;

namespace Game.Logic
{
    public class InventoryRoleShow : MonoBehaviour
    {
        [SerializeField] private RawImage m_RawImage;

        private void Awake()
        {
            m_RawImage.SetNativeSize();
        }

        private void Start()
        {
            AddressableResMgr.S.InstantiateAsync("InventoryRoleScene", (target) =>
            {
                target.transform.position = Vector3.one * 5000;
            });
        }
    }
}

