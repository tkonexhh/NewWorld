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
using RootMotion.FinalIK;

namespace Game.Logic
{
    public class RoleIKComponent : RoleBaseComponent
    {
        private RoleIK_LookAt m_LookAtIK;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_LookAtIK = new RoleIK_LookAt();
            m_LookAtIK.Init(role);
        }

        public void SetFocusTarget(Transform target)
        {
            m_LookAtIK.SetFocusTarget(target);
        }

        public override void Excute(float dt)
        {
            m_LookAtIK.Excute(dt);

        }

    }

    public class RoleIK_LookAt
    {
        private Role m_Role;
        private Transform m_Target;
        private LookAtIK m_LookAtIK;

        private Vector3 dir = Vector3.zero;
        private float weightV;
        private Vector3 lastPosition;
        private float m_AimSpeed = 1.5f;

        public void Init(Role role)
        {
            m_Role = role;
            m_LookAtIK = role.monoReference.lookAtIK;
            m_LookAtIK.solver.target = null;
            lastPosition = m_LookAtIK.solver.IKPosition;
        }

        public void SetFocusTarget(Transform target)
        {
            m_Target = target;
        }

        public void Excute(float dt)
        {
            float targetWeight = m_Target == null ? 0 : 1;
            m_LookAtIK.solver.IKPositionWeight = Mathf.SmoothDamp(m_LookAtIK.solver.IKPositionWeight, targetWeight, ref weightV, 0.3f);
            if (m_LookAtIK.solver.IKPositionWeight <= 0f) return;

            if (m_Target != null)
            {
                lastPosition = Vector3.Lerp(lastPosition, m_Target.position, dt * m_AimSpeed);
                m_LookAtIK.solver.IKPosition = lastPosition;//Vector3.Lerp(lastPosition, target.position + offset, switchWeight);
            }
        }

    }
}