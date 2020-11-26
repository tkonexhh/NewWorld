/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BasicState/PlayerBaseState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 2:51:55 PM
	Tip:11/25/2020 2:51:55 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerBaseState_Air : PlayerBaseState_Move
    {
        protected float m_AirTimer;
        private bool isFailing = false;

        public override void Enter(Player player, params object[] args)
        {
            base.Enter(player, args);
            m_AirTimer = 0;
            isFailing = false;
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
            base.Exit(player);
            m_AirTimer = 0;
        }



        protected override void OnInAir(Vector3 moveDir)
        {
            if (!isFailing)
            {
                isFailing = true;
                m_Player.role.controlComponent.Fall();
            }

            m_Player.monoReference.rigidbody.AddForce(-Vector3.up * m_Player.role.data.baseData.fallSpeed);//给向下的速度
            m_Player.monoReference.rigidbody.AddForce(moveDir * m_Player.role.data.baseData.fallSpeed / 10f);//如果前方没有物体，可以加上一个速度//用于从边缘出下落

            Vector3 vel = m_Player.controlComponent.velocity;
            vel.Normalize();
            m_Player.controlComponent.velocity = vel * m_Player.role.data.baseData.walkSpeed * 2;
        }
    }

}