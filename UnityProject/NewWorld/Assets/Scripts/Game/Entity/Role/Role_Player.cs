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

        //---------Mono---------------
        private RoleAnimEvent m_AnimEvent;

        protected override void OnResLoaded(GameObject target)
        {
            m_AnimEvent = target.AddComponent<RoleAnimEvent>();
            m_AnimEvent.Init(this);

            m_EquipComponent.ApplyEquipment();

            Timer.S.Post2Really(t =>
            {
                //test
                var weapon = m_EquipComponent.GetEquipmentBySlot(InventoryEquipSlot.Weapon) as Weapon;
                var test = target.GetComponent<InteractionSystemTestGUI>();
                test.interactionObject = weapon.appearance.weaponModel.handleObj;
            }, 2.7f);

        }
    }

}