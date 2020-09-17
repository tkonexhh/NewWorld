/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleAnimComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/14/2020 6:20:26 PM
	Tip:9/14/2020 6:20:26 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleAnimComponent : RoleBaseComponent
    {
        private Animator m_Animator;

        public Animator animator => m_Animator;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Animator = role.gameObject.GetComponentInChildren<Animator>();
        }
    }

}