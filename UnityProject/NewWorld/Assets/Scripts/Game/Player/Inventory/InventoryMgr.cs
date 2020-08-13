/************************
	FileName:/Scripts/Game/Player/Inventory/InventoryMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/13/2020 5:57:30 PM
	Tip:7/13/2020 5:57:30 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class InventoryMgr : TSingleton<InventoryMgr>
    {
        private List<Equipment> m_LstEquipment = new List<Equipment>();
        private List<SupplyItem> m_LstSupply = new List<SupplyItem>();

        public List<SupplyItem> LstSupply
        {
            get { return m_LstSupply; }
        }

        public List<Equipment> LstEquipment
        {
            get { return m_LstEquipment; }
        }

        public override void OnSingletonInit()
        {
        }

        public void AddItem(long id, int num = 1)
        {
            TDItem itemConf = TDItemTable.GetData(id);
            switch (itemConf.itemType)
            {
                case ItemType.Equipment:
                    AddEquipment(itemConf, id);
                    break;
                case ItemType.Food:
                    AddSupply(itemConf, id, num);
                    break;
            }

        }

        public void AddSupply(TDItem itemConf, long id, int num)
        {
            SupplyItem bagItem = m_LstSupply.Find(item => item.id == id);
            if (bagItem != null)
            {
                bagItem.AddNum(num);
            }
            else
            {
                SupplyItem newitem = new SupplyItem(id, num);
                newitem.Conf = itemConf;
                m_LstSupply.Add(newitem);
            }
        }

        public void AddEquipment(TDItem itemConf, long id)
        {
            Equipment equipment = new Equipment(id);
            equipment.Conf = itemConf;
            m_LstEquipment.Add(equipment);
        }
    }

}