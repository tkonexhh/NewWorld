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
    public enum RoleAnimatorLayer
    {
        Base = 0,
        Upper,
        Face,
    }

    public enum RoleAnimationType
    {
        Move,
        Attack,
        WeaponSwitch,
    }

    public class RoleAnimComponent : RoleBaseComponent
    {
        private Animator m_Animator;
        private int m_StopAnimFrame;

        #region key keyhash
        private string m_Key_BoolMoving = "Moving";
        private string m_Key_BoolInjured = "Injured";
        private string m_Key_BoolCrouch = "Crouch";

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
        private string m_Key_Trigger_Revive = "ReviveTrigger";
        private string m_Key_Trigger_GetHurt = "GetHurtTrigger";
        private string m_Key_Trigger_BlockBreak = "BlockBreakTrigger";
        private string m_Key_Trigger_Cast = "CastTrigger";
        private string m_Key_Trigger_AttackCast = "AttackCastTrigger";
        private string m_Key_Trigger_CastEnd = "CastEndTrigger";
        private string m_Key_Trigger_AttackKick = "AttackKickTrigger";
        private string m_Key_Trigger_Swim = "SwimTrigger";
        private string m_Key_Trigger_CanCombo = "ComboTrigger";

        private int m_KeyHash_BoolMoving;
        private int m_KeyHash_BoolInjured;
        private int m_KeyHash_BoolCrouch;

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
        private int m_KeyHash_TriggerRevive;
        private int m_KeyHash_TriggerGetHurt;
        private int m_KeyHash_TriggerBlockBreak;
        private int m_KeyHash_TriggerCast;
        private int m_KeyHash_TriggerAttackCast;
        private int m_KeyHash_TriggerCastEnd;
        private int m_KeyHash_TriggerAttactKick;
        private int m_KeyHash_TriggerSwim;
        private int m_KeyHash_TriggerCanCombo;

        #endregion

        public Animator animator => m_Animator;


        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Animator = role.gameObject.GetComponentInChildren<Animator>();

            #region key keyhash
            m_KeyHash_BoolMoving = Animator.StringToHash(m_Key_BoolMoving);
            m_KeyHash_BoolInjured = Animator.StringToHash(m_Key_BoolInjured);
            m_KeyHash_BoolCrouch = Animator.StringToHash(m_Key_BoolCrouch);
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
            m_KeyHash_TriggerRevive = Animator.StringToHash(m_Key_Trigger_Revive);
            m_KeyHash_TriggerGetHurt = Animator.StringToHash(m_Key_Trigger_GetHurt);
            m_KeyHash_TriggerBlockBreak = Animator.StringToHash(m_Key_Trigger_BlockBreak);
            m_KeyHash_TriggerCast = Animator.StringToHash(m_Key_Trigger_Cast);
            m_KeyHash_TriggerAttackCast = Animator.StringToHash(m_Key_Trigger_AttackCast);
            m_KeyHash_TriggerCastEnd = Animator.StringToHash(m_Key_Trigger_CastEnd);
            m_KeyHash_TriggerAttactKick = Animator.StringToHash(m_Key_Trigger_AttackKick);
            m_KeyHash_TriggerSwim = Animator.StringToHash(m_Key_Trigger_Swim);
            m_KeyHash_TriggerCanCombo = Animator.StringToHash(m_Key_Trigger_CanCombo);
            #endregion
        }


        #region Setter
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

        public bool GetMoving()
        {
            return m_Animator.GetBool(m_KeyHash_BoolMoving);
        }

        public void SetInjured(bool injured)
        {
            m_Animator.SetBool(m_KeyHash_BoolInjured, injured);
        }

        public void SetCrouch(bool crouch)
        {
            m_Animator.SetBool(m_KeyHash_BoolCrouch, crouch);
        }

        #endregion

        #region int
        public void SetAction(int index)
        {
            m_Animator.SetInteger(m_KeyHash_IntAction, index);
        }

        public int GetAction()
        {
            return m_Animator.GetInteger(m_KeyHash_IntAction);
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

        public void ReviveTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerRevive);
        }

        public void SetGetHurtTrigger()
        {
            m_Animator.SetTrigger(m_KeyHash_TriggerGetHurt);
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

        public void AttackKickTrigger()
        {
            SetTrigger(m_KeyHash_TriggerAttactKick);
        }
        public void SwimTrigger()
        {
            SetTrigger(m_KeyHash_TriggerSwim);
        }

        public void CanComboTrigger()
        {
            SetTrigger(m_KeyHash_TriggerCanCombo);
        }

        private void SetTrigger(int keyhash)
        {
            m_Animator.SetTrigger(keyhash);
        }

        #endregion

        #region Layer
        //--------------------------
        private void SetLayerWeight(RoleAnimatorLayer layer, float weight)
        {
            m_Animator.SetLayerWeight((int)layer, weight);
        }

        public void PlayAnim(string animname, int layer)
        {
            m_Animator.Play(animname, layer);
        }
        #endregion

        public void AnimStopFrame(int frame)
        {
            animator.speed = 0;
            m_StopAnimFrame = frame;
        }


        #region override
        public override void Excute(float dt)
        {

        }

        public override void FixedExcute(float dt)
        {
            if (animator.speed == 0 && m_StopAnimFrame > 0)
            {
                m_StopAnimFrame--;
                if (m_StopAnimFrame == 0)
                {
                    animator.speed = 1;
                }
            }
        }
        #endregion
    }

}