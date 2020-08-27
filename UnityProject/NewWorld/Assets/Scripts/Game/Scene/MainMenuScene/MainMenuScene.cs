/************************
	FileName:/Scripts/Game/Scene/MainMenuScene/MainMenuScene.cs
	CreateAuthor:neo.xu
	CreateTime:8/27/2020 10:45:36 AM
	Tip:8/27/2020 10:45:36 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;

namespace Game.Logic
{
    public class MainMenuScene : AbstractScene
    {
        protected override void OnSceneInit()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(UIMgr.S.uiRoot.uiCamera);
        }
        protected override void OnSceneEnter()
        {
            UIMgr.S.OpenPanel(UIID.MainMenuPanel);
        }

    }

}