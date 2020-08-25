/************************
	FileName:/Scripts/Game/Scene/Base/AbstractScene.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:20:21 PM
	Tip:8/25/2020 5:20:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class AbstractScene : MonoBehaviour, IScene
    {
        #region IScene

        public void EnterScene()
        {

        }

        public void ExitScene()
        {

        }
        #endregion

        protected virtual void OnEnterScene() { }
        protected virtual void OnExitScene() { }
    }

}