using System;
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
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerControlComponent : EntityComponennt
    {
        private Player player;

        public Vector3 velocity
        {
            get => player.monoReference.rigidbody.velocity;
            set
            {
                player.monoReference.rigidbody.velocity = value;
            }
        }

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
            player.role.monoReference.onAnimatorMove += OnAnimatorMove;

        }

        private void OnAnimatorMove(Vector3 deletaPos)
        {
            if (!player.role.controlComponent.usingMotion)
                return;

            // Debug.LogError(deletaPos);
            //drag加速度
            player.monoReference.rigidbody.drag = 0;
            deletaPos.y = 0;
            Vector3 vel = deletaPos / Time.deltaTime;
            velocity = vel;
        }
    }
}