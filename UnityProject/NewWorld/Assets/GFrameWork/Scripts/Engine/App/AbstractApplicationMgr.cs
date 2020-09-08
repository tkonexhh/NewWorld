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
    public class AbstractApplicationMgr<T> : TMonoSingleton<T> where T : TMonoSingleton<T>
    {

        private void Start()
        {
            StartApp();
        }

        private void StartApp()
        {
            InitConfig();
            InitGame();
            StartGame();
        }

        protected virtual void InitConfig()
        {

        }

        private void InitGame()
        {
            UIMgr.S.Init();
            SceneMgr.S.Init();
        }

        protected virtual void StartGame()
        {

        }

        private void OnApplicationQuit()
        {
            EventSystem.S.Send(EngineEventID.OnApplicationQuit);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            EventSystem.S.Send(EngineEventID.OnApplicationPauseChange, pauseStatus);
            EventSystem.S.Send(EngineEventID.OnAfterApplicationPauseChange, pauseStatus);
        }

        private void OnApplicationFocus(bool focusStatus)
        {
            EventSystem.S.Send(EngineEventID.OnApplicationFocusChange, focusStatus);
            EventSystem.S.Send(EngineEventID.OnAfterApplicationFocusChange, focusStatus);
        }

    }

}