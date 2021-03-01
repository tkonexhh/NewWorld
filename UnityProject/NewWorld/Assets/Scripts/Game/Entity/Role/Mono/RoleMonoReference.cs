/************************
	FileName:/Scripts/Game/Entity/Role/Mono/RoleMonoRefence.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 3:30:07 PM
	Tip:9/25/2020 3:30:07 PM
************************/

using UnityEngine;
using RootMotion;
using RootMotion.FinalIK;
using GFrame;

namespace Game.Logic
{
    //用来存放所有需要拖入的组件 方便其他组件进行引用
    public class RoleMonoReference : MonoBehaviour
    {
        public Animator animator;

        public Transform lockOn;
        public Transform headLook;
        public Transform kneeLook;

        [Header("AnimIK")]
        public LookAtIK lookAtIK;
        public Transform lookTarget;
        public FullBodyBipedIK fullBodyIK;
        public HandPoser rightHandPoser;
        public HandPoser leftHandPoser;

        public InteractionSystem interactionSystem;

        [Header("装备挂点")]
        public Transform handLeftAttach;
        public Transform handRightAttach;



        public Run<Vector3> onAnimatorMove;

        public float kneeHeight => kneeLook.localPosition.y;



        private void OnAnimatorMove()
        {
            if (onAnimatorMove != null)
            {
                Vector3 deltaPosition = animator.deltaPosition;
                onAnimatorMove(deltaPosition);
            }
        }

    }

}