/************************
	FileName:/Scripts/Game/Entity/Player/Component/FSM/RelaxFSM/PlayerRelaxFSMState_Air.cs
	CreateAuthor:neo.xu
	CreateTime:11/3/2020 7:26:03 PM
	Tip:11/3/2020 7:26:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GFrame;

namespace Game.Logic
{
    public class PlayerRelaxFSMState_Air : FSMState<Player>
    {
        private Player m_Player;
        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;
            // GameInputMgr.S.mainAction.Jump.performed += OnJumpPerformed;
            // player.monoReference.onCollisionEnter += OnCollisionEnter;
            // player.monoReference.onCollisionStay += OnCollisionStay;
        }

        public override void Update(Player player, float dt)
        {
        }

        public override void FixedUpdate(Player player, float dt)
        {
            float maxSpeed = player.role.data.baseData.walkSpeed;
        }


    }

}