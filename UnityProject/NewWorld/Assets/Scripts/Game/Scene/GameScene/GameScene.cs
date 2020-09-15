/************************
	FileName:/Scripts/Game/Scene/GameScene/GameScene.cs
	CreateAuthor:neo.xu
	CreateTime:9/15/2020 7:16:31 PM
	Tip:9/15/2020 7:16:31 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;

namespace Game.Logic
{
    public class GameScene : AbstractScene
    {
        protected override void OnSceneInit()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(UIMgr.S.uiRoot.uiCamera);
        }
        protected override void OnSceneEnter()
        {
            //PlayerMgr.S.role.transform.SetXYZ(Vector3.zero);
        }
    }

}