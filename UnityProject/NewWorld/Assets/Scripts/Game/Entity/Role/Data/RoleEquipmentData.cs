/************************
	FileName:/Scripts/Game/Data/Player/PlayerEquipmentData.cs
	CreateAuthor:neo.xu
	CreateTime:9/8/2020 5:55:21 PM
	Tip:9/8/2020 5:55:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    //玩家装备数据唯一来源，其他的必须从这去数据 修改的同时也必须改动他
    public class RoleEquipmentData
    {
        public int helmetID = -1;
        public int torsoID = -1;
        public int handsID = -1;
        public int legsID = -1;
        public int hipsID = -1;
        public int shouldersID = -1;
        public int backID = -1;
    }

}