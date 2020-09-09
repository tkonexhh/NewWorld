/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/ColorSelect/CreateCharacterBodyArtColor.cs
	CreateAuthor:neo.xu
	CreateTime:9/9/2020 1:22:12 PM
	Tip:9/9/2020 1:22:12 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class CreateCharacterBodyArtColor : CreateCharacterColorSelect
    {
        protected override List<Color> targetColors => CharacterColorConfig.bodyColors;
        protected override AppearanceColor colorSlot => AppearanceColor.BodyArt;
    }

}