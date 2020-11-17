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
            m_EquipmentMap.Add((int)InventoryEquipSlot.Helmet, EquipmentFactory.CreateEquipment(role.data.equipmentData.helmetID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Torso, EquipmentFactory.CreateEquipment(role.data.equipmentData.torsoID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Hands, EquipmentFactory.CreateEquipment(role.data.equipmentData.handsID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Legs, EquipmentFactory.CreateEquipment(role.data.equipmentData.legsID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Hips, EquipmentFactory.CreateEquipment(role.data.equipmentData.hipsID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Shoulders, EquipmentFactory.CreateEquipment(role.data.equipmentData.shouldersID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Back, EquipmentFactory.CreateEquipment(role.data.equipmentData.backID));
            m_EquipmentMap.Add((int)InventoryEquipSlot.Weapon, EquipmentFactory.CreateTestEquipment(WeaponType.TwoHandAxe));
        }

        public void ApplyEquipment()
        {
            foreach (var equipment in m_EquipmentMap.Values)
            {
                equipment?.Equip(role);
            }
        }

        public Weapon GetWeapon()
        {
            var equipment = GetEquipmentBySlot(InventoryEquipSlot.Weapon);
            if (equipment != null)
            {
                return equipment as Weapon;
            }
            return null;
        }

        public Equipment GetEquipmentBySlot(InventoryEquipSlot slot)
        {
            Equipment equipment;

            if (m_EquipmentMap.TryGetValue((int)slot, out equipment))
            {
                return equipment;
            }
            return null;
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