/************************
	FileName:/Scripts/Game/Item/InteractableObject.cs
	CreateAuthor:neo.xu
	CreateTime:11/26/2020 8:58:45 PM
	Tip:11/26/2020 8:58:45 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    [RequireComponent(typeof(Collider))]
    public abstract class InteractableObject : MonoBehaviour, IInteractable
    {
        public float radius = 0.5f;
        // public float offsetY = 0f;

        private void Awake()
        {
            OnInit();
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        protected virtual void OnInit() { }
        public virtual void Interact(Role role) { }
        public virtual void InteractOver(Role role) { }

    }

}