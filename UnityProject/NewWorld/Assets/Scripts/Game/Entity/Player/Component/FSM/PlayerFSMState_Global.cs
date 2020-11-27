/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Sit.cs
	CreateAuthor:neo.xu
	CreateTime:9/28/2020 6:25:39 PM
	Tip:9/28/2020 6:25:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerFSMState_Global : FSMState<Player>
    {

        private Player m_Player;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
        }

        public override void Update(Player player, float dt)
        {


            if (Input.GetKeyDown(KeyCode.X))
            {
                player.fsmComponent.SetRoleState(RoleState.Swim);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                player.role.animComponent.ReviveTrigger();
            }
        }

        public override void FixedUpdate(Player entity, float dt)
        {
            CheckInteractableObject();
        }

        public override void Exit(Player player)
        {

        }

        private void CheckInteractableObject()
        {
            RaycastHit hit;

            if (Physics.SphereCast(m_Player.transform.position, 0.3f, m_Player.transform.forward, out hit, 1f))
            {
                var interactable = hit.collider.GetComponent<InteractableObject>();
                if (interactable != null)
                {
                    Debug.LogError(interactable);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.Interact(m_Player.role);
                    }
                }
            }
        }
    }

}