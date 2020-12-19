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
    public class PlayerRelaxFSMState_Sleep : FSMState<Player>
    {
        private Player m_Player;
        private Vector3 targetPosition;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            GameInputMgr.S.mainAction.Any.performed += OnAnyPerformed;
            player.role.controlComponent.Sleep();
        }

        public override void Exit(Player player)
        {
            GameInputMgr.S.mainAction.Any.performed -= OnAnyPerformed;
        }

        public override void Update(Player player, float dt)
        {
            AnimatorStateInfo info = player.role.monoReference.animator.GetCurrentAnimatorStateInfo(0);
            // 判断动画是否播放完成
            if (info.IsName(player.role.controlComponent.animName.sleep_StandUp) && info.normalizedTime >= 1f)
            {
                m_Player.role.controlComponent.Idle();
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }
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

        private void OnAnyPerformed(InputAction.CallbackContext callback)
        {
            AnimatorStateInfo info = m_Player.role.monoReference.animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName(m_Player.role.controlComponent.animName.sleep_Idle) && !m_Player.role.monoReference.animator.IsInTransition(0))
            {
                m_Player.role.controlComponent.SleepStandUp();
            }
        }
    }

}