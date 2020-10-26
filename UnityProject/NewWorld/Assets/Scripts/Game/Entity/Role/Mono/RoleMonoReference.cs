/************************
	FileName:/Scripts/Game/Entity/Role/Mono/RoleMonoRefence.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 3:30:07 PM
	Tip:9/25/2020 3:30:07 PM
************************/

using UnityEngine;
using RootMotion.FinalIK;

namespace Game.Logic
{
    //用来存放所有需要拖入的组件 方便其他组件进行引用
    public class RoleMonoReference : MonoBehaviour
    {

        [Header("AnimIK")]
        public LookAtIK lookAtIK;
        public Transform lookTarget;
        public FullBodyBipedIK fullBodyIK;



        [Header("装备挂点")]
        public Transform handLeftAttach;
        public Transform handRightAttach;


    }

}