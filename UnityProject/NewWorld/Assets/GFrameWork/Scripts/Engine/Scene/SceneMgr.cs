/************************
	FileName:/Scripts/Game/Scene/Mgr/SceneMgr.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:23:42 PM
	Tip:8/25/2020 5:23:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[SceneMgr]")]
    public class SceneMgr : TMonoSingleton<SceneMgr>
    {

        public override void OnSingletonInit()
        {

        }

        public void Init()
        {
            Log.i("#Init[SceneMgr]");
        }

        public void OpenScene<T>(T sceneID, params object[] args) where T : System.IConvertible
        {

        }
    }

}