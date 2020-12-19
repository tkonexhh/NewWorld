/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr/EnvironmentMgr/Component/EnvironmentComponent.cs
	CreateAuthor:neo.xu
	CreateTime:12/17/2020 8:00:55 PM
	Tip:12/17/2020 8:00:55 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EnvironmentComponent
    {
        protected EnvironmentMgr environmentMgr;
        public virtual void Init(EnvironmentMgr mgr)
        {
            environmentMgr = mgr;
        }

        public virtual void Update(float dt) { }
        public virtual void FixedUpdate(float dt) { }
    }

}