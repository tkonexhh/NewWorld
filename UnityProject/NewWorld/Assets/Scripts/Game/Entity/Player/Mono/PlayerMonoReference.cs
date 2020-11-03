/************************
	FileName:/Scripts/Game/Entity/Player/Mono/PlayerMonoReference.cs
	CreateAuthor:neo.xu
	CreateTime:11/2/2020 4:40:48 PM
	Tip:11/2/2020 4:40:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerMonoReference : MonoBehaviour
    {
        public Rigidbody rigidbody;

        public Run<Collision> onCollisionEnter;
        public Run<Collision> onCollisionExit;
        public Run<Collision> onCollisionStay;

        private void OnCollisionEnter(Collision other)
        {
            if (onCollisionEnter != null)
                onCollisionEnter(other);
        }

        private void OnCollisionExit(Collision other)
        {
            if (onCollisionExit != null)
                onCollisionExit(other);
        }

        private void OnCollisionStay(Collision other)
        {
            if (onCollisionStay != null)
                onCollisionStay(other);
        }
    }

}