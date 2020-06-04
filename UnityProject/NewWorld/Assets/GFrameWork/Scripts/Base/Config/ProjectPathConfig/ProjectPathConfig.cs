/************************
	FileName:/GFrameWork/Scripts/Base/Config/ProjectPathConfig/ProjectPathConfig.cs
	CreateAuthor:neo.xu
	CreateTime:4/29/2020 2:43:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [System.Serializable]
    public class ProjectPathConfig : TScriptableObjectSingleton<ProjectPathConfig>
    {
        public string I18NSettingPath = "Resources/Config/I18NConfig";
    }

}