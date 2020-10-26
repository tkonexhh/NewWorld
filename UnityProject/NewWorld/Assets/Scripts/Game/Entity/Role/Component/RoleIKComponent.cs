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
        private Transform m_Target;
        private LookAtIK m_LookAtIK;

        private Vector3 dir = Vector3.zero;
        private float weightV;
        public float weightSmoothTime = 0.3f;

        private Role m_Role;
        public void Init(Role role)
        {
            m_Role = role;
            m_LookAtIK = role.monoReference.lookAtIK;
        }

        public void SetFocusTarget(Transform target)
        {
            m_Target = target;
            m_LookAtIK.solver.target = m_Target;
        }

        public void Excute(float dt)
        {
            float targetWeight = m_Target == null ? 0 : 1;
            m_LookAtIK.solver.IKPositionWeight = Mathf.SmoothDamp(m_LookAtIK.solver.IKPositionWeight, targetWeight, ref weightV, weightSmoothTime);
            if (m_LookAtIK.solver.IKPositionWeight <= 0f) return;
            Vector3 targetDir = m_LookAtIK.solver.IKPosition - pivot;
            dir = Vector3.Slerp(dir, targetDir, Time.deltaTime);
            dir = Vector3.RotateTowards(dir, targetDir, Time.deltaTime, 45);
            m_LookAtIK.solver.IKPosition = pivot + dir;
        }

        private Vector3 pivot
        {
            get
            {
                return m_LookAtIK.transform.position + m_LookAtIK.transform.rotation * Vector3.up;
            }
        }


    }
}