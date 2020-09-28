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
        private string m_Key_BoolInjured = "Injured";
        private string m_Key_BoolCrouch = "Crouch";

        private string m_Key_IntTalking = "Talking";
        private string m_Key_IntAction = "Action";
        private string m_Key_FloatVelocityX = "Velocity X";
        private string m_Key_FloatVelocityZ = "Velocity Z";
        private string m_Key_Trigger_TurnLeft = "TurnLeftTrigger";
        private string m_Key_Trigger_TurnRight = "TurnLeftTrigger";
        private string m_Key_Trigger_Action = "ActionTrigger";

        private int m_KeyHash_BoolMoving;
        private int m_KeyHash_BoolInjured;
        private int m_KeyHash_BoolCrouch;
        private int m_KeyHash_IntTalking;
        private int m_KeyHash_IntAction;
        private int m_KeyHash_FloatVelocityX;
        private int m_KeyHash_FloatVelocityZ;
        private int m_KeyHash_TriggerTurnLeft;
        private int m_KeyHash_TriggerTurnRight;
        private int m_KeyHash_TriggerAction;

        public Animator animator => m_Animator;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Animator = role.gameObject.GetComponentInChildren<Animator>();

            m_KeyHash_BoolMoving = Animator.StringToHash(m_Key_BoolMoving);
            m_KeyHash_BoolInjured = Animator.StringToHash(m_Key_BoolInjured);
            m_KeyHash_BoolCrouch = Animator.StringToHash(m_Key_BoolCrouch);
            m_KeyHash_IntTalking = Animator.StringToHash(m_Key_IntTalking);
            m_KeyHash_IntAction = Animator.StringToHash(m_Key_IntAction);
            m_KeyHash_FloatVelocityX = Animator.StringToHash(m_Key_FloatVelocityX);
            m_KeyHash_FloatVelocityZ = Animator.StringToHash(m_Key_FloatVelocityZ);
            m_KeyHash_TriggerTurnLeft = Animator.StringToHash(m_Key_Trigger_TurnLeft);
            m_KeyHash_TriggerTurnRight = Animator.StringToHash(m_Key_Trigger_TurnRight);
            m_KeyHash_TriggerAction = Animator.StringToHash(m_Key_Trigger_Action);
        }


        public void SetVelocity(Vector2 vec)
        {
            //m_Animator.SetBool(m_KeyHash_BoolMoving, true);
            m_Animator.SetFloat(m_KeyHash_FloatVelocityX, vec.x);
            m_Animator.SetFloat(m_KeyHash_FloatVelocityZ, vec.y);
        }

        public void SetMoving(bool moving)
        {
            m_Animator.SetBool(m_KeyHash_BoolMoving, moving);
        }

        public void SetInjured(bool injured)
        {
            m_Animator.SetBool(m_KeyHash_BoolInjured, injured);
        }

        public void SetCrouch(bool crouch)
        {
            m_Animator.SetBool(m_KeyHash_BoolCrouch, crouch);
        }

        public void SetTalking(int index)
        {
            m_Animator.SetInteger(m_KeyHash_IntTalking, index);
        }

        public void SetAction(int index)
        {
            m_Animator.SetInteger(m_KeyHash_IntAction, index);
        }

        public void SetActionTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerAction);
        }
    }

}