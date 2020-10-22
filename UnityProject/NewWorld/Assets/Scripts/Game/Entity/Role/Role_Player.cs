/************************
	FileName:/Scripts/Game/Entity/Role/Role_Player.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 2:40:37 PM
	Tip:9/25/2020 2:40:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Role_Player : Role
    {
        protected override string resName => "ModularCharacters_Male_Game";

        private RoleInputComponent m_InputComponent;
        private RoleControlComponent m_ControlComponent;
        private RoleFSMComponent m_FSMConponent;

        public RoleControlComponent controlComponent => m_ControlComponent;
        public RoleFSMComponent fsmComponent => m_FSMConponent;

        public Role_Player() : base()
        {
            m_RootGameObject.AddComponent<Rigidbody>();
            var collider = m_RootGameObject.AddComponent<CapsuleCollider>();
            collider.center = new Vector3(0, 0.9f, 0);
            collider.radius = 0.25f;
            collider.height = 1.8f;
        }

        protected override void OnResLoaded(GameObject target)
        {
            m_InputComponent = AddComponent(new RoleInputComponent());
            m_FSMConponent = AddComponent(new RoleFSMComponent());
            m_ControlComponent = AddComponent(new RoleControlComponent());

            target.AddComponent<RoleAnimEvent>();

            m_EquipComponent.ApplyEquipment();

            Equipment_Weapon_TwoHandAxe axe = new Equipment_Weapon_TwoHandAxe(1);
            axe.Equip(this);
        }
    }

}