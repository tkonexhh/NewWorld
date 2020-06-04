/************************
	FileName:/GFrameWork/Scripts/Engine/App/ApplicationMgr.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 11:29:14 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[App]/[ApplicationMgr]")]
    public partial class ApplicationMgr : TMonoSingleton<ApplicationMgr>
    {

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
        }



    }

}