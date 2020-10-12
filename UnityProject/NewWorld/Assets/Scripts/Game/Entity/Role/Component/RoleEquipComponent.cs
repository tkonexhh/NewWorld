/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleEquipComponent.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:54:47 PM
	Tip:8/8/2020 9:54:47 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleEquipComponent : RoleBaseComponent
    {
        private Dictionary<int, Equipment> m_EquipmentMap = new Dictionary<int, Equipment>();

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_EquipmentMap.Add((int)EquipmentType.Helmet, new Equipment_Helmet(role.data.equipmentData.helmetID));
            m_EquipmentMap.Add((int)EquipmentType.Torso, new Equipment_Torso(role.data.equipmentData.torsoID));
            m_EquipmentMap.Add((int)EquipmentType.Hands, new Equipment_Hands(role.data.equipmentData.handsID));
            m_EquipmentMap.Add((int)EquipmentType.Legs, new Equipment_Legs(role.data.equipmentData.legsID));
            m_EquipmentMap.Add((int)EquipmentType.Hips, new Equipment_Hips(role.data.equipmentData.hipsID));
            m_EquipmentMap.Add((int)EquipmentType.Shoulders, new Equipment_Shoulders(role.data.equipmentData.shouldersID));
            m_EquipmentMap.Add((int)EquipmentType.Back, new Equipment_Back(role.data.equipmentData.backID));
        }

        public void ApplyEquipment()
        {
            foreach (var equipment in m_EquipmentMap.Values)
            {
                equipment.Equip(role);
            }
        }

        public void Equip(Equipment equipment)
        {
            equipment.Equip(role);
            role.data.equipmentData.SetData(equipment.equipmentType, (int)equipment.id);
            m_EquipmentMap[(int)equipment.equipmentType] = equipment;
        }

        public void UnEquip(Equipment equipment)
        {
            equipment.UnEquip(role);
            role.data.equipmentData.SetData(equipment.equipmentType, -1);
            m_EquipmentMap[(int)equipment.equipmentType] = null;
        }
    }

}