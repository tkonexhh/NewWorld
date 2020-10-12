/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleIKComponent.cs
	CreateAuthor:xuhonghua
	CreateTime:10/11/2020 8:09:45 PM
	Tip:10/11/2020 8:09:45 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logic
{
    public class RoleIKComponent : RoleBaseComponent
    {
        private Transform m_RootFocus;
        private float m_AimSpeed = 1.5f;

        public void SetFocusTarget(Transform focus)
        {
            m_RootFocus = focus;
        }

        public override void Update(float dt)
        {
            if (m_RootFocus)
            {
                float dot = Vector3.Dot(role.transform.forward, m_RootFocus.transform.forward);
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                if (angle < 80)
                {
                    role.monoReference.headIK.weight = Mathf.Clamp01(role.monoReference.headIK.weight - m_AimSpeed * Time.deltaTime);
                }
                else
                {
                    role.monoReference.headAimTarget.position = Vector3.Lerp(role.monoReference.headAimTarget.position, m_RootFocus.position, 3 * m_AimSpeed * Time.deltaTime);
                    role.monoReference.headIK.weight = Mathf.Clamp01(role.monoReference.headIK.weight + m_AimSpeed * Time.deltaTime);
                }
            }
            else
            {
                role.monoReference.headIK.weight = Mathf.Clamp01(role.monoReference.headIK.weight - m_AimSpeed * Time.deltaTime);
            }
        }
    }

}