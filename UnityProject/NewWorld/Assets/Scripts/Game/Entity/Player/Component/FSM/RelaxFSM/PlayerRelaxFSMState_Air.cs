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
    public class PlayerRelaxFSMState_Air : PlayerBaseMoveState
    {
        private float m_AirTimer;
        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            m_AirTimer = 0;
        }

        public override void Update(Player player, float dt)
        {

        }

        public override void FixedUpdate(Player player, float dt)
        {
            base.FixedUpdate(player, dt);
            m_AirTimer += dt;
        }

        public override void Exit(Player player)
        {
            m_AirTimer = 0;
        }


        protected override void OnHitGround(RaycastHit hit)
        {
            if (m_AirTimer > 0.5f)
            {
                Debug.LogError("InAirTimer:" + m_AirTimer);
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Land);
            }
            else
            {
                // Debug.LogError("Back To Ground");
                m_Player.role.controlComponent.BackToMovement();
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }
        }

        protected override void OnInAir(Vector3 moveDir)
        {
            m_Player.role.controlComponent.Fall();
            m_Player.monoReference.rigidbody.AddForce(-Vector3.up * m_Player.role.data.baseData.fallSpeed);//给向下的速度
            m_Player.monoReference.rigidbody.AddForce(moveDir * m_Player.role.data.baseData.fallSpeed / 10f);//如果前方没有物体，可以加上一个速度//用于从边缘出下落

            Vector3 vel = m_Player.controlComponent.velocity;
            vel.Normalize();
            m_Player.controlComponent.velocity = vel * m_Player.role.data.baseData.walkSpeed * 2;
        }

    }

}