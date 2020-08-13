/************************
	FileName:/Scripts/Game/Entity/EntityModel.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:41:37 PM
	Tip:8/7/2020 5:41:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EntityData
    {
        protected Entity m_Owner;

        public EntityData(Entity owner)
        {
            m_Owner = owner;
        }
    }

}