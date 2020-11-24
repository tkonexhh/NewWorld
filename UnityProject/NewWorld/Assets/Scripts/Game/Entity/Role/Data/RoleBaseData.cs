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
        public readonly float acceleration = 14;//移动最大加速度//不能小于5
        public readonly float maxGroundAngle = 60;//最大地面角度//超过这个角度要下降
        public readonly float airAcceleration = 4;//空中的加速度
        public readonly float jumpHeight = 1.0f;
        public readonly int jumpCount = 2;//多段跳
        public readonly float fallSpeed = 160;//下落速度
    }

}