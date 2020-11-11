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


            //不同的动画层不要用trigger来触发，只会触发一次，trigger会被吞掉，直接使用play来暂时解决
            WeaponUnSheath();

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

            // player.role.animComponent.SetWeaponSwitch(-1);
            // player.role.animComponent.SetWeapon(3);

            // entity.animComponent.animator.CrossFade();
            //下半身动画也需要插值到Idle动画
            bool isMoving = player.role.animComponent.GetMoving();
            if (isMoving)
            {
                player.role.animComponent.animator.CrossFade("Relax-Movement", 0.25f, 0, 0.4f);
            }
            else
            {
                player.role.animComponent.animator.CrossFade("Idle", 0.25f, 0, 0.4f);
            }


            WeaponSheath();
        }

        public override void OnMsg(Player entity, int key, params object[] args)
        {
        }

        public void SetBattleState(RoleBattleState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

        /// <summary>
        /// 伸手拿武器
        /// </summary>
        private void WeaponUnSheath()
        {
            var weapon = m_Player.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            weapon.UnSheath(m_Player.role);
        }

        /// <summary>
        /// 把武器放回去
        /// </summary>
        private void WeaponSheath()
        {
            var weapon = m_Player.role.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            weapon.Sheath(m_Player.role);
        }

    }

}