/************************
	FileName:/GFrameWork/Scripts/Engine/Component/Module/AbstractStartProcess.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 2:26:29 PM
	Tip:7/7/2020 2:26:29 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AbstractStartProcess : AbstractModule
    {
        protected override void OnModuleAwake()
        {
            InitProcess();
        }


        protected virtual void InitProcess()
        {

        }
    }

}