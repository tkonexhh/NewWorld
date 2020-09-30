/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/BattleFSM/RoleFSMStateBattle_Blocking.cs
	CreateAuthor:neo.xu
	CreateTime:9/30/2020 10:17:27 AM
	Tip:9/30/2020 10:17:27 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class RoleBattleFSMState_Battle : FSMState<Role_Player>
    {
        private Role_Player player;
        private Vector2 m_InputMove = Vector2.zero;
        private Vector2 m_VecMove = Vector2.zero;
        private float m_VecSpeed = 3.0f;

        public override void Enter(Role_Player role, params object[] args)
        {
            player = role;
            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled += OnMoveCancled;
        }

        public override void Execute(Role_Player role, float dt)
        {
            if (role.animComponent == null)
                return;
            m_VecMove = Vector2.Lerp(m_VecMove, m_InputMove, dt * m_VecSpeed);
            role.animComponent.SetVelocity(m_VecMove);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GetHurt();
            }


            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                (role.fsmComponent.stateMachine.currentState as RoleFSMState_Battle).SetBattleState(RoleBattleState.Blocking);
            }

            if (m_InputMove.sqrMagnitude < 0.1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    role.animComponent.SetLeftRight(1);
                    role.animComponent.SetAction(Random.Range(1, 4));
                    role.animComponent.SetAttackTrigger();
                }

                if (Input.GetMouseButtonDown(1))
                {
                    role.animComponent.SetLeftRight(2);
                    role.animComponent.SetAction(Random.Range(1, 4));
                    role.animComponent.SetAttackTrigger();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Cast(Random.Range(1, 7));
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                role.animComponent.SetCastEndTrigger();
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                role.animComponent.SetAttackCastTrigger();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                (role.fsmComponent.stateMachine.currentState as RoleFSMState_Battle).SetBattleState(RoleBattleState.Crouch);
            }
        }

        public override void Exit(Role_Player role)
        {
            GameInputMgr.S.mainAction.Move.performed -= OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled -= OnMoveCancled;
        }

        public override void OnMsg(Role_Player entity, int key, params object[] args)
        {

        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            m_InputMove = callback.ReadValue<Vector2>();
            m_InputMove *= 6;
            player.controlComponent.Moving = true;
        }

        private void OnMoveCancled(InputAction.CallbackContext callback)
        {
            m_InputMove = Vector2.zero;
            player.controlComponent.Moving = false;
        }

        private void GetHurt()
        {
            player.animComponent.SetHurt(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
            player.animComponent.SetGetHurtTrigger();
        }

        private void Cast(int action)
        {
            player.animComponent.SetAction(action);
            player.animComponent.SetCastTrigger();
        }
    }

}