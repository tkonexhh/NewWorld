using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{
    public static class AnimatorExtensions
    {
        public static void OnAnimComplete(this Animator animator, Action callback)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

            float length = animator.GetCurrentAnimatorStateInfo(0).length;
            Timer.S.Post2Really(i =>
            {
                if (callback != null)
                    callback.Invoke();
            }, length);
        }
    }
}
