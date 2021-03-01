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
    [TMonoSingletonAttribute("[Game]/[GamePlayMgr]")]
    public class GamePlayMgr : AbstractMgr<GamePlayMgr>
    {
        public PlayerMgr playerMgr { get; private set; }
        public EnvironmentMgr environmentMgr { get; private set; }

        public override void Init()
        {
            AddComponent(new GameInputComponent());
            playerMgr = AddComponent(new PlayerMgr());
            environmentMgr = AddComponent(new EnvironmentMgr());
        }

        public override void Update()
        {
            base.Update();
            EntityMgr.S.Update(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            EntityMgr.S.FixedUpdate(Time.fixedDeltaTime);
        }

    }

}