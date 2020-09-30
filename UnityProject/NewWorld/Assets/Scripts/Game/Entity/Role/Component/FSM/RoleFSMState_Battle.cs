/************************
	FileName:/Scripts/Game/Entity/Role/Component/FSM/RoleFSMState_Sit.cs
	CreateAuthor:neo.xu
	CreateTime:9/28/2020 6:25:39 PM
	Tip:9/28/2020 6:25:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
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
    public class RoleFSMState_Battle : FSMState<Role>
    {
        private Role_Player player;
        private FSMStateMachine<Role_Player> m_FSM;

        public override void Enter(Role entity, params object[] args)
        {
            player = entity as Role_Player;
            entity.animComponent.SetWeaponUnSheathTrigger();

            if (m_FSM == null)
            {
                m_FSM = new FSMStateMachine<Role_Player>(player);
                m_FSM.SetGlobalState(new RoleBattleFSMState_Global());
                m_FSM.stateFactory = new FSMStateFactory<Role_Player>(false);
                m_FSM.stateFactory.RegisterState(RoleBattleState.Battle, new RoleBattleFSMState_Battle());
                m_FSM.stateFactory.RegisterState(RoleBattleState.Blocking, new RoleBattleFSMState_Blocking());
                m_FSM.stateFactory.RegisterState(RoleBattleState.Crouch, new RoleBattleFSMState_Crouch());
                m_FSM.SetCurrentStateByID(RoleBattleState.Battle);
            }

        }

        public override void Execute(Role role, float dt)
        {
            if (role.animComponent == null)
                return;

            m_FSM?.UpdateState(dt);

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

        }

        public override void Exit(Role entity)
        {
            entity.animComponent.SetWeaponSheathTrigger();
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {

        }

        private void Cast(int action)
        {
            player.animComponent.SetAction(action);
            player.animComponent.SetCastTrigger();
        }

        public void SetBattleState(RoleBattleState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

    }

}