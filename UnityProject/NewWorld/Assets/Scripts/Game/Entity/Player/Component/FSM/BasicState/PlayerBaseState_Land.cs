/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/BasicState/PlayerBaseState_Land.cs
	CreateAuthor:neo.xu
	CreateTime:11/25/2020 2:46:07 PM
	Tip:11/25/2020 2:46:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerBaseState_Land : FSMState<Player>
    {
        protected Player m_Player;
        private Vector3 targetPosition;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            player.role.controlComponent.canMove = false;
            player.role.controlComponent.canRotate = false;
            player.role.controlComponent.Land();
            player.role.animComponent.SetVelocityZ(0);

        }

        public override void FixedUpdate(Player player, float dt)
        {
            player.role.animComponent.ResetVelocityZ();

            CheckGround();
            player.transform.position = Vector3.Lerp(player.transform.position, targetPosition, dt);

            if (player.role.controlComponent.canMove)
            {
                OnLandComplete();
                // (player.fsmComponent.stateMachine.currentState as PlayerFSMState_Battle).SetBattleState(RoleBattleState.Move);
            }
        }

        protected virtual void OnLandComplete() { }

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
            Debug.DrawRay(origin, -Vector3.up * 0.7f, Color.red, 0.1f);
            if (Physics.Raycast(origin, -Vector3.up, out hit, 0.7f, 1 << LayerDefine.Layer_Ground))//检测是否落到地上了
            {
                Vector3 tp = hit.point;
                // Debug.LogError(tp.y + "---" + targetPosition.y);
                targetPosition.y = tp.y;
                m_Player.monoReference.rigidbody.drag = 0;
                m_Player.monoReference.rigidbody.velocity = Vector3.zero;
            }
        }
    }

}