/************************
	FileName:/Scripts/Game/Entity/Character/CharacterData.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:44:03 PM
	Tip:8/8/2020 9:44:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleData : EntityData
    {
        public BasicAppearance basicAppearance;
        private RoleAppearanceData m_AppearanceData;
        private RoleEquipmentData m_EquipmentData;

        public RoleAppearanceData appearanceData => m_AppearanceData;
        public RoleEquipmentData equipmentData => m_EquipmentData;

        public RoleData(Entity owner) : base(owner)
        {
            m_AppearanceData = new RoleAppearanceData();

            m_EquipmentData = new RoleEquipmentData();
            m_EquipmentData.helmetID = 4;
            m_EquipmentData.torsoID = 5;
            m_EquipmentData.handsID = 7;
            m_EquipmentData.legsID = 8;
            m_EquipmentData.hipsID = 9;
            m_EquipmentData.shouldersID = 10;
            m_EquipmentData.backID = 11;
        }
    }

}