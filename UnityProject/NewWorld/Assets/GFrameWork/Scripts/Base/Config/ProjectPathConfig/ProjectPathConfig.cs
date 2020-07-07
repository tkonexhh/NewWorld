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
        [SerializeField] private string m_UIRootPath = "Resources/UI/UIRoot";
        [SerializeField] private string m_TableCsharpPath = "Resources/Scripts/Table/";
        [SerializeField] private string m_DataBasepath = "Resources/Data/";

        public static string uiRootPath
        {
            get
            {
                return S.m_UIRootPath;
            }
        }

        public static string tableCsharpPath
        {
            get
            {
                return S.m_TableCsharpPath;
            }
        }

        public static string DataBasePath
        {
            get
            {
                return S.m_DataBasepath;
            }
        }
    }

}