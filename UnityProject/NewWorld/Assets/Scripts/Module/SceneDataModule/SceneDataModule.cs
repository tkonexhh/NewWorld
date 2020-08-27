/************************
	FileName:/Scripts/Module/SceneDataModule/SceneDataModule.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:48:58 PM
	Tip:8/25/2020 5:48:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GFrame;

namespace Game.Logic
{
    public class SceneDataModule : AbstractComponent
    {
        protected override void OnAwake()
        {
            InitScenePath();
            RegisterScene();
        }

        private void InitScenePath()
        {
            SceneData.SCENE_PATH = "AddressableRes/FolderMode/Scene/{0}";
        }

        private void RegisterScene()
        {
            SceneDataTable.SetLoadMode(SceneLoadStatgy.Addressable);
            SceneDataTable.AddSceneData(SceneID.CreateCharacterScene, "CreateCharacterScene", LoadSceneMode.Single);
            SceneDataTable.AddSceneData(SceneID.MainMenuScene, "MainMenuScene", LoadSceneMode.Single);
        }
    }

}