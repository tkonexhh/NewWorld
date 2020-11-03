/************************
	FileName:/Scripts/Game/Entity/Role/Data/RoleStatusData.cs
	CreateAuthor:neo.xu
	CreateTime:10/21/2020 1:58:19 PM
	Tip:10/21/2020 1:58:19 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleStatusData
    {
        public int maxHp;
        public int hp;


        public bool injured => hp < maxHp / 10.0f;//小于1/10血就是受伤状态

    }

}