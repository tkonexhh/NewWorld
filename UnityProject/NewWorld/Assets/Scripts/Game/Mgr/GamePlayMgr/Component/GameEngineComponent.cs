/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr/Component/GameEngineComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 2:01:38 PM
	Tip:9/25/2020 2:01:38 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public abstract class GameEngineComponent : IEngineComponent
    {
        public virtual void Init(IEngineMgr mgr) { }

        public virtual void Update(float dt) { }
    }


}