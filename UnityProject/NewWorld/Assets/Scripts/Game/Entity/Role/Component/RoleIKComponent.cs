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
        private RoleIK_RightHand m_RightHandIK;

        public RoleIK_RightHand rightHandIK => m_RightHandIK;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_LookAtIK = new RoleIK_LookAt();
            m_LookAtIK.Init(role);
            m_RightHandIK = new RoleIK_RightHand();
            m_RightHandIK.Init(role);
        }

        public void SetFocusTarget(Transform target)
        {
            m_LookAtIK.SetFocusTarget(target);
        }

        public override void Excute(float dt)
        {
            m_LookAtIK.Excute(dt);
            m_RightHandIK.Excute(dt);
        }

    }

    public abstract class RoleIKBase
    {
        protected Role role;

        public virtual void Init(Role role)
        {
            this.role = role;
        }

        public abstract void Excute(float dt);
    }

    public class RoleIK_LookAt : RoleIKBase
    {
        private Transform m_Target;
        private LookAtIK m_LookAtIK;
        // private float weightV;
        private Vector3 lastPosition;
        private float m_AimSpeed = 1.3f;

        public override void Init(Role role)
        {
            base.Init(role);
            m_LookAtIK = role.monoReference.lookAtIK;
            m_LookAtIK.solver.target = null;
            m_LookAtIK.solver.IKPositionWeight = 0;
            lastPosition = m_LookAtIK.solver.IKPosition;
        }

        public void SetFocusTarget(Transform target)
        {
            m_Target = target;
        }

        public override void Excute(float dt)
        {
            float targetWeight = m_Target == null ? -1 : 1;

            if (m_Target != null)
            {
                float dot = Vector3.Dot(role.transform.forward, m_Target.forward);
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                // Debug.LogError(angle);
                if (angle < 80)
                {
                    targetWeight = -1;
                }
                lastPosition = Vector3.Lerp(lastPosition, m_Target.position, dt * m_AimSpeed);
                m_LookAtIK.solver.IKPosition = lastPosition;
            }

            m_LookAtIK.solver.IKPositionWeight = Mathf.Clamp01(m_LookAtIK.solver.IKPositionWeight + targetWeight * dt * m_AimSpeed);
            // Debug.LogError(m_LookAtIK.solver.IKPositionWeight);
            // m_LookAtIK.solver.IKPositionWeight = Mathf.SmoothDamp(m_LookAtIK.solver.IKPositionWeight, targetWeight, ref weightV, dt * 0.1f);
        }
    }

    public class RoleIK_RightHand : RoleIKBase
    {
        private Transform m_Target;
        private Vector3 m_Offset;
        private IKEffector m_RightHandEffector;
        // private float weightV;
        // private Vector3 lastPosition;
        public override void Init(Role role)
        {
            base.Init(role);
            m_RightHandEffector = role.monoReference.fullBodyIK.solver.rightHandEffector;
            m_Offset = Vector3.zero;
        }

        public void SetFocusTarget(Transform target, Vector3 offset)
        {
            m_Target = target;
            m_Offset = offset;
        }

        public override void Excute(float dt)
        {
            float targetWeight = m_Target == null ? -1 : 1;
            m_RightHandEffector.positionWeight = Mathf.Clamp01(m_RightHandEffector.positionWeight + targetWeight * dt * 4.5f * 0.1f);
            // m_RightHandEffector.rotationWeight = Mathf.Clamp01(m_RightHandEffector.rotationWeight + targetWeight * dt * 5.5f) * 0.5f;

            if (m_Target != null)
            {
                m_RightHandEffector.target.position = Vector3.Slerp(m_RightHandEffector.target.position, m_Target.position + m_Offset, dt * 20.0f * 0.1f);
                // m_RightHandEffector.target.rotation = Quaternion.Slerp(m_RightHandEffector.target.rotation, m_Target.rotation, dt * 20.0f);
            }
        }
    }
}