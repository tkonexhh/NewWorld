/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleBaseMonoComponent.cs
	CreateAuthor:neo.xu
	CreateTime:10/21/2020 5:17:23 PM
	Tip:10/21/2020 5:17:23 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleBaseMonoComponent : EntityMonoComponennt
    {
        protected Role role;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            role = ownner as Role;
        }
    }

}