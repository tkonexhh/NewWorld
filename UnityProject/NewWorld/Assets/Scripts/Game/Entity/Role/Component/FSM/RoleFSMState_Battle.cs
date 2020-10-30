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
    public class RoleFSMState_Battle : FSMState<Role>
    {
        private Role_Player player;
        private FSMStateMachine<Role_Player> m_FSM;

        public override void Enter(Role entity, params object[] args)
        {
            player = entity as Role_Player;

            //0空拳
            //1双手剑
            //2双手矛
            //3双手斧
            entity.animComponent.SetWeaponSwitch(-1);
            entity.animComponent.SetWeapon(3);
            entity.animComponent.SetWeaponUnSheathTrigger();

            entity.animComponent.SetMoving(false);
            WeaponUnSheath();

            if (m_FSM == null)
            {
                m_FSM = new FSMStateMachine<Role_Player>(player);
                m_FSM.SetGlobalState(new RoleBattleFSMState_Global());
                m_FSM.stateFactory = new FSMStateFactory<Role_Player>(false);
                m_FSM.stateFactory.RegisterState(RoleBattleState.Battle, new RoleBattleFSMState_Move());
                m_FSM.stateFactory.RegisterState(RoleBattleState.Blocking, new RoleBattleFSMState_Blocking());
                m_FSM.stateFactory.RegisterState(RoleBattleState.Crouch, new RoleBattleFSMState_Crouch());
            }

            SetBattleState(RoleBattleState.Battle);

        }

        public override void Update(Role role, float dt)
        {
            if (role.animComponent == null)
                return;

            m_FSM?.UpdateState(dt);
        }

        public override void Exit(Role entity)
        {
            entity.animComponent.SetWeaponSheathTrigger();
            entity.animComponent.SetWeaponSwitch(-1);
            entity.animComponent.SetWeapon(3);
            WeaponSheath();
        }

        public override void OnMsg(Role entity, int key, params object[] args)
        {
        }

        public void SetBattleState(RoleBattleState state)
        {
            m_FSM.SetCurrentStateByID(state);
        }

        private void WeaponUnSheath()
        {
            //伸手抓武器
            var weapon = player.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            var weaponHand = (weapon.appearance.weaponModel as WeaponModel_TwoHandAxe).handleObj;
            player.iKComponent.rightHandIK.SetFocusTarget(weaponHand.transform);
            // player.monoReference.interactionSystem.StartInteraction(RootMotion.FinalIK.FullBodyBipedEffector.RightHand, weapon.appearance.weaponModel.handleObj, true);
        }

        private void WeaponSheath()
        {
            var weapon = player.equipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
            var model = (weapon.appearance.weaponModel as WeaponModel_TwoHandAxe);
            player.iKComponent.rightHandIK.SetFocusTarget(model.handleObj.transform);
            // player.monoReference.interactionSystem.StartInteraction(RootMotion.FinalIK.FullBodyBipedEffector.RightHand, weapon.appearance.weaponModel.handleObj, true);
        }

    }

}