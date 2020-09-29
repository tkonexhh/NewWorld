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
        private string m_Key_BoolBlock = "Blocking";

        private string m_Key_IntTalking = "Talking";
        private string m_Key_IntAction = "Action";

        private string m_Key_FloatVelocityX = "Velocity X";
        private string m_Key_FloatVelocityZ = "Velocity Z";

        private string m_Key_Trigger_TurnLeft = "TurnLeftTrigger";
        private string m_Key_Trigger_TurnRight = "TurnLeftTrigger";
        private string m_Key_Trigger_Action = "ActionTrigger";
        private string m_Key_Trigger_WeaponSheath = "WeaponSheathTrigger";
        private string m_Key_Trigger_WeaponUnSheath = "WeaponUnsheathTrigger";
        private string m_Key_Trigger_Death = "DeathTrigger";
        private string m_Key_Trigger_Revive = "ReviveTrigger";
        private string m_Key_Trigger_GetHurt = "GetHurtTrigger";
        private string m_Key_Trigger_Block = "BlockTrigger";
        private string m_Key_Trigger_BlockBreak = "BlockBreakTrigger";

        private int m_KeyHash_BoolMoving;
        private int m_KeyHash_BoolInjured;
        private int m_KeyHash_BoolCrouch;
        private int m_KeyHash_BoolBlock;

        private int m_KeyHash_IntTalking;
        private int m_KeyHash_IntAction;

        private int m_KeyHash_FloatVelocityX;
        private int m_KeyHash_FloatVelocityZ;

        private int m_KeyHash_TriggerTurnLeft;
        private int m_KeyHash_TriggerTurnRight;
        private int m_KeyHash_TriggerAction;
        private int m_KeyHash_TriggerWeaponSheath;
        private int m_KeyHash_TriggerWeaponUnSheath;
        private int m_KeyHash_TriggerDeath;
        private int m_KeyHash_TriggerRevive;
        private int m_KeyHash_TriggerGetHurt;
        private int m_KeyHash_TriggerBlock;
        private int m_KeyHash_TriggerBlockBreak;

        public Animator animator => m_Animator;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Animator = role.gameObject.GetComponentInChildren<Animator>();

            m_KeyHash_BoolMoving = Animator.StringToHash(m_Key_BoolMoving);
            m_KeyHash_BoolInjured = Animator.StringToHash(m_Key_BoolInjured);
            m_KeyHash_BoolCrouch = Animator.StringToHash(m_Key_BoolCrouch);
            m_KeyHash_BoolBlock = Animator.StringToHash(m_Key_BoolBlock);
            m_KeyHash_IntTalking = Animator.StringToHash(m_Key_IntTalking);
            m_KeyHash_IntAction = Animator.StringToHash(m_Key_IntAction);
            m_KeyHash_FloatVelocityX = Animator.StringToHash(m_Key_FloatVelocityX);
            m_KeyHash_FloatVelocityZ = Animator.StringToHash(m_Key_FloatVelocityZ);
            m_KeyHash_TriggerTurnLeft = Animator.StringToHash(m_Key_Trigger_TurnLeft);
            m_KeyHash_TriggerTurnRight = Animator.StringToHash(m_Key_Trigger_TurnRight);
            m_KeyHash_TriggerAction = Animator.StringToHash(m_Key_Trigger_Action);
            m_KeyHash_TriggerWeaponSheath = Animator.StringToHash(m_Key_Trigger_WeaponSheath);
            m_KeyHash_TriggerWeaponUnSheath = Animator.StringToHash(m_Key_Trigger_WeaponUnSheath);
            m_KeyHash_TriggerDeath = Animator.StringToHash(m_Key_Trigger_Death);
            m_KeyHash_TriggerRevive = Animator.StringToHash(m_Key_Trigger_Revive);
            m_KeyHash_TriggerGetHurt = Animator.StringToHash(m_Key_Trigger_GetHurt);
            m_KeyHash_TriggerBlock = Animator.StringToHash(m_Key_Trigger_Block);
            m_KeyHash_TriggerBlockBreak = Animator.StringToHash(m_Key_Trigger_BlockBreak);
        }


        public void SetVelocity(Vector2 vec)
        {
            m_Animator.SetFloat(m_KeyHash_FloatVelocityX, vec.x);
            m_Animator.SetFloat(m_KeyHash_FloatVelocityZ, vec.y);
        }
        #region bool
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

        public void SetBlocking(bool block)
        {
            m_Animator.SetBool(m_KeyHash_BoolBlock, block);
        }
        #endregion

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

        public void SetWeaponSheathTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerWeaponSheath);
        }

        public void SetWeaponUnSheathTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerWeaponUnSheath);
        }

        public void SetDeathTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerDeath);
        }

        public void SetReviveTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerRevive);
        }

        public void SetGetHurtTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerGetHurt);
        }

        public void SetBlockTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerBlock);
        }

        public void SetBlockBreakTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerBlockBreak);
        }
    }

}