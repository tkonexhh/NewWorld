/************************
	FileName:/Scripts/Game/Module/UIDataModule/UIDataModule.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 1:31:05 PM
	Tip:7/7/2020 1:31:05 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class UIDataModule : AbstractComponent
    {
        protected override void OnAwake()
        {
            InitUIPath();
            RegisterPanel();
        }

        private void InitUIPath()
        {
            PanelData.PANEL_PATH = "Resources/UI/Panels/{0}";
        }

        private void RegisterPanel()
        {
            UIDataTable.SetAddressMode(false);

            UIDataTable.AddPanelData(UIID.MainMenuPanel, "MainMenuPanel");
            UIDataTable.AddPanelData(UIID.StartGamePanel, "SetupPanel");
        }
    }

}