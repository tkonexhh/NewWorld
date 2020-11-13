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

namespace Game.Logic
{
    public class RoleControlComponent : RoleBaseComponent
    {
        private bool m_DesiredToArm = false;

        /// <summary>
        /// 正在切换武器中
        /// </summary>
        /// <value></value>
        public bool weaponSwitching { get; private set; }

        /// <summary>
        /// 是否装备武器
        /// </summary>
        /// <value></value>
        public bool armed { get; private set; }

        public bool talking { get; private set; }


        public Run onWeaponSwitchComplete;
        // private Run onAnimComplete;

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
            // onAnimComplete += ChekTalkAnimComplete;
            talking = true;
            PlayTalkAnim();

        }

        public void EndTalking()
        {
            talking = false;
            // onAnimComplete -= ChekTalkAnimComplete;
            role.animComponent.animator.CrossFade("Idle", 0.2f, 0, 0.2f);
        }

        private void ChekTalkAnimComplete()
        {
            // var info = role.animComponent.animator.GetCurrentAnimatorStateInfo(0);
            // if (info.IsName("Talk1"))
            // {
            //     PlayTalkAnim();
            // }
        }

        private void PlayTalkAnim()
        {
            Debug.LogError("PlayTalkAnim");
            // string talkAnimName = "Talk" + UnityEngine.Random.Range(1, 8);
            // string talkAnimName = "Talk1";
            // role.animComponent.animator.CrossFade(talkAnimName, 0.2f, 0, 0f);
            // var clip = role.animComponent.animator.GetCurrentAnimatorClipInfo(0);
            // Debug.LogError(clip[0].clip.name);
            // var clip2 = role.animComponent.animator.GetCurrentAnimatorClipInfo(0);
            // Debug.LogError(clip2[0].clip.name);
            // role.animComponent.animator.Play(talkAnimName, 0);
        }


        public override void Excute(float dt)
        {
            // if (onAnimComplete != null)
            // {
            //     var info = role.animComponent.animator.GetCurrentAnimatorStateInfo(0);
            //     if (info.normalizedTime >= 1.0f)
            //     {
            //         onAnimComplete();
            //     }
            // }
        }
    }

}