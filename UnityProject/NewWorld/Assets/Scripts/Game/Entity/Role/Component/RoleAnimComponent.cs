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
        private string m_Key_IntLeftRight = "LeftRight";
        private string m_Key_IntWeapon = "Weapon";
        private string m_Key_IntWeaponSwitch = "WeaponSwitch";

        private string m_Key_FloatVelocityX = "Velocity X";
        private string m_Key_FloatVelocityZ = "Velocity Z";
        private string m_Key_FloatHurtX = "Hurt X";
        private string m_Key_FloatHurtZ = "Hurt Z";

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
        private string m_Key_Trigger_Cast = "CastTrigger";
        private string m_Key_Trigger_AttackCast = "AttackCastTrigger";
        private string m_Key_Trigger_CastEnd = "CastEndTrigger";
        private string m_Key_Trigger_Attack = "AttackTrigger";
        private string m_Key_Trigger_AttackKick = "AttackKickTrigger";
        private string m_Key_Trigger_Swim = "SwimTrigger";

        private int m_KeyHash_BoolMoving;
        private int m_KeyHash_BoolInjured;
        private int m_KeyHash_BoolCrouch;
        private int m_KeyHash_BoolBlock;

        private int m_KeyHash_IntTalking;
        private int m_KeyHash_IntAction;
        private int m_KeyHash_IntLeftRight;
        private int m_KeyHash_IntWeapon;
        private int m_KeyHash_IntWeaponSwitch;

        private int m_KeyHash_FloatVelocityX;
        private int m_KeyHash_FloatVelocityZ;
        private int m_KeyHash_FloatHurtX;
        private int m_KeyHash_FloatHurtZ;

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
        private int m_KeyHash_TriggerCast;
        private int m_KeyHash_TriggerAttackCast;
        private int m_KeyHash_TriggerCastEnd;
        private int m_KeyHash_TriggerAttact;
        private int m_KeyHash_TriggerAttactKick;
        private int m_KeyHash_TriggerSwim;


        public Animator animator => m_Animator;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Animator = role.roleGameObject.GetComponentInChildren<Animator>();

            m_KeyHash_BoolMoving = Animator.StringToHash(m_Key_BoolMoving);
            m_KeyHash_BoolInjured = Animator.StringToHash(m_Key_BoolInjured);
            m_KeyHash_BoolCrouch = Animator.StringToHash(m_Key_BoolCrouch);
            m_KeyHash_BoolBlock = Animator.StringToHash(m_Key_BoolBlock);
            m_KeyHash_IntTalking = Animator.StringToHash(m_Key_IntTalking);
            m_KeyHash_IntAction = Animator.StringToHash(m_Key_IntAction);
            m_KeyHash_IntLeftRight = Animator.StringToHash(m_Key_IntLeftRight);
            m_KeyHash_IntWeapon = Animator.StringToHash(m_Key_IntWeapon);
            m_KeyHash_IntWeaponSwitch = Animator.StringToHash(m_Key_IntWeaponSwitch);
            m_KeyHash_FloatVelocityX = Animator.StringToHash(m_Key_FloatVelocityX);
            m_KeyHash_FloatVelocityZ = Animator.StringToHash(m_Key_FloatVelocityZ);
            m_KeyHash_FloatHurtX = Animator.StringToHash(m_Key_FloatHurtX);
            m_KeyHash_FloatHurtZ = Animator.StringToHash(m_Key_FloatHurtZ);
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
            m_KeyHash_TriggerCast = Animator.StringToHash(m_Key_Trigger_Cast);
            m_KeyHash_TriggerAttackCast = Animator.StringToHash(m_Key_Trigger_AttackCast);
            m_KeyHash_TriggerCastEnd = Animator.StringToHash(m_Key_Trigger_CastEnd);
            m_KeyHash_TriggerAttact = Animator.StringToHash(m_Key_Trigger_Attack);
            m_KeyHash_TriggerAttactKick = Animator.StringToHash(m_Key_Trigger_AttackKick);
            m_KeyHash_TriggerSwim = Animator.StringToHash(m_Key_Trigger_Swim);
        }


        public void SetVelocity(Vector2 vec)
        {
            SetVelocityX(vec.x);
            SetVelocityZ(vec.y);
        }

        public void SetVelocityX(float x)
        {
            m_Animator.SetFloat(m_KeyHash_FloatVelocityX, x);
        }

        public void SetVelocityZ(float z)
        {
            // m_Animator.SetFloat(m_KeyHash_FloatVelocityZ, Mathf.Lerp(m_Animator.GetFloat(m_KeyHash_FloatVelocityZ), z, 0.1f));
            m_Animator.SetFloat(m_KeyHash_FloatVelocityZ, z);
        }

        public void SetHurt(Vector2 vec)
        {
            m_Animator.SetFloat(m_KeyHash_FloatHurtX, vec.x);
            m_Animator.SetFloat(m_KeyHash_FloatHurtZ, vec.y);
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

        #region int
        public void SetTalking(int index)
        {
            m_Animator.SetInteger(m_KeyHash_IntTalking, index);
        }

        public void SetAction(int index)
        {
            m_Animator.SetInteger(m_KeyHash_IntAction, index);
        }

        /// <summary>
        /// 0 null
        /// 1 left 左手
        /// 2 right 右手
        /// 3 double 双手
        /// </summary>
        /// <param name="leftorRight"></param>
        public void SetLeftRight(int leftorRight)
        {
            m_Animator.SetInteger(m_KeyHash_IntLeftRight, leftorRight);
        }

        /// <summary>
        /// 武器动作
        /// 0 无武器
        /// 
        /// 3 为双手斧
        /// </summary>
        /// <param name="weapon"></param>
        public void SetWeapon(int weapon)
        {
            m_Animator.SetInteger(m_KeyHash_IntWeapon, weapon);
        }

        public void SetWeaponSwitch(int weaponSwitch)
        {
            m_Animator.SetInteger(m_KeyHash_IntWeaponSwitch, weaponSwitch);
        }

        #endregion
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

        public void ReviveTrigger()
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

        public void SetCastTrigger()
        {
            SetTrigger(m_KeyHash_TriggerCast);
        }

        public void SetAttackCastTrigger()
        {
            SetTrigger(m_KeyHash_TriggerAttackCast);
        }

        public void SetCastEndTrigger()
        {
            SetTrigger(m_KeyHash_TriggerCastEnd);
        }
        public void SetAttackTrigger()
        {
            SetTrigger(m_KeyHash_TriggerAttact);
        }
        public void AttackKickTrigger()
        {
            SetTrigger(m_KeyHash_TriggerAttactKick);
        }
        public void SwimTrigger()
        {
            SetTrigger(m_KeyHash_TriggerSwim);
        }

        private void SetTrigger(int keyhash)
        {
            m_Animator.SetTrigger(keyhash);
        }
    }

}