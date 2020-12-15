/************************
	FileName:/Scripts/Game/Mgr/Base/AbstractMgr.cs
	CreateAuthor:neo.xu
	CreateTime:12/15/2020 6:59:31 PM
	Tip:12/15/2020 6:59:31 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public abstract class AbstractMgr<T> : TMonoSingleton<T>, IEngineMgr where T : TMonoSingleton<T>
    {
        protected List<IEngineComponent> _components = new List<IEngineComponent>();
        protected virtual C AddComponent<C>(C component) where C : IEngineComponent
        {
            component.Init();
            _components.Add(component);
            return component;
        }

        public virtual void Init() { }

        public virtual void Update()
        {
            _components.ForEach(p => p.Update(Time.deltaTime));
        }

    }

}