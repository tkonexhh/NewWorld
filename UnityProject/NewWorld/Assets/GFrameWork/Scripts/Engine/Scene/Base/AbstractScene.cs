/************************
	FileName:/Scripts/Game/Scene/Base/AbstractScene.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:20:21 PM
	Tip:8/25/2020 5:20:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AbstractScene : MonoBehaviour, IScene
    {

        private void Awake()
        {
            OnSceneInit();
        }

        private void Start()
        {
            SceneEnter();
        }

        private void OnDestroy()
        {
            SceneExit();
        }

        #region IScene

        public void SceneEnter()
        {
            OnSceneEnter();
        }

        public void SceneExit()
        {
            OnSceneExit();
        }
        #endregion


        protected virtual void OnSceneInit() { }
        protected virtual void OnSceneEnter() { }
        protected virtual void OnSceneExit() { }
    }

}