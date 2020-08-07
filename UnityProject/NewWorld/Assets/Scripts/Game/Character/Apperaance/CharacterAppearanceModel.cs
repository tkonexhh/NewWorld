/************************
	FileName:/Scripts/Game/Character/Apperaance/CharacterAppearanceModel.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:41:01 PM
	Tip:8/7/2020 5:41:01 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class CharacterAppearanceModel : EntityModel
    {
        public CharacterAppearanceData m_AppearanceData;


        public override void Init(IEntityControl entityControl)
        {
            m_EntityControl = entityControl;
        }
    }

}