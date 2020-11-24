/************************
	FileName:/Scripts/Helper/Animator/StateMachineBehaviour/ApplyRootMotionSMB.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 12:30:39 PM
	Tip:11/24/2020 12:30:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class ApplyRootMotionSMB : StateMachineBehaviour
    {
        public string animKey = "applyRootMotion";

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(animKey, true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(animKey, false);
        }
    }

}