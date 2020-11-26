/************************
	FileName:/Scripts/Game/Entity/Role/AnimatorSMB/ResetBoolSMB.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 4:42:10 PM
	Tip:11/25/2020 4:42:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class ResetBoolSMB : StateMachineBehaviour
    {
        public string boolName = "InterActing";

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(boolName, true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(boolName, false);
        }
    }

}