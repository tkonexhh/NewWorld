/************************
	FileName:/Scripts/Game/Entity/Character/CharacterData.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:44:03 PM
	Tip:8/8/2020 9:44:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class RoleData : EntityData
    {
        public BasicAppearance basicAppearance;
        public RoleAppearanceData appearanceData;

        public RoleData(Entity owner) : base(owner)
        {
        }
    }

}