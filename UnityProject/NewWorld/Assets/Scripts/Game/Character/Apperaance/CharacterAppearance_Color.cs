/************************
	FileName:/Scripts/Game/Character/Apperaance/CharacterAppearance_Color.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 5:08:10 PM
	Tip:7/10/2020 5:08:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public partial class CharacterAppearance : MonoBehaviour
    {

        public void SetColor(AppearanceColor appearance, Color color)
        {
            color.a = 1;
            switch (appearance)
            {
                case AppearanceColor.Hair:
                    SetHairColor(color);
                    break;
                case AppearanceColor.Skin:
                    SetSkinColor(color);
                    break;
            }
        }

        public void SetHairColor(Color color)
        {
            material.SetColor("_Color_Hair", color);
            material.SetColor("_Color_Stubble", color * 0.75f);

        }

        public void SetSkinColor(Color color)
        {
            material.SetColor("_Color_Skin", color);
        }
    }

}