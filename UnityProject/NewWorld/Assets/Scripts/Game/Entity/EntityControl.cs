/************************
	FileName:/Scripts/Game/Entity/EntityControl.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:42:10 PM
	Tip:8/7/2020 5:42:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EntityControl : IEntityControl
    {
        protected Entity m_Entity;
        public EntityControl(Entity entity)
        {
            m_Entity = entity;
        }

        #region IEntityControl
        public virtual void OnInit() { }
        public virtual void OnUpdate(float dt) { }

        #endregion
    }

}