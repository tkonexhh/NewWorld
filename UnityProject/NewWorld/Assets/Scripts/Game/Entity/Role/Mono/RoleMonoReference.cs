/************************
	FileName:/Scripts/Game/Entity/Role/Mono/RoleMonoRefence.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 3:30:07 PM
	Tip:9/25/2020 3:30:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    //用来存放所有需要拖入的组件 方便其他组件进行引用
    public class RoleMonoReference : MonoBehaviour
    {
        [Header("AnimIK")]
        public Transform headAnimIK;

        public Transform transRoleHead;

    }

}