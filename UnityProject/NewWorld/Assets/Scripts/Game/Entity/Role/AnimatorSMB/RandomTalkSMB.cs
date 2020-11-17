/************************
	FileName:/Scripts/Game/Entity/Role/AnimatorSMB/RandomTalkSMB.cs
	CreateAuthor:neo.xu
	CreateTime:11/17/2020 1:32:28 PM
	Tip:11/17/2020 1:32:28 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RandomTalkSMB : StateMachineBehaviour
    {
        public int talkingNum = 8;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!animator.IsInTransition(layerIndex) && stateInfo.normalizedTime >= 1)
            {
                string animName = "Talk" + Random.Range(1, talkingNum + 1);
                animator.CrossFade(animName, 0.2f, 0, 0f);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }

}