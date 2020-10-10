/************************
	FileName:/Scripts/Game/Mgr/PlayerMgr/PlayerInventoryFactory.cs
	CreateAuthor:neo.xu
	CreateTime:9/3/2020 7:36:20 PM
	Tip:9/3/2020 7:36:20 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerInventoryFactory
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
            }

            if (equipment != null)
            {
                equipment.Conf = itemConf;
            }
            return equipment;
        }
    }

}