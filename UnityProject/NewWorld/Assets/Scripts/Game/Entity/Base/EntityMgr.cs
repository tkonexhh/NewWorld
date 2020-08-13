/************************
	FileName:/Scripts/Game/Entity/EntityMgr.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:37:17 PM
	Tip:8/8/2020 9:37:17 PM
************************/


using UnityEngine;
using System.Collections.Generic;
using GFrame;

namespace Game.Logic
{
    public class EntityMgr : TSingleton<EntityMgr>
    {
        private int _nCounter = 0;
        List<Entity> _entities = new List<Entity>();

        public void RegisterEntity(Entity entity)
        {
            //entity.EntityID = _nCounter++;
            _entities.Add(entity);
        }

        public void UnRegisterEntity(Entity entity)
        {
            _entities.Remove(entity);
            //entity.Dispose();
        }

        public void Tick(float fDeltaTime)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                _entities[i].Tick(fDeltaTime);
            }
        }
    }

}