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

        private Vector2 m_PreviousMovementInput;
        public Vector3 movementInput;//相对于相机的输入方向
        public Vector3 movementVector;//最终移动向量

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
            player.role.monoReference.onAnimatorMove += OnAnimatorMove;
            GameInputMgr.S.moveEvent += OnMove;
        }

        public override void Excute(float dt)
        {
            RecalculateMovementInput();
            RecalculateMovementVector();
        }

        public override void Destroy()
        {
            GameInputMgr.S.moveEvent -= OnMove;
        }

        private void OnMove(Vector2 movement)
        {
            m_PreviousMovementInput = movement;
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

        private void RecalculateMovementInput()
        {
            Vector3 cameraForward = GameCameraMgr.S.mainCamera.transform.forward;
            cameraForward.y = 0f;
            Vector3 cameraRight = GameCameraMgr.S.mainCamera.transform.right;
            cameraRight.y = 0f;

            Vector3 adjustedMovement = cameraRight.normalized * m_PreviousMovementInput.x + cameraForward.normalized * m_PreviousMovementInput.y;
            movementInput = Vector3.ClampMagnitude(adjustedMovement, 1f);
        }

        private void RecalculateMovementVector()
        {
            movementVector = Vector3.zero;
            Vector3 velocity = movementVector;
            Vector3 input = movementInput;
            float speed = 2;
            float acceleration = 40;
            SetVelocityPerAxis(ref velocity.x, input.x, acceleration, speed);
            SetVelocityPerAxis(ref velocity.z, input.z, acceleration, speed);
            movementVector = velocity;
        }

        private void SetVelocityPerAxis(ref float currentAxisSpeed, float axisInput, float acceleration, float targetSpeed)
        {
            if (axisInput == 0f)
            {
                if (currentAxisSpeed != 0f)
                {

                }
            }
            else
            {
                (float absVel, float absInput) = (Mathf.Abs(currentAxisSpeed), Mathf.Abs(axisInput));
                (float signVel, float signInput) = (Mathf.Sign(currentAxisSpeed), Mathf.Sign(axisInput));
                targetSpeed *= absInput;
                if (signVel != signInput || absVel < targetSpeed)
                {
                    currentAxisSpeed += axisInput * acceleration * Time.deltaTime;
                    currentAxisSpeed = Mathf.Clamp(currentAxisSpeed, -targetSpeed, targetSpeed);
                }
                else
                {
                    // ApplyAirResistance(ref currentAxisSpeed);
                }
            }
        }

    }
}