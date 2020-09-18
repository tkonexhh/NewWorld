/************************
	FileName:/Scripts/Game/Entity/Entity.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:21:37 PM
	Tip:8/8/2020 9:21:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Entity
    {
        protected List<EntityComponennt> _components = new List<EntityComponennt>();

        public Entity()
        {

        }

        protected virtual T AddComponent<T>(T component) where T : EntityComponennt
        {
            component.Init(this);
            _components.Add(component);
            return component;
        }

        protected virtual void Start()
        {
            _components.ForEach(p => p.Start());
        }

        public virtual void Update(float dt)
        {
            _components.ForEach(p => p.Update(dt));
        }

    }

}