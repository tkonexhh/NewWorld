/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BasicState/PlayerBaseState_None.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 3:14:03 PM
	Tip:11/25/2020 3:14:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public class PlayerBaseState_Crouch : FSMState<Player>
    {
        protected Player m_Player;
        private Vector3 targetPosition;
        private bool m_ToIdle = false;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Crouch.canceled += OnCrouchCanceled;
            player.role.controlComponent.Crouch();
            m_ToIdle = false;
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Crouch.canceled -= OnCrouchCanceled;
        }

        public override void Update(Player player, float dt)
        {
            AnimatorStateInfo info = player.role.monoReference.animator.GetCurrentAnimatorStateInfo(0);
            // 判断动画是否播放完成
            if (player.role.monoReference.animator.IsInTransition(0) && info.IsName(player.role.controlComponent.animName.crouch) && info.normalizedTime >= 1f)
            {
                if (m_Player.fsmComponent.stateMachine.currentState is PlayerFSMState_Battle stateBattle)
                {
                    stateBattle.SetBattleState(RoleBattleState.Move);
                }
                else if (m_Player.fsmComponent.stateMachine.currentState is PlayerFSMState_Relax stateRelax)
                {
                    stateRelax.SetRelaxState(RoleRelaxState.Move);
                }
            }
        }

        private void OnCrouchCanceled(InputAction.CallbackContext callback)
        {
            if (m_ToIdle) return;
            m_ToIdle = true;
            m_Player.role.controlComponent.Idle();
            //TODO 等待起身完毕之后才可以再次走路
        }

        public override void FixedUpdate(Player player, float dt)
        {
            CheckGround();
            player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, dt);
        }


        private void CheckGround()
        {
            RaycastHit hit;
            Vector3 origin = m_Player.transform.position;
            //将检测点抬高到膝盖的位置，同时collider的位置也如此
            origin.y += m_Player.role.monoReference.kneeHeight;
            targetPosition = m_Player.transform.position;
            Debug.DrawRay(origin, -Vector3.up * 0.8f, Color.red, 0.1f);
            if (Physics.Raycast(origin, -Vector3.up, out hit, 0.8f, 1 << LayerDefine.Layer_Ground))//检测是否落到地上了
            {
                Vector3 tp = hit.point;
                // Debug.LogError(tp.y + "---" + targetPosition.y);
                targetPosition.y = tp.y + 0.2f;
                m_Player.monoReference.rigidbody.drag = 0;
                m_Player.monoReference.rigidbody.velocity = Vector3.zero;
            }
        }
    }

}