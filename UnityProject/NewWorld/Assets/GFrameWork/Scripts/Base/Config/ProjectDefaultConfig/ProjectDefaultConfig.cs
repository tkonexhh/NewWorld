/************************
	FileName:/GFrameWork/Scripts/Base/Config/ProjectDefaultConfig/ProjectDefaultConfig.cs
	CreateAuthor:neo.xu
	CreateTime:6/24/2020 2:25:48 PM
	Tip:6/24/2020 2:25:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [System.Serializable]
    public class ProjectDefaultConfig : TScriptableObjectSingleton<ProjectDefaultConfig>
    {
        [Header("UI")]
        [SerializeField] private Font m_DefaultTextFont;
        [SerializeField] private Color m_DefaultTextColor = Color.white;
        [Header("Script")]
        [SerializeField] private string m_DefaultNameSpace = "GameWish.Game";


        public static Font defaultTextFont
        {
            get
            {
                if (S.m_DefaultTextFont == null)
                {
                    Resources.GetBuiltinResource<Font>("Arial.ttf");
                }
                return S.m_DefaultTextFont;
            }
            set
            {
                S.m_DefaultTextFont = value;
            }
        }


        public static Color defaultTextColor
        {
            get
            {
                return S.m_DefaultTextColor;
            }
        }


        public static string defaultNameSpace
        {
            get
            {
                if (S == null)
                {
                    return "GameWish.Game";
                }
                else
                {
                    return S.m_DefaultNameSpace;
                }

            }
        }

    }

}