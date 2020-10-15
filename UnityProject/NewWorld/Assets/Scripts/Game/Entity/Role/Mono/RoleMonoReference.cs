/************************
	FileName:/Scripts/Game/Entity/Role/Mono/RoleMonoRefence.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 3:30:07 PM
	Tip:9/25/2020 3:30:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Game.Logic
{
    //用来存放所有需要拖入的组件 方便其他组件进行引用
    public class RoleMonoReference : MonoBehaviour
    {
        [Header("AnimIK")]
        public MultiAimConstraint headIK;
        public Transform headAimTarget;

        [Header("Transform")]
        public Transform boneHead;

        // [Header("装备挂点")]
        public Transform boneHandLeft;
        public Transform boneHandRight;

    }

}