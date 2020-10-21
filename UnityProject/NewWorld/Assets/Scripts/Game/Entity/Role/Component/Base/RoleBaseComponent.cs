/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleBaseComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/17/2020 8:34:53 PM
	Tip:9/17/2020 8:34:53 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleBaseComponent : EntityComponennt
    {
        protected Role role;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            role = ownner as Role;
        }
    }

}