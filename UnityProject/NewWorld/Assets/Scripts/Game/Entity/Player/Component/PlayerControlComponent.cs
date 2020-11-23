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
    public enum ControlState
    {
        Ground,
        Air
    }
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

        public Vector3 position
        {
            get => player.monoReference.rigidbody.position;
        }

        public Vector3 forward
        {
            get => player.transform.forward;
            set
            {
                player.transform.forward = value;
            }
        }

        public Vector3 roleForward
        {
            get => player.role.transform.forward;
            set
            {
                player.role.transform.forward = value;
            }
        }


        float minDistanceNeededToFall = 1f;//变为下落状态的距离
        float inAirTimer;


        FSMStateMachine<Player> m_FSM;
        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
            GameInputMgr.S.mainAction.Roll.performed += OnRollPerformed;
            GameInputMgr.S.mainAction.Run.performed += i => player.role.controlComponent.running = true;
            GameInputMgr.S.mainAction.Run.canceled += i => player.role.controlComponent.running = false;
            player.role.monoReference.onAnimatorMove += OnAnimatorMove;

            // m_FSM = new FSMStateMachine<Player>(player);
            // m_FSM.stateFactory = new FSMStateFactory<Player>(false);
            // m_FSM.stateFactory.RegisterState(ControlState.Ground, new PlayerControlFSMState_Ground());
            // m_FSM.stateFactory.RegisterState(ControlState.Air, new PlayerControlFSMState_Air());
            // m_FSM.SetCurrentStateByID(ControlState.Ground);

        }

        private void OnRollPerformed(InputAction.CallbackContext callback)
        {
            if (GameInputMgr.S.moveAmount == 0f)
            {
                player.role.controlComponent.Roll(RollDir.Backward);
            }
            else
            {
                Vector3 rollDir = Vector3.zero;
                rollDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
                rollDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
                rollDir.Normalize();
                rollDir.y = 0;

                if (rollDir.x > rollDir.y)
                {
                    //水平翻滚
                    if (rollDir.x < 0)
                    {
                        player.role.controlComponent.Roll(RollDir.Left);
                    }
                    else
                    {
                        player.role.controlComponent.Roll(RollDir.Right);
                    }
                }
                else
                {
                    //水平翻滚
                    if (rollDir.y < 0)
                    {
                        player.role.controlComponent.Roll(RollDir.Backward);
                    }
                    else
                    {
                        player.role.controlComponent.Roll(RollDir.Forward);
                    }
                }
            }

        }

        public override void Excute(float dt)
        {
            m_FSM?.UpdateState(dt);

            if (player.role.controlComponent.isInAir)
            {
                inAirTimer += Time.deltaTime;
            }

        }

        public override void FixedExcute(float dt)
        {
            m_FSM?.FixedUpdateState(dt);
            if (player.role.controlComponent.canRotate)
            {
                HandleRotation(dt);
            }

            if (player.role.controlComponent.canMove && !player.role.controlComponent.usingMotion)
            {
                HandleMove(dt);
            }

            HandleFalling(dt, moveDir);

        }

        public void SetControlState(ControlState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

        Vector3 targetPosition;
        private Vector3 normalVector;
        private Vector3 moveDir;
        private void HandleMove(float dt)
        {
            if (player.role.controlComponent.rolling)
                return;

            moveDir = Vector3.zero;
            moveDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            moveDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            moveDir.Normalize();
            moveDir.y = 0;

            float speed = player.role.controlComponent.running ? player.role.data.baseData.runSpeed : player.role.data.baseData.walkSpeed;
            moveDir *= speed;

            Vector3 projectedVel = Vector3.ProjectOnPlane(moveDir, normalVector);
            player.monoReference.rigidbody.velocity = projectedVel;
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
                targetDir = forward;
            }

            float rs = 10;
            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(player.transform.rotation, tr, rs * dt);
            player.transform.rotation = targetRotation;
        }


        private void HandleFalling(float dt, Vector3 moveDir)
        {
            player.role.controlComponent.isGround = false;
            RaycastHit hit;
            Vector3 origin = player.transform.position;
            //将检测点抬高到膝盖的位置，同时collider的位置也如此
            origin.y += player.role.monoReference.kneeHeight;//0.5f就是ground DetectionRayStartPoint 从人物那个位置向下打射线

            // Debug.DrawRay(origin, player.transform.forward, Color.green, 0.4f);
            if (Physics.Raycast(origin, player.transform.forward, out hit, 0.4f))//如果脚前面前面有物体贴着的话，不可以移动了
            {
                moveDir = Vector3.zero;
            }


            if (player.role.controlComponent.isInAir)
            {
                player.monoReference.rigidbody.AddForce(-Vector3.up * player.role.data.baseData.fallSpeed);//给向下的速度
                player.monoReference.rigidbody.AddForce(moveDir * player.role.data.baseData.fallSpeed / 10f);//如果前方没有物体，可以加上一个速度//用于从边缘出下落
            }


            Vector3 dir = moveDir;
            dir.Normalize();
            //将下落检测点略微放在角色的移动方向的额前面
            origin += dir * player.monoReference.rigidbodyCollider.radius;
            targetPosition = player.transform.position;
            Debug.DrawRay(origin, -Vector3.up * minDistanceNeededToFall, Color.red, 0.1f, false);
            if (Physics.Raycast(origin, -Vector3.up, out hit, minDistanceNeededToFall, 1 << LayerDefine.Layer_Ground))//检测是否落到地上了
            {
                normalVector = hit.normal;
                Vector3 tp = hit.point;
                player.role.controlComponent.isGround = true;

                targetPosition.y = tp.y;


                if (player.role.controlComponent.isInAir)
                {
                    if (inAirTimer > 0.5f)
                    {
                        Debug.LogError("InAirTimer:" + inAirTimer);
                        player.role.controlComponent.Land();
                        inAirTimer = 0;
                    }
                    else
                    {
                        Debug.LogError("Back To Ground");
                        player.role.controlComponent.BackToMovement();
                        inAirTimer = 0;
                    }

                    player.role.controlComponent.isInAir = false;
                }
            }
            else
            {
                if (player.role.controlComponent.isGround)
                {
                    player.role.controlComponent.isGround = false;
                }

                if (!player.role.controlComponent.isInAir)
                {
                    //播放Falling
                    Debug.LogError("Falling");
                    player.role.controlComponent.Fall();
                }

                Vector3 vel = velocity;
                vel.Normalize();
                velocity = vel * player.role.data.baseData.walkSpeed * 2;
                player.role.controlComponent.isInAir = true;
            }


            if (player.role.controlComponent.isGround)
            {
                if (GameInputMgr.S.moveAmount > 0)
                {
                    //TODO 如果刚刚落地的话，坐标需要插值过去
                    // player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, dt);
                    player.transform.position = targetPosition;
                }
                else
                {
                    player.transform.position = targetPosition;
                }
            }
        }


        private void OnAnimatorMove(Vector3 deletaPos)
        {
            //drag加速度
            player.monoReference.rigidbody.drag = 0;
            deletaPos.y = 0;
            Vector3 vel = deletaPos / Time.deltaTime;
            velocity = vel;
            // Debug.LogError(deletaPos + "---" + velocity);
        }
    }
}