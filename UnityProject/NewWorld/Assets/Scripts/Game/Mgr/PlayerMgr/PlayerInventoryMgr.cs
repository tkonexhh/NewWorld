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
    public class PlayerInventoryMgr : MonoBehaviour, IPlayerMgr
    {
        private List<Equipment> m_LstEquipment = new List<Equipment>();
        private List<SupplyItem> m_LstSupply = new List<SupplyItem>();

        public List<SupplyItem> LstSupply { get => m_LstSupply; }

        public List<Equipment> LstEquipment { get => m_LstEquipment; }


        #region IPlayerComponent
        public void OnInit()
        {
            AddItem(1);
            AddItem(1, 10);
            AddItem(2, 3);
            AddItem(2, 3);
            AddItem(3);
            AddItem(4);
            AddItem(4);
            AddItem(4);
            AddItem(5);
            AddItem(4);
            AddItem(5);
            AddItem(5);
            AddItem(4);
            AddItem(5);
            AddItem(6);
            AddItem(7);
            AddItem(7);
            AddItem(7);
        }
        public void OnUpdate() { }
        public void OnDestroyed() { }
        #endregion


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
            Equipment equipment = PlayerInventoryFactory.CreateEquipment(itemConf, id);
            if (equipment == null)
            {
                Debug.LogError("Failed to Add Equipment");
                return;
            }
            m_LstEquipment.Add(equipment);
        }
    }

}