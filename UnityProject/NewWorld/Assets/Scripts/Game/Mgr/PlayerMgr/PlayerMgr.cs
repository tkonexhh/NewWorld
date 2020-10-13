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
    [TMonoSingletonAttribute("[Game]/[PlayerMgr]")]
    public class PlayerMgr : TMonoSingleton<PlayerMgr>
    {
        private Role_Player m_Role;
        private PlayerInventoryMgr m_InventoryMgr = null;
        private PlayerEquipmentMgr m_EquipmentMgr = null;

        public Role_Player role => m_Role;
        public PlayerInventoryMgr inventoryMgr => m_InventoryMgr;
        public PlayerEquipmentMgr equipmentMgr => m_EquipmentMgr;


        public override void OnSingletonInit()
        {
            m_InventoryMgr = gameObject.AddComponent<PlayerInventoryMgr>();
            m_EquipmentMgr = gameObject.AddComponent<PlayerEquipmentMgr>();


            m_InventoryMgr.OnInit();
            m_EquipmentMgr.OnInit();


            m_Role = new Role_Player();
        }

        public void Init()
        {

        }


        private void Update()
        {
            m_InventoryMgr?.OnUpdate();
            m_EquipmentMgr?.OnUpdate();
        }
    }

}