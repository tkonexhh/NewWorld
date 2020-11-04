/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/3/2020 7:26:03 PM
	Tip:11/3/2020 7:26:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Air : FSMState<Player>
    {
        private Player m_Player;
        private int m_JumpChance = 0;
        private Vector3 m_MoveVelocity;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            m_JumpChance = 0;
            GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
            player.monoReference.onCollisionEnter += OnCollisionEnter;
            player.monoReference.onCollisionStay += OnCollisionStay;
        }

        public override void Update(Player player, float dt)
        {
            // if (player.role.animComponent == null)
            //     return;
        }

        public override void FixedUpdate(Player player, float dt)
        {
            float maxSpeed = player.role.data.baseData.walkSpeed;//: player.role.data.baseData.walkSpeed;
            player.controlComponent.Move(maxSpeed, player.role.data.baseData.airAcceleration, dt);
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Jump.performed -= OnJumpPerformed;
            player.monoReference.onCollisionEnter -= OnCollisionEnter;
            player.monoReference.onCollisionStay -= OnCollisionStay;
        }

        public override void OnMsg(Player role, int key, params object[] args)
        {

        }

        private void OnJumpPerformed(InputAction.CallbackContext callback)
        {
            Jump();
        }

        private void Jump()
        {
            if (m_JumpChance < m_Player.role.data.baseData.jumpCount - 1)
            {
                Debug.LogError("Jump");
                m_JumpChance += 1;
                m_Player.controlComponent.Jump();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            EvaluateCollision(other);
        }

        private void OnCollisionStay(Collision other)
        {
            EvaluateCollision(other);
        }

        private void EvaluateCollision(Collision collision)
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                Vector3 normal = collision.GetContact(i).normal;
                if (normal.y >= 0.9f)
                {
                    // Debug.LogError("OnGround");
                    (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
                }
            }
        }
    }

}