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
        private Role_Player m_Role;

        public Role_Player role => m_Role;

        public delegate void OnRoleCreated(Role role);
        public OnRoleCreated onRoleCreated;

        public Player() : base()
        {
            AddressableResMgr.S.InstantiateAsync("Player", (target) =>
            {
                m_Role = new Role_Player();
                m_Role.transform.SetParent(target.transform);
            });

        }
    }

}