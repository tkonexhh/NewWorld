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
        private RoleIK_LeftHand m_LeftHandIK;

        public RoleIK_RightHand rightHandIK => m_RightHandIK;
        public RoleIK_LeftHand leftHandIK => m_LeftHandIK;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_LookAtIK = new RoleIK_LookAt();
            m_LookAtIK.Init(role);
            m_RightHandIK = new RoleIK_RightHand();
            m_RightHandIK.Init(role);
            m_LeftHandIK = new RoleIK_LeftHand();
            m_LeftHandIK.Init(role);
        }

        public void SetFocusTarget(Transform target)
        {
            m_LookAtIK.SetFocusTarget(target);
        }

        public override void Excute(float dt)
        {
            m_LookAtIK.Excute(dt);
            m_RightHandIK.Excute(dt);
            // m_LeftHandIK.Excute(dt);
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
        }
    }

    public class RoleIKHand : RoleIKBase
    {
        protected Transform target;
        protected virtual IKEffector hand => role.monoReference.fullBodyIK.solver.rightHandEffector;
        protected virtual HandPoser handPoser => role.monoReference.rightHandPoser;
        public override void Init(Role role)
        {
            base.Init(role);
            hand.positionWeight = 0;
            hand.rotationWeight = 0;
            handPoser.weight = 0;
        }

        public void SetFocusTarget(Transform target)
        {
            this.target = target;
        }

        public void SetHandPoser(Transform hand)
        {
            handPoser.poseRoot = hand;
        }

        public override void Excute(float dt)
        {
            if (target != null)
            {
                hand.position = target.transform.position;
                hand.rotation = target.transform.rotation;
            }
            float targetWeight = target == null ? -1 : 1;
            hand.positionWeight = Mathf.Clamp01(hand.positionWeight + targetWeight * dt * 3.0f);
            handPoser.weight = hand.positionWeight;
        }
    }

    public class RoleIK_RightHand : RoleIKHand
    {
        protected override IKEffector hand => role.monoReference.fullBodyIK.solver.rightHandEffector;
        protected override HandPoser handPoser => role.monoReference.rightHandPoser;
    }

    public class RoleIK_LeftHand : RoleIKHand
    {
        protected override IKEffector hand => role.monoReference.fullBodyIK.solver.leftHandEffector;
        protected override HandPoser handPoser => role.monoReference.leftHandPoser;
    }
}