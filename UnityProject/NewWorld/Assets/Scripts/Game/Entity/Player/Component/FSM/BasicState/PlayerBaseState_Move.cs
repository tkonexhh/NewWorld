/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/PlayerBaseMoveState.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 7:03:05 PM
	Tip:11/24/2020 7:03:05 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerBaseState_Move : FSMState<Player>
    {
        protected Player m_Player;
        protected Vector3 targetPosition;
        protected Vector3 normalVector;
        protected Vector3 m_MoveDir;
        private float minDistanceNeededToFall = 1.0f;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            m_Player.role.monoReference.onAnimatorMove += OnAnimatorMove;
        }


        public override void FixedUpdate(Player player, float dt)
        {
            // 控制角色朝向
            if (!m_Player.role.animComponent.GetInterActing())
                m_Player.role.animComponent.SetVelocityZ(GameInputMgr.S.moveAmount, m_Player.role.controlComponent.running);

            if (player.role.controlComponent.canRotate)
            {
                HandleRotation(dt);
            }

            if (player.role.controlComponent.canMove && !player.role.controlComponent.usingMotion)
            {
                HandleMove(dt);
            }

            HandleGroundHit(dt, m_MoveDir);
        }

        public override void Exit(Player player)
        {
            m_Player.role.monoReference.onAnimatorMove -= OnAnimatorMove;
        }

        private void OnAnimatorMove(Vector3 deletaPos)
        {
            // Debug.LogError(deletaPos.sqrMagnitude);
            // Debug.LogError(deletaPos.sqrMagnitude.Remap(0, 0.005f, 0, 1));
        }



        private void HandleRotation(float dt)
        {
            Vector3 targetDir = Vector3.zero;
            float moveOverride = GameInputMgr.S.moveAmount;

            targetDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            targetDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            targetDir.Normalize();

            targetDir.y = 0;


            if (targetDir == Vector3.zero)
            {
                targetDir = m_Player.transform.forward;
            }

            float rotateSpeed = 10;
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(m_Player.transform.rotation, tr, rotateSpeed * dt);
            m_Player.transform.rotation = targetRotation;
        }


        private void HandleMove(float dt)
        {
            if (m_Player.role.controlComponent.usingMotion)
                return;

            m_MoveDir = Vector3.zero;
            m_MoveDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            m_MoveDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            m_MoveDir.Normalize();
            m_MoveDir.y = 0;

            float speed = m_Player.role.controlComponent.running ? m_Player.role.data.baseData.runSpeed : m_Player.role.data.baseData.walkSpeed;
            m_MoveDir *= speed;

            float remapSpeed = 1;
            if (m_Player.role.controlComponent.running)
            {
                remapSpeed = m_Player.role.animComponent.GetVelocityZ().Remap(3, 6, 0, 1);
            }
            else
            {
                remapSpeed = m_Player.role.animComponent.GetVelocityZ().Remap(0, 3, 0, 1);
            }

            Vector3 projectedVel = Vector3.ProjectOnPlane(m_MoveDir, normalVector);
            //这里希望速度也能够配合动画进行缓动
            m_Player.monoReference.rigidbody.velocity = projectedVel * remapSpeed;

        }


        protected virtual void HandleGroundHit(float dt, Vector3 moveDir)
        {
            RaycastHit hit;
            Vector3 origin = m_Player.transform.position;
            //将检测点抬高到膝盖的位置，同时collider的位置也如此
            origin.y += m_Player.role.monoReference.kneeHeight;//0.5f就是ground DetectionRayStartPoint 从人物那个位置向下打射线

            Debug.DrawRay(origin, m_Player.transform.forward, Color.green, 0.1f);
            if (Physics.Raycast(origin, m_Player.transform.forward, out hit, 0.4f))//如果脚前面前面有物体贴着的话，不可以移动了
            {
                m_Player.role.animComponent.SetVelocityZ(0);
                moveDir = Vector3.zero;
            }

            Vector3 dir = moveDir;
            dir.Normalize();
            origin += dir * m_Player.monoReference.rigidbodyCollider.radius;
            targetPosition = m_Player.transform.position;
            // Debug.DrawRay(origin, -Vector3.up * minDistanceNeededToFall, Color.red, 0.1f);
            if (Physics.Raycast(origin, -Vector3.up, out hit, minDistanceNeededToFall, 1 << LayerDefine.Layer_Ground))//检测是否落到地上了
            {
                normalVector = hit.normal;
                Vector3 tp = hit.point;
                targetPosition.y = tp.y;
                OnHitGround(hit);
            }
            else
            {
                OnInAir(moveDir);
            }


        }


        protected virtual void OnHitGround(RaycastHit hit)
        {

        }

        protected virtual void OnInAir(Vector3 moveDir)
        {

        }
    }

}