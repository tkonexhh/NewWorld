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

        }

        protected override void OnResLoaded(GameObject target)
        {
            m_InputComponent = AddComponent(new RoleInputComponent());
            m_FSMConponent = AddComponent(new RoleFSMComponent());
            m_ControlComponent = AddComponent(new RoleControlComponent());

            target.AddComponent<RoleAnimEvent>();

            m_EquipComponent.ApplyEquipment();
        }
    }

}