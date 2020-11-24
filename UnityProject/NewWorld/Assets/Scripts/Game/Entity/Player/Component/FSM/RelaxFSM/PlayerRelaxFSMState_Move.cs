/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RelaxFSM/RoleRelaxFSMState_Talking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 1:43:03 PM
	Tip:9/30/2020 1:43:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Move : FSMState<Player>
    {
        private Player m_Player;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Roll.performed += OnRollPerformed;
            GameInputMgr.S.mainAction.Run.performed += i => player.role.controlComponent.running = true;
            GameInputMgr.S.mainAction.Run.canceled += i => player.role.controlComponent.running = false;
            // player.role.monoReference.onAnimatorMove += OnAnimatorMove;
        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            player.role.animComponent.SetMoving(GameInputMgr.S.moveVec.sqrMagnitude > 0.1f);
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.fsmComponent.SetRoleState(RoleState.Battle);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Talking);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Sit);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Crouch);
            }
        }

        public override void FixedUpdate(Player player, float dt)
        {
            // 控制角色朝向
            player.role.animComponent.SetVelocityZ(GameInputMgr.S.moveAmount, player.role.controlComponent.running);


            if (player.role.controlComponent.canRotate)
            {
                HandleRotation(dt);
            }

            if (player.role.controlComponent.canMove && !player.role.controlComponent.usingMotion)
            {
                HandleMove(dt);
            }
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Roll.performed -= OnRollPerformed;
            // player.role.monoReference.onAnimatorMove -= OnAnimatorMove;
        }

        private void OnRollPerformed(InputAction.CallbackContext callback)
        {
            (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Roll);
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

        Vector3 targetPosition;
        private Vector3 normalVector;
        private Vector3 moveDir;
        private void HandleMove(float dt)
        {
            if (m_Player.role.controlComponent.rolling)
                return;

            moveDir = Vector3.zero;
            moveDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            moveDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            moveDir.Normalize();
            moveDir.y = 0;

            float speed = m_Player.role.controlComponent.running ? m_Player.role.data.baseData.runSpeed : m_Player.role.data.baseData.walkSpeed;
            moveDir *= speed;

            Vector3 projectedVel = Vector3.ProjectOnPlane(moveDir, normalVector);
            m_Player.monoReference.rigidbody.velocity = projectedVel;
        }


        private void OnAnimatorMove(Vector3 deletaPos)
        {
            if (!m_Player.role.controlComponent.usingMotion)
                return;

            //drag加速度
            m_Player.monoReference.rigidbody.drag = 0;
            deletaPos.y = 0;
            Vector3 vel = deletaPos / Time.deltaTime;
            m_Player.controlComponent.velocity = vel;
            // Debug.LogError(deletaPos + "---" + velocity);
        }
    }

}