/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 3:57:22 PM
	Tip:6/12/2020 3:57:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class GamePlayMgr : TMonoSingleton<GamePlayMgr>, IEngineMgr
    {
        protected List<IEngineComponent> _components = new List<IEngineComponent>();
        protected virtual T AddComponent<T>(T component) where T : IEngineComponent
        {
            component.Init(this);
            _components.Add(component);
            return component;
        }

        public override void OnSingletonInit()
        {

        }

        public void Init()
        {
            AddComponent(new GameInputComponent());
        }

        public void Update()
        {
            EntityMgr.S.Update(Time.deltaTime);
            _components.ForEach(p => p.Update(Time.deltaTime));
        }

    }

}