/************************
	FileName:/Scripts/Game/Entity/Role/Data/RoleBaseData.cs
	CreateAuthor:neo.xu
	CreateTime:11/3/2020 2:04:30 PM
	Tip:11/3/2020 2:04:30 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleBaseData
    {
        public readonly float walkSpeed = 1.4f;//移动最大速度
        public readonly float runSpeed = 4f;
        public readonly float jumpHeight = 6.0f;
        public readonly int jumpCount = 2;//多段跳
        public readonly float fallSpeed = 170;//下落速度
    }

}