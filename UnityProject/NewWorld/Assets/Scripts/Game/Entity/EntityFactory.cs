/************************
	FileName:/Scripts/Game/Entity/EntityFactory.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 11:17:47 AM
	Tip:9/18/2020 11:17:47 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EntityFactory
    {
        public static Role CreateRole()
        {
            Role role = new Role();
            EntityMgr.S.RegisterEntity(role);

            return role;
        }
    }

}