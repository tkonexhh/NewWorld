/************************
	FileName:/Scripts/Game/Entity/Player/Component/ControlFSM/PlayerControlFSMBaseState.cs
	CreateAuthor:neo.xu
	CreateTime:11/6/2020 3:49:35 PM
	Tip:11/6/2020 3:49:35 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class PlayerControlFSMBaseState : FSMState<Player>
    {
        protected Player player;
        protected LayerMask groundMask = LayerDefine.Layer_Ground;

        public override void Init(Player entity)
        {
            if (player == null)
                player = entity;
        }

        public override void Enter(Player entity, params object[] args)
        {
        }

        public override void Update(Player entity, float dt)
        {
        }

        public override void FixedUpdate(Player entity, float dt)
        {

        }

        public override void Exit(Player entity)
        {
        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {

        }

        protected Vector3 ProjectOnContactPlane(Vector3 vector, Vector3 normal)
        {
            return vector - normal * Vector3.Dot(vector, normal);
        }

        protected void AdjustVelocity(float speed, float acceleration, Vector3 normal, ref Vector3 velocity)
        {
            Vector3 xAxis = ProjectOnContactPlane(Vector3.right, normal).normalized;
            Vector3 zAxis = ProjectOnContactPlane(Vector3.forward, normal).normalized;

            float currentX = Vector3.Dot(velocity, xAxis);
            float currentz = Vector3.Dot(velocity, zAxis);
            //经过测试 如果加速度比较小的话，上坡会很慢，这里提供一个斜坡加速度支持
            float angle = Vector3.Dot(Vector3.up, normal);
            // Debug.LogError(speed + "--" + acceleration);
            // acceleration *= (1 + (1 - angle) * player.role.data.baseData.clambAccelerationRate);
            Vector3 desiredVelocity = new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y) * speed;
            float maxSpeedChange = acceleration * Time.fixedDeltaTime;
            float newX = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            float newZ = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

            velocity += xAxis * (newX - currentX) + zAxis * (newZ - currentz);
            // Debug.LogError(velocity);
        }
    }

}