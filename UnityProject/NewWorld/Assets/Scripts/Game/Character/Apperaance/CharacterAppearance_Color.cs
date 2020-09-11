/************************
	FileName:/Scripts/Game/Character/Apperaance/CharacterAppearance_Color.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 5:08:10 PM
	Tip:7/10/2020 5:08:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public partial class CharacterAppearance : MonoBehaviour
    {
        private int m_ShaderHash_ColorBodyArt;
        private int m_ShaderHash_ColorHair;
        private int m_ShaderHash_ColorStubble;
        private int m_ShaderHash_ColorSkin;
        private int m_ShaderHash_ColorScar;

        public void InitColor()
        {
            m_ShaderHash_ColorBodyArt = Shader.PropertyToID("_Color_BodyArt");
            m_ShaderHash_ColorHair = Shader.PropertyToID("_Color_Hair");
            m_ShaderHash_ColorStubble = Shader.PropertyToID("_Color_Stubble");
            m_ShaderHash_ColorSkin = Shader.PropertyToID("_Color_Skin");
            m_ShaderHash_ColorScar = Shader.PropertyToID("_Color_Scar");
        }

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
                case AppearanceColor.BodyArt:
                    SetBodyArtColor(color);
                    break;
            }
        }

        public void SetHairColor(Color color)
        {
            material.SetColor(m_ShaderHash_ColorHair, color);
            material.SetColor(m_ShaderHash_ColorStubble, color * 0.75f);
        }

        public void SetSkinColor(Color color)
        {
            material.SetColor(m_ShaderHash_ColorSkin, color);
            material.SetColor(m_ShaderHash_ColorScar, color * 0.65f);//伤疤的颜色比皮肤颜色要深
        }

        public void SetBodyArtColor(Color color)
        {
            material.SetColor(m_ShaderHash_ColorBodyArt, color);
        }
    }

}