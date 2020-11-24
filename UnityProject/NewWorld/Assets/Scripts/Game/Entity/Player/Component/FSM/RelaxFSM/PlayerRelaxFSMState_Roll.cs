/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Roll.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 4:04:25 PM
	Tip:11/24/2020 4:04:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Roll : FSMState<Player>
    {
        private Player m_Player;
        private bool m_StartRoll;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            StartRoll();
            m_StartRoll = true;
        }
        public override void FixedUpdate(Player player, float dt)
        {
            //检测是否roll完成
            if (m_StartRoll && !player.role.controlComponent.rolling)
            {
                (m_Player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
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
                rollDir = GameCameraMgr.S.mainCamera.transform.forward * GameInputMgr.S.moveInput.y;
                rollDir += GameCameraMgr.S.mainCamera.transform.right * GameInputMgr.S.moveInput.x;
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
    }

}