/************************
	FileName:/Scripts/Game/Item/StackableItem.cs
	CreateAuthor:xuhonghua
	CreateTime:8/10/2020 10:16:37 PM
	Tip:8/10/2020 10:16:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class StackableItem : AbstractItem
    {
        public int num { get; set; }

        public StackableItem(long id) : base(id)
        {

        }
    }

}