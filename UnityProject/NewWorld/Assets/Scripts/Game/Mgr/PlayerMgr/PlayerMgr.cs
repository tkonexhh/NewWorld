/************************
	FileName:/Scripts/Game/Player/PlayerMgr.cs
	CreateAuthor:neo.xu
	CreateTime:8/13/2020 7:53:27 PM
	Tip:8/13/2020 7:53:27 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerMgr : TMonoSingleton<PlayerMgr>
    {
        private PlayerInventoryMgr m_InventoryMgr = null;

        public PlayerInventoryMgr inventoryMgr { get => m_InventoryMgr; }


        public override void OnSingletonInit()
        {
            m_InventoryMgr = gameObject.AddComponent<PlayerInventoryMgr>();


            m_InventoryMgr.OnInit();
        }


        private void Update()
        {
            m_InventoryMgr?.OnUpdate();
        }
    }

}