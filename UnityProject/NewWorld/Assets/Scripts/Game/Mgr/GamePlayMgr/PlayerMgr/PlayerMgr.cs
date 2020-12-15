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
    public class PlayerMgr : IEngineComponent
    {
        private Player m_Player;
        private PlayerInventoryMgr m_InventoryMgr = null;
        private PlayerEquipmentMgr m_EquipmentMgr = null;

        public Role_Player role => m_Player.role;
        public Player player => m_Player;
        public PlayerInventoryMgr inventoryMgr => m_InventoryMgr;
        public PlayerEquipmentMgr equipmentMgr => m_EquipmentMgr;

        public void Init()
        {
            m_InventoryMgr = new PlayerInventoryMgr();
            m_EquipmentMgr = new PlayerEquipmentMgr();

            m_InventoryMgr.OnInit();
            m_EquipmentMgr.OnInit();

            m_Player = new Player();
        }


        public void Update(float dt)
        {
            m_InventoryMgr?.OnUpdate();
            m_EquipmentMgr?.OnUpdate();
        }
    }

}