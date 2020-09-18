/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 5:08:33 PM
	Tip:9/18/2020 5:08:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleControlComponent : RoleBaseComponent
    {
        private bool isDead = false;
        private bool isInjured = false;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
        }
    }

}