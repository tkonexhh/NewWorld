/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 5:08:33 PM
	Tip:9/18/2020 5:08:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class RoleControlComponent : RoleBaseComponent
    {
        private Role_Player player;

        private Rigidbody m_Rigidbody;
        private bool isInjured = false;


        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Role_Player)role;
        }

        public override void Excute(float dt)
        {
            player.animComponent.SetMoving(moving);
            // Debug.LogError(player.animComponent.GetMoving());
        }

        public bool IsInjured
        {
            get => isInjured;
            set
            {
                isInjured = value;
                role.animComponent.SetInjured(isInjured);
            }
        }

        public bool moving
        {
            get => velocity.sqrMagnitude > 0.1f;
        }

        public Vector3 velocity
        {
            get => m_Rigidbody.velocity;
            private set
            {
                m_Rigidbody.velocity = value;
            }
        }

        public Vector3 roleForward
        {
            get => player.transform.forward;
            private set
            {
                player.transform.forward = value;
            }
        }

        public void SetRigidbody(Rigidbody rigidbody)
        {
            m_Rigidbody = rigidbody;
        }

        public void SetForward(Vector3 forward)
        {
            this.roleForward = forward;
        }

        public void SetVelocity(Vector3 velocity)
        {
            this.velocity = velocity;
        }

    }

}