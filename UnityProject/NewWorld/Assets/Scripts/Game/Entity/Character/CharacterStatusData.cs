/************************
	FileName:/Scripts/Game/Entity/Base/CharacterStatusData.cs
	CreateAuthor:neo.xu
	CreateTime:11/10/2020 10:56:19 AM
	Tip:11/10/2020 10:56:19 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class CharacterStatusData
    {
        public int hp;
        public int maxHp;
        public bool death = false;

        public bool injured => hp < maxHp / 10.0f;//小于1/10血就是受伤状态


        public void GetDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
                death = true;
            }
        }
    }

}