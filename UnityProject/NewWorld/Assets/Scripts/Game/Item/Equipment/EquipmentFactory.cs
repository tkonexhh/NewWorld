/************************
	FileName:/Scripts/Game/Item/Equipment/EquipmentFactory.cs
	CreateAuthor:neo.xu
	CreateTime:10/22/2020 4:02:06 PM
	Tip:10/22/2020 4:02:06 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EquipmentFactory
    {
        public static Equipment CreateEquipment(TDItem itemConf)
        {
            var conf_Equipment = TDEquipmentTable.GetData(itemConf.SubID);

            Equipment equipment = null;
            switch (conf_Equipment.equipmentType)
            {
                case EquipmentType.Helmet:
                    equipment = new Equipment_Helmet(itemConf.ID);
                    break;
                case EquipmentType.Torso:
                    equipment = new Equipment_Torso(itemConf.ID);
                    break;
                case EquipmentType.Hands:
                    equipment = new Equipment_Hands(itemConf.ID);
                    break;
                case EquipmentType.Legs:
                    equipment = new Equipment_Legs(itemConf.ID);
                    break;
                case EquipmentType.Hips:
                    equipment = new Equipment_Hips(itemConf.ID);
                    break;
                case EquipmentType.Shoulders:
                    equipment = new Equipment_Shoulders(itemConf.ID);
                    break;
                case EquipmentType.Back:
                    equipment = new Equipment_Back(itemConf.ID);
                    break;
                case EquipmentType.Weapon:
                    break;
            }

            if (equipment != null)
            {
                equipment.Conf = itemConf;
            }
            return equipment;
        }


        public static Equipment CreateEquipment(long itemID)
        {
            if (itemID == -1)
                return null;

            var itemConf = TDItemTable.GetData(itemID);

            if (itemConf == null)
                return null;

            return CreateEquipment(itemConf);
        }
    }

}