/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleIKComponent.cs
	CreateAuthor:xuhonghua
	CreateTime:10/11/2020 8:09:45 PM
	Tip:10/11/2020 8:09:45 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class RoleIKComponent : RoleBaseMonoComponent
    {
        private Transform m_RootFocus;
        private float m_LookWeight = 0;
        private float m_AimSpeed = 1.5f;

        public void SetFocusTarget(Transform focus)
        {
            m_RootFocus = focus;
        }

        //Animation Rigging相关的暂时弃用
        // public override void Update(float dt)
        // {
        //     if (m_RootFocus)
        //     {
        //         float dot = Vector3.Dot(role.roleTransform.forward, m_RootFocus.forward);
        //         float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        //         if (angle < 80)
        //         {
        //             role.monoReference.headIK.weight = Mathf.Clamp01(role.monoReference.headIK.weight - m_AimSpeed * Time.deltaTime);
        //         }
        //         else
        //         {
        //             role.monoReference.headAimTarget.position = Vector3.Lerp(role.monoReference.headAimTarget.position, m_RootFocus.position, 3 * m_AimSpeed * Time.deltaTime);
        //             role.monoReference.headIK.weight = Mathf.Clamp01(role.monoReference.headIK.weight + m_AimSpeed * Time.deltaTime);
        //         }
        //     }
        //     else
        //     {
        //         role.monoReference.headIK.weight = Mathf.Clamp01(role.monoReference.headIK.weight - m_AimSpeed * Time.deltaTime);
        //     }
        // }

        private void OnAnimatorIK(int layerIndex)
        {
            if (m_RootFocus)
            {
                float dot = Vector3.Dot(role.transform.forward, m_RootFocus.forward);
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                // Debug.LogError(angle);
                if (angle > 120 && angle < 160)
                {
                    m_LookWeight = Mathf.Clamp01(m_LookWeight - m_AimSpeed * Time.deltaTime);
                }
                else
                {
                    role.monoReference.headAimTarget.position = Vector3.Lerp(role.monoReference.headAimTarget.position, m_RootFocus.position, 3 * m_AimSpeed * Time.deltaTime);
                    m_LookWeight = Mathf.Clamp01(m_LookWeight + m_AimSpeed * Time.deltaTime);
                }

                role.animComponent.animator.SetLookAtWeight(m_LookWeight);
                role.animComponent.animator.SetLookAtPosition(role.monoReference.headAimTarget.position);
            }
            else
            {
                m_LookWeight = Mathf.Clamp01(m_LookWeight - m_AimSpeed * Time.deltaTime);
                role.animComponent.animator.SetLookAtWeight(m_LookWeight);
            }
        }

    }

}