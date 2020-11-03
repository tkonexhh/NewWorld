/************************
	FileName:/Scripts/Game/Entity/Player/Component/PlayerControlComponent.cs
	CreateAuthor:neo.xu
	CreateTime:11/2/2020 4:25:33 PM
	Tip:11/2/2020 4:25:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class PlayerControlComponent : EntityComponennt
    {
        private Player player;
        private Rigidbody m_Rigidbody;


        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
        }

        public override void Excute(float dt)
        {
            // player.role.animComponent.SetMoving(moving);
            // Debug.LogError(player.role.animComponent.GetMoving());
        }

        public Vector3 velocity
        {
            get => m_Rigidbody.velocity;
            set
            {
                m_Rigidbody.velocity = value;
            }
        }

        public Vector3 roleForward
        {
            get => player.role.transform.forward;
            private set
            {
                player.role.transform.forward = value;
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