/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Sit.cs
	CreateAuthor:neo.xu
	CreateTime:9/28/2020 6:25:39 PM
	Tip:9/28/2020 6:25:39 PM
************************/

using UnityEngine;
using GFrame;
using UnityEngine.InputSystem;

namespace Game.Logic
{
    public enum RoleBattleState
    {
        Battle,
        Blocking,
        Crouch,
    }
    public class PlayerFSMState_Battle : FSMState<Player>
    {
        private Player m_Player;
        private FSMStateMachine<Player> m_FSM;

        public override void Enter(Player player, params object[] args)
        {
            m_Player = player;

            //0空拳
            //1双手剑
            //2双手矛
            //3双手斧
            player.role.animComponent.SetWeaponSwitch(-1);
            m_Player.role.controlComponent.Arm();

            if (m_FSM == null)
            {
                m_FSM = new FSMStateMachine<Player>(player);
                m_FSM.SetGlobalState(new PlayerBattleFSMState_Global());
                m_FSM.stateFactory = new FSMStateFactory<Player>(false);
                m_FSM.stateFactory.RegisterState(RoleBattleState.Battle, new PlayerBattleFSMState_Move());
                m_FSM.stateFactory.RegisterState(RoleBattleState.Blocking, new PlayerBattleFSMState_Blocking());
                m_FSM.stateFactory.RegisterState(RoleBattleState.Crouch, new PlayerBattleFSMState_Crouch());
            }

            SetBattleState(RoleBattleState.Battle);

        }

        public override void Update(Player player, float dt)
        {
            if (player.role.animComponent == null)
                return;

            m_FSM?.UpdateState(dt);
        }

        public override void FixedUpdate(Player player, float dt)
        {
            m_FSM?.FixedUpdateState(dt);
        }

        public override void Exit(Player player)
        {
            player.role.controlComponent.UnArm();
        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {
        }

        public void SetBattleState(RoleBattleState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

    }

}