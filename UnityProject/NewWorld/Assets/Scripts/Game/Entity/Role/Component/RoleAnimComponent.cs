/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleAnimComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/14/2020 6:20:26 PM
	Tip:9/14/2020 6:20:26 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleAnimComponent : RoleBaseComponent
    {
        private Animator m_Animator;

        private string m_Key_BoolMoving = "Moving";
        private string m_Key_IntTalking = "Talking";
        private string m_Key_FloatVelocityX = "Velocity X";
        private string m_Key_FloatVelocityZ = "Velocity Z";

        private int m_KeyHash_BoolMoving;
        private int m_KeyHash_IntTalking;
        private int m_KeyHash_FloatVelocityX;
        private int m_KeyHash_FloatVelocityZ;

        public Animator animator => m_Animator;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Animator = role.gameObject.GetComponentInChildren<Animator>();

            m_KeyHash_BoolMoving = Animator.StringToHash(m_Key_BoolMoving);
            m_KeyHash_IntTalking = Animator.StringToHash(m_Key_IntTalking);
            m_KeyHash_FloatVelocityX = Animator.StringToHash(m_Key_FloatVelocityX);
            m_KeyHash_FloatVelocityZ = Animator.StringToHash(m_Key_FloatVelocityZ);
        }


        public void SetVelocity(Vector2 vec)
        {
            m_Animator.SetBool(m_KeyHash_BoolMoving, true);
            m_Animator.SetFloat(m_KeyHash_FloatVelocityX, vec.x);
            m_Animator.SetFloat(m_KeyHash_FloatVelocityZ, vec.y);
        }
    }

}