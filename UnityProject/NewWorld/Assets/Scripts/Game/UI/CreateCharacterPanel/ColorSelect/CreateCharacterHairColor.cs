/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/NewBehaviourScript.cs
	CreateAuthor:neo.xu
	CreateTime:7/10/2020 4:19:36 PM
	Tip:7/10/2020 4:19:36 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class CreateCharacterHairColor : CreateCharacterColorSelect
    {
        protected override List<Color> targetColors
        {
            get
            {
                return CharacterColorConfig.hairColors;
            }
        }

        protected override AppearanceColor colorSlot
        {
            get
            {
                return AppearanceColor.Hair;
            }
        }
    }

}