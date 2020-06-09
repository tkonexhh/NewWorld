/************************
	FileName:/Scripts/Player/PlayerAnim.cs
	CreateAuthor:neo.xu
	CreateTime:6/9/2020 1:46:48 PM
	Tip:6/9/2020 1:46:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class PlayerAnim : MonoBehaviour
    {
        [SerializeField] private AnimationSetting m_AnimationSetting;
        private Animator m_Anim;
        public Animator animator
        {
            get { return m_Anim; }
        }

        //Parameters
        public static readonly int HashInputDetectedBool = Animator.StringToHash("InputDetected");
        public static readonly int HashForwardSpeed = Animator.StringToHash("ForwardSpeed");
        public static readonly int HashVerticalSpeed = Animator.StringToHash("VerticalSpeed");
        public static readonly int HashGroundedBool = Animator.StringToHash("Grounded");
        public static readonly int HasHurtFormX = Animator.StringToHash("HurtFromX");
        public static readonly int HasHurtFormY = Animator.StringToHash("HurtFromY");
        public static readonly int HashTimeoutToIdle = Animator.StringToHash("TimeoutToIdle");
        public static readonly int HashCrouchBool = Animator.StringToHash("Crouch");
        public static readonly int HashRespawnTrigger = Animator.StringToHash("Respawn");
        public static readonly int HashDeadTrigger = Animator.StringToHash("Dead");
        public static readonly int HashHurtTrigger = Animator.StringToHash("Hurt");


        private void Awake()
        {
            m_Anim = GetComponent<Animator>();
        }

    }

}