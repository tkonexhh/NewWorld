/************************
	FileName:/Scripts/Game/Entity/Player/Player.cs
	CreateAuthor:neo.xu
	CreateTime:10/21/2020 2:32:03 PM
	Tip:10/21/2020 2:32:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class Player : Entity
    {
        private GameObject m_GameObject;
        private Transform m_Transform;
        private PlayerData m_Data;
        private Role_Player m_Role;

        private PlayerMonoReference m_MonoReference;
        private PlayerControlComponent m_ControlComponent;
        private PlayerFSMComponent m_FSMComponent;

        public PlayerMonoReference monoReference => m_MonoReference;
        public PlayerControlComponent controlComponent => m_ControlComponent;
        public PlayerFSMComponent fsmComponent => m_FSMComponent;


        public Role_Player role => m_Role;

        public delegate void OnPlayerCreated(Player role);
        public OnPlayerCreated onPlayerCreated;

        public Player() : base()
        {
            m_Data = new PlayerData(this);
            AddressableResMgr.S.InstantiateAsync("Player", (target) =>
            {
                m_GameObject = target;
                m_Transform = target.transform;

                m_MonoReference = target.GetComponent<PlayerMonoReference>();

                m_Role = new Role_Player();
                m_Role.onRoleCreated += (role) =>
                {
                    role.gameObject.name = "Role";
                    m_Role.transform.SetParent(m_Transform);
                    m_FSMComponent = AddComponent(new PlayerFSMComponent());
                    m_ControlComponent = AddComponent(new PlayerControlComponent());

                    if (onPlayerCreated != null)
                    {
                        onPlayerCreated(this);
                    }
                };
            });

            EntityMgr.S.RegisterEntity(this);

        }
    }

}