/************************
	FileName:/Scripts/Game/Item/ItemEnum.cs
	CreateAuthor:neo.xu
	CreateTime:7/13/2020 6:05:28 PM
	Tip:7/13/2020 6:05:28 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public enum ItemType
    {
        Equipment,
        Food,
        Other,
    }

    public enum ItemQuality
    {
        Common,
        UnCommon,
        Rare,//稀有
        Lengend,//传说
    }

}