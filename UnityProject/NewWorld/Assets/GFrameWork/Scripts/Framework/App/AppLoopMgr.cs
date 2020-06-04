/************************
	
	主要給非Mono的提供update的方法
************************/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame][App]/[AppLoopMgr]")]
    public class AppLoopMgr : TMonoSingleton<AppLoopMgr>
    {
        public event Action onUpdate;

        private void Update()
        {
            if (onUpdate != null)
            {
                try
                {
                    onUpdate();
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }
        }
    }
}
