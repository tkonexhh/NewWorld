using System.Security.Cryptography;
/************************
	FileName:/Scripts/Game/Entity/Role/Role_Player.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 2:40:37 PM
	Tip:9/25/2020 2:40:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;
using RootMotion.FinalIK;
using GFrame;

namespace Game.Logic
{
    public class Role_Player : Role
    {
        protected override string resName => "ModularCharacters_Male_Game";

        private RoleInputComponent m_InputComponent;
        private RoleControlComponent m_ControlComponent;
        private RoleFSMComponent m_FSMConponent;

        //---------Mono---------------
        private RoleAnimEvent m_AnimEvent;

        private Rigidbody m_Rigidbody;

        public RoleControlComponent controlComponent => m_ControlComponent;
        public RoleFSMComponent fsmComponent => m_FSMConponent;
        public Rigidbody rigidbody => m_Rigidbody;

        public RoleAnimEvent animEvent => m_AnimEvent;

        public Role_Player() : base()
        {
            var collider = m_RootGameObject.AddComponent<CapsuleCollider>();
            collider.center = new Vector3(0, 0.9f, 0);
            collider.radius = 0.25f;
            collider.height = 1.8f;
            m_Rigidbody = m_RootGameObject.AddComponent<Rigidbody>();
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        protected override void OnResLoaded(GameObject target)
        {
            m_InputComponent = AddComponent(new RoleInputComponent());
            m_FSMConponent = AddComponent(new RoleFSMComponent());
            m_ControlComponent = AddComponent(new RoleControlComponent());

            m_AnimEvent = target.AddComponent<RoleAnimEvent>();
            m_AnimEvent.Init(this);

            m_EquipComponent.ApplyEquipment();

            Timer.S.Post2Really(t =>
            {
                //test
                var weapon = m_EquipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Equipment_Weapon;
                var test = target.GetComponent<InteractionSystemTestGUI>();
                test.interactionObject = weapon.appearance.weaponModel.handleObj;
            }, 2.7f);

        }
    }

}