/************************
	FileName:/GFrameWork/Scripts/Engine/App/ApplicationMgr.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 11:29:14 AM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[App]/[ApplicationMgr]")]
    public partial class ApplicationMgr : TMonoSingleton<ApplicationMgr>
    {
        public Action onApplicationUpdate = null;
        public Action onApplicationOnGUI = null;

        private void Start()
        {
            StartApp();
        }

        private void StartApp()
        {
            InitConfig();
            StartGame();
        }

        private void InitConfig()
        {

        }

        private void StartGame()
        {
            Debug.LogError("StartGame");
            UIMgr.S.Init();
        }

        private void OnApplicationQuit()
        {
            EventSystem.S.Send(EngineEventID.OnApplicationQuit);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            EventSystem.S.Send(EngineEventID.OnApplicationPauseChange, pauseStatus);
        }

        private void OnApplicationFocus(bool focusStatus)
        {
            EventSystem.S.Send(EngineEventID.OnApplicationFocusChange, focusStatus);
        }

    }

}