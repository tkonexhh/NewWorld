/************************
	FileName:/Scripts/Game/Mgr/EnvironmentMgr/EnvironmentMgr.cs
	CreateAuthor:neo.xu
	CreateTime:12/15/2020 6:47:01 PM
	Tip:12/15/2020 6:47:01 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class EnvironmentMgr : GameEngineComponent
    {
        public float time { get; private set; }//24*60*60 按秒算
        private float m_TimeSpeed = 200;

        private List<EnvironmentComponent> _Components = new List<EnvironmentComponent>();

        public override void Init()
        {
            time = GetTime(5, 11, 1);

            _Components.Add(new SkyboxComponent());

            foreach (var com in _Components)
            {
                com.Init(this);
            }

        }

        public override void Update(float dt)
        {
            time += Time.deltaTime * m_TimeSpeed;

            foreach (var com in _Components)
            {
                com.Update(dt);
            }
        }

        public override void FixedUpdate(float dt)
        {
            foreach (var com in _Components)
            {
                com.FixedUpdate(dt);
            }
        }


        public float GetTime(int hour, int min, int sec)
        {
            return sec + min * 60 + hour * 3600;
        }

        public string FormatTime()
        {
            int hour = (int)(time / 3600.0f);
            int min = (int)((time - 3600 * hour) / 60);
            int sec = (int)(time - 3600 * hour - 60 * min);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        }


    }

}