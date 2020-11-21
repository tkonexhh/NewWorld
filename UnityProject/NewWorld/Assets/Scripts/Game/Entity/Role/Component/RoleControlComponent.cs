/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:11/11/2020 2:41:23 PM
	Tip:11/11/2020 2:41:23 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using System;
using Random = UnityEngine.Random;

namespace Game.Logic
{
    public enum AttackTypeEnum
    {
        None,
        Light,//轻攻击
        Heavy,//重攻击
    }
    public class RoleControlComponent : RoleBaseComponent
    {
        private bool m_DesiredToArm = false;
        public bool weaponSwitching { get; private set; }// 正在切换武器中
        public bool armed { get; private set; }// 是否装备武器

        public bool firstAttack { get; set; }
        public AttackTypeEnum attackType { get; set; }
        public bool canRotate { get; set; }
        public bool canMove { get; set; }
        public bool running { get; set; }
        public bool rolling { get; set; }//是否翻滚中
        public bool dodgeing { get; set; }// 闪避中

        public Run onWeaponSwitchComplete;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            firstAttack = true;
            // desireToCombo = false;
            attackType = AttackTypeEnum.None;
            canRotate = true;
            canMove = true;
        }

        public bool CanMove()
        {
            if (canMove)
            {
                if (rolling || dodgeing)
                    return false;

                return true;
            }

            return false;

        }

        //TODO 当速度小于X时，Vel采用插值过渡，当Vel进入到跑步时候，采用急停
        public void RunToStop()
        {
            role.animComponent.animator.CrossFade("RunToStop", 0.05f, 0, 0.1f);
            role.animComponent.SetMoving(false);
            role.animComponent.SetVelocityX(0);
            role.animComponent.SetVelocityZ(0);
        }

        public void Arm()
        {
            if (weaponSwitching) return;
            weaponSwitching = true;
            m_DesiredToArm = true;
            var weapon = role.equipComponent.GetWeapon();
            weapon.UnSheath(role);
        }

        public void UnArm()
        {
            if (weaponSwitching) return;
            weaponSwitching = true;
            m_DesiredToArm = false;
            var weapon = role.equipComponent.GetWeapon();
            weapon.Sheath(role);
        }

        public void WeaponSwitchComplete()
        {
            weaponSwitching = false;
            armed = m_DesiredToArm;
            m_DesiredToArm = false;
            if (onWeaponSwitchComplete != null)
                onWeaponSwitchComplete();
        }

        public void StartTalking()
        {
            //如果拿了武器的话先收刀
            if (armed)
            {
                Run callback = null;
                callback = () =>
                {
                    StartTalking();
                    onWeaponSwitchComplete -= callback;
                };

                onWeaponSwitchComplete += callback;
                UnArm();
                return;
            }

            string talkAnimName = "Talk" + UnityEngine.Random.Range(1, 9);
            role.animComponent.animator.CrossFade(talkAnimName, 0.2f, 0, 0f);

        }

        public void EndTalking()
        {
            role.animComponent.animator.CrossFade("Idle", 0.2f, 0, 0.2f);
        }

        public void Block()
        {
            //没有武装不能进行防守
            if (!armed)
                return;

            var weapon = role.equipComponent.GetWeapon();
            weapon.Block(role);
        }

        public void UnBlock()
        {
            //没有武装不能进行防守
            if (!armed)
                return;

            var weapon = role.equipComponent.GetWeapon();
            weapon.UnBlock(role);
        }


        public void Death()
        {
            var weapon = role.equipComponent.GetWeapon();
            if (weapon == null)
            {
                role.animComponent.animator.CrossFade("Unarmed-Death1", 0.2f, 0, 0.2f);
            }
            else
                weapon.Death(role);
        }


        public void Attack()
        {
            //没有武装不能进行攻击
            if (!armed)
                return;

            if (firstAttack)
            {
                firstAttack = false;
                // desireToCombo = false;
                attackType = AttackTypeEnum.None;
                var weapon = role.equipComponent.GetWeapon();
                weapon.Attack(role as Role_Player);
            }
            else
            {
                //检测动作是否在连击触发区间内
                if ((role as Role_Player).animEvent.canCombo)
                {
                    // desireToCombo = true;
                    attackType = AttackTypeEnum.Light;
                    firstAttack = false;
                }
            }
        }

        public void Attack2()
        {
            //没有武装不能进行攻击
            if (!armed)
                return;

            if (firstAttack)
            {
                firstAttack = false;
                // desireToCombo = false;
                attackType = AttackTypeEnum.None;
                var weapon = role.equipComponent.GetWeapon();
                weapon.Attack2(role as Role_Player);
            }
            else
            {
                //检测动作是否在连击触发区间内
                if ((role as Role_Player).animEvent.canCombo)
                {
                    // desireToCombo = true;
                    attackType = AttackTypeEnum.Heavy;
                    firstAttack = false;
                }
            }
        }

        public void SpecialAttackStart()
        {
            if (!armed)
                return;

            var weapon = role.equipComponent.GetWeapon();
            weapon.SpecialAttackStart(role as Role_Player);

        }

        public void SpecialAttackEnd()
        {
            if (!armed)
                return;

            var weapon = role.equipComponent.GetWeapon();
            weapon.SpecialAttackEnd(role as Role_Player);
        }

        public void Roll()
        {
            //TODO 暂时改成只有武器才能翻滚
            if (!armed)
                return;

            //如果正在翻滚就不能在翻滚了
            if (rolling || dodgeing)
                return;

            rolling = true;
            //翻滚的时候使用apply motion
            role.monoReference.animator.applyRootMotion = true;
            var weapon = role.equipComponent.GetWeapon();
            weapon.Roll(role as Role_Player, (RollDir)Random.Range(0, 4));
        }

        public void Dodge()
        {
            //TODO 暂时改成只有武器才能翻滚
            if (!armed)
                return;

            //如果正在翻滚就不能在翻滚了
            if (dodgeing || rolling)
                return;

            dodgeing = true;
            var weapon = role.equipComponent.GetWeapon();
            weapon.Dodge(role as Role_Player, (DodgeDir)Random.Range(0, 2));
        }
    }

}