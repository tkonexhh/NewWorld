/************************
	FileName:/Scripts/Table/Sql/Game/Item/TDItem.cs
	CreateAuthor:neo.xu
	CreateTime:7/15/2020 4:00:50 PM
	Tip:7/15/2020 4:00:50 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public partial class TDItem
    {
        public long id;
        public long subId;
        public string name;
        public string type;
        public string iconName;
        public float weight = 0;

        public ItemType itemType
        {
            get
            {
                switch (type)
                {
                    case "Food":
                        return ItemType.Food;
                    case "Equipment":
                        return ItemType.Equipment;
                }
                return ItemType.Other;
            }
        }
    }

}