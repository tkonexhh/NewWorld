/************************
	FileName:/Scripts/Game/Scene/Base/IScene.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:20:33 PM
	Tip:8/25/2020 5:20:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IScene
    {
        void SceneEnter();
        void SceneExit();
    }

}