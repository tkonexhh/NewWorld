/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BasicState/PlayerBaseRollState.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 2:42:41 PM
	Tip:11/25/2020 2:42:41 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerBaseState_Roll : FSMState<Player>
    {
        protected Player m_Player;
        private Vector3 targetPosition;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            StartRoll();
            GameInputMgr.S.ClearMove();
        }
        public override void FixedUpdate(Player player, float dt)
        {
            player.role.animComponent.ResetVelocityZ();

            CheckGround();
            player.transform.position = targetPosition;

            //检测是否roll完成
            if (!player.role.controlComponent.rolling)
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

        private void StartRoll()
        {
            if (GameInputMgr.S.moveAmount == 0f)
            {
                m_Player.role.controlComponent.Roll(RollDir.Backward);
            }
            else
            {
                Vector3 rollDir = Vector3.zero;
                rollDir = m_Player.transform.forward * GameInputMgr.S.moveInput.y;
                rollDir += m_Player.transform.right * GameInputMgr.S.moveInput.x;
                rollDir.Normalize();
                rollDir.y = 0;

                if (rollDir.x > rollDir.y)
                {
                    //水平翻滚
                    if (rollDir.x < 0)
                    {
                        m_Player.role.controlComponent.Roll(RollDir.Left);
                    }
                    else
                    {
                        m_Player.role.controlComponent.Roll(RollDir.Right);
                    }
                }
                else
                {
                    //水平翻滚
                    if (rollDir.y < 0)
                    {
                        m_Player.role.controlComponent.Roll(RollDir.Backward);
                    }
                    else
                    {
                        m_Player.role.controlComponent.Roll(RollDir.Forward);
                    }
                }
            }
        }

        private void CheckGround()
        {
            RaycastHit hit;
            Vector3 origin = m_Player.transform.position;
            //将检测点抬高到膝盖的位置，同时collider的位置也如此
            origin.y += m_Player.role.monoReference.kneeHeight;
            targetPosition = m_Player.transform.position;
            Debug.DrawRay(origin, -Vector3.up * 0.7f, Color.red, 0.1f);
            if (Physics.Raycast(origin, -Vector3.up, out hit, 0.7f, 1 << LayerDefine.LAYER_GROUND))//检测是否落到地上了
            {
                Vector3 tp = hit.point;
                // Debug.LogError(tp.y + "---" + targetPosition.y);
                targetPosition.y = tp.y;

            }
        }
    }

}