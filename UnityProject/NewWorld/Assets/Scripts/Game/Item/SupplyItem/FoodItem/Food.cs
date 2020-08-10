/************************
	FileName:/Scripts/Game/Item/Food/Food.cs
	CreateAuthor:neo.xu
	CreateTime:7/15/2020 5:38:53 PM
	Tip:7/15/2020 5:38:53 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Food : SupplyItem, IFood
    {
        public override ItemType type
        {
            get { return ItemType.Food; }
        }

        public Food(long id) : base(id)
        {

        }

        public void Eat()
        {

        }
    }

}