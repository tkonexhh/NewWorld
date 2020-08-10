/************************
	FileName:/Scripts/Game/Item/Supply/SupplyItem.cs
	CreateAuthor:neo.xu
	CreateTime:7/15/2020 5:41:55 PM
	Tip:7/15/2020 5:41:55 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class SupplyItem : StackableItem
    {
        public override ItemType type
        {
            get { return ItemType.Other; }
        }

        public SupplyItem(long id) : base(id)
        {

        }

        public SupplyItem(long id, int num) : base(id)
        {
            this.num = num;
        }

        public void AddNum(int num)
        {
            this.num += num;
        }
    }

}