/************************
	FileName:/Scripts/Game/SetupScene/SetupScene.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 8:27:07 PM
	Tip:7/9/2020 8:27:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;


namespace Game.Logic
{
    public class CreateCharacterScene : AbstractScene
    {

        protected override void OnSceneInit()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(UIMgr.S.uiRoot.uiCamera);
        }

        protected override void OnSceneEnter()
        {
            // UIMgr.S.OpenPanel(UIID.CreateCharacterPanel);
            UIMgr.S.OpenPanel(UIID.Inventorypanel);
        }

    }

}