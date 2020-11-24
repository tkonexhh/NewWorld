/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Land.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 8:03:56 PM
	Tip:11/24/2020 8:03:56 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Land : FSMState<Player>
    {
        private Player m_Player;
        private Vector3 targetPosition;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            player.role.controlComponent.canMove = false;
            player.role.controlComponent.canRotate = false;
            player.role.controlComponent.Land();
        }

        public override void FixedUpdate(Player player, float dt)
        {
            if (player.role.controlComponent.canMove)
            {
                GameInputMgr.S.ClearMove();
                player.controlComponent.velocity = Vector3.zero;
                (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Relax).SetRelaxState(RoleRelaxState.Move);
            }

            CheckGround();
            player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, dt);
        }

        public override void Exit(Player player)
        {
            player.role.controlComponent.canMove = true;
            player.role.controlComponent.canRotate = true;
        }

        private void CheckGround()
        {
            RaycastHit hit;
            Vector3 origin = m_Player.transform.position;
            //将检测点抬高到膝盖的位置，同时collider的位置也如此
            origin.y += m_Player.role.monoReference.kneeHeight;
            targetPosition = m_Player.transform.position;
            if (Physics.Raycast(origin, -Vector3.up, out hit, 0.7f, 1 << LayerDefine.Layer_Ground))//检测是否落到地上了
            {

                Vector3 tp = hit.point;
                targetPosition.y = tp.y;
            }
        }
    }

}