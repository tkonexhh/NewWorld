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

        FSMStateMachine<Player> m_FSM;
        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            player = (Player)ownner;
            // m_FSM = new FSMStateMachine<Player>(player);
            // m_FSM.stateFactory = new FSMStateFactory<Player>(false);
            // m_FSM.stateFactory.RegisterState(ControlState.Ground, new PlayerControlFSMState_Ground());
            // m_FSM.stateFactory.RegisterState(ControlState.Air, new PlayerControlFSMState_Air());
            // m_FSM.SetCurrentStateByID(ControlState.Ground);

        }

        public override void Excute(float dt)
        {
            m_FSM?.UpdateState(dt);
        }

        public override void FixedExcute(float dt)
        {
            m_FSM?.FixedUpdateState(dt);

            if (player.role.controlComponent.canRotate)
            {
                HandleRotation(dt);
            }

            if (player.role.controlComponent.canMove)
            {
                HandleMove(dt);
            }

        }

        public void SetControlState(ControlState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }


        private Vector3 normalVector;
        private void HandleMove(float dt)
        {
            Vector3 targetDir = Vector3.zero;
            targetDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
            targetDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
            targetDir.Normalize();
            targetDir.y = 0;

            float speed = player.role.data.baseData.walkSpeed;
            targetDir *= speed;

            Vector3 projectedVel = Vector3.ProjectOnPlane(targetDir, normalVector);
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
    }
}