/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateCharacterSkinColor.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 5:14:26 PM
	Tip:7/10/2020 5:14:26 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class CreateCharacterSkinColor : CreateCharacterColorSelect
    {
        protected override List<Color> targetColors
        {
            get
            {
                return CharacterColorConfig.skinColors;
            }
        }

        protected override AppearanceColor colorSlot
        {
            get
            {
                return AppearanceColor.Skin;
            }
        }
    }

}