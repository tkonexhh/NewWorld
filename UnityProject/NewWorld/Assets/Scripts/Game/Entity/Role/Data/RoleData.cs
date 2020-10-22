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
        private RoleAppearanceData m_AppearanceData;
        private RoleEquipmentData m_EquipmentData;
        private RoleStatusData m_StatusData;

        public RoleAppearanceData appearanceData => m_AppearanceData;
        public RoleEquipmentData equipmentData => m_EquipmentData;
        public RoleStatusData statusData => m_StatusData;

        public RoleData(Entity owner) : base(owner)
        {
            m_StatusData = new RoleStatusData();
            m_AppearanceData = new RoleAppearanceData();
            m_AppearanceData.basicAppearance = new BasicAppearance();
            m_EquipmentData = new RoleEquipmentData();
            m_EquipmentData.helmetID = 4;
            m_EquipmentData.torsoID = 24;
            m_EquipmentData.handsID = 33;
            m_EquipmentData.legsID = 34;
            m_EquipmentData.hipsID = 35;
            m_EquipmentData.shouldersID = 63;
            // m_EquipmentData.backID = 86;
        }
    }

}