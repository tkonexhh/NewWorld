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
        public readonly float walkSpeed = 1.5f;//移动最大速度
        public readonly float runSpeed = 1.5f * 2.5f;
        public readonly float acceleration = 7;//移动最大加速度//不能小于5
        public readonly float airAcceleration = 1;//空中的加速度
        public readonly float jumpHeight = 1.0f;
        public readonly float jumpCount = 2;//多段跳
    }

}