/************************
	FileName:/Scripts/Config/CharacterColorConfig.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 4:26:10 PM
	Tip:7/10/2020 4:26:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    [System.Serializable]
    public class CharacterColorConfig : TScriptableObjectSingleton<CharacterColorConfig>
    {
        [SerializeField] private List<Color> m_HairColors;
        [SerializeField] private List<Color> m_SkinColors;

        public static List<Color> hairColors
        {
            get
            {
                return S.m_HairColors;
            }
        }

        public static List<Color> skinColors
        {
            get
            {
                return S.m_SkinColors;
            }
        }

    }

}