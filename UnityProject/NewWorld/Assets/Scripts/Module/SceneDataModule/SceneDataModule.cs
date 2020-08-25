/************************
	FileName:/Scripts/Module/SceneDataModule/SceneDataModule.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:48:58 PM
	Tip:8/25/2020 5:48:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class SceneDataModule : AbstractComponent
    {
        protected override void OnAwake()
        {
            InitScenePath();
            // RegisterPanel();
        }

        private void InitScenePath()
        {
            SceneData.SCENE_PATH = "Resources/UI/Panels/{0}";
        }

        private void RegisterScene()
        {
            SceneDataTable.SetLoadMode(LoadStrategy.Addressable);

            SceneDataTable.AddSceneData(SceneID.CreateCharacterScene, "CreateCharacterScene");
            //     UIDataTable.SetAddressMode(false);

            //     UIDataTable.AddPanelData(UIID.MainMenuPanel, "MainMenuPanel");
            //     UIDataTable.AddPanelData(UIID.LoadingPanel, "LoadingPanel");
            //     UIDataTable.AddPanelData(UIID.CreateCharacterPanel, "CreateCharacterPanel");

            //     UIDataTable.AddPanelData(UIID.Inventorypanel, "Inventorypanel");
        }
    }

}