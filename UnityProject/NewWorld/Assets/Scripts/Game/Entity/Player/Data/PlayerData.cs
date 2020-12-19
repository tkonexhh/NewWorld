/************************
	FileName:/Scripts/Game/Entity/Player/PlayerData.cs
	CreateAuthor:neo.xu
	CreateTime:11/10/2020 10:49:01 AM
	Tip:11/10/2020 10:49:01 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerData : EntityData
    {
        public static int jumpCount = 0;
        public PlayerData(Entity owner) : base(owner)
        {

        }
    }

}