/************************
	FileName:/Scripts/Game/Module/Inventory/Player/Equipment/PlayerEquipmentView.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 8:20:25 PM
	Tip:9/1/2020 8:20:25 PM
************************/

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Logic
{

    public class PlayerEquipmentView : AbstractInventoryView
    {
        [SerializeField] private PlayerEquipmentCellView m_Head;
        [SerializeField] private PlayerEquipmentCellView m_Torso;

        public int CellCount => (int)InventoryEquipSlot.Length;
        private Dictionary<int, PlayerEquipmentCellView> m_CellViewMap = new Dictionary<int, PlayerEquipmentCellView>();
        int? originalId;
        IInventoryCellData originalCellData;

        public PlayerEquipmentViewData playerEquipmentViewData;

        #region IInventoryView
        public override void Apply(IInventoryViewData data)
        {
            base.Apply(data);
            InitMap();
            playerEquipmentViewData = viewData as PlayerEquipmentViewData;

            if (itemViews == null || itemViews.Length != CellCount)
            {
                itemViews = new PlayerEquipmentCellView[CellCount];
                for (int i = 0; i < CellCount; i++)
                {
                    var itemView = GetCellBySlot(i);
                    itemViews[i] = itemView;
                    itemView.SetCellCallback(
                       onCellClick,
                       onCellOptionClick,
                       onCellEnter,
                       onCellExit,
                       null,
                       null);
                    itemView.Apply(null);
                }
            }



            for (var i = 0; i < playerEquipmentViewData.CellData.Length; i++)
            {
                itemViews[i].Apply(playerEquipmentViewData.CellData[i]);
            }
        }

        public override void OnPrePick(IInventoryCellView targetCell)
        {
            if (targetCell?.CellData == null)
            {
                return;
            }
        }

        public override bool OnPick(IInventoryCellView targetCell)
        {
            if (targetCell?.CellData == null)
            {
                return false;
            }

            var id = viewData.GetId(targetCell.CellData);
            if (id.HasValue)
            {
                originalId = id;
                originalCellData = targetCell.CellData;

                itemViews[id.Value].Apply(null);
                viewData.InsertInventoryItem(id.Value, null);
                return true;
            }


            return false;
        }

        public override void OnPicked(IInventoryCellView effectCell)
        {

        }

        public override void OnDrag(IInventoryCellView targetCell, IInventoryCellView effectCell, PointerEventData pointerEventData)
        {
            if (targetCell == null)
            {
                return;
            }
        }
        public override bool OnDrop(IInventoryCellView targetCell, IInventoryCellView effectCell)
        {
            if (!itemViews.Any(item => item == targetCell))
            {
                return false;
            }
            // Debug.LogError(GetType().ToString() + "OnDrop" + (effectCell.CellData.GetType()));
            var cellView = targetCell as PlayerEquipmentCellView;


            // if (playerEquipmentViewData.CheckInsert((int)cellView.slot, effectCell.CellData))
            // {
            //     Debug.LogError(GetType().ToString() + "Equip");
            //     targetCell.Apply(new PlayerEquipmentCellData(cellView.slot, (cellView.CellData as PlayerEquipmentCellData).item as Equipment));
            //     playerEquipmentViewData.InsertInventoryItem((int)cellView.slot, cellView.CellData);
            // }


            //如果拿起的物品是装备 并且装备类型和格子类型匹配的话 就装备上
            if (effectCell.CellData is PlayerInventoryCellData inventoryCellData && inventoryCellData.item is Equipment equipment)
            {
                Debug.LogError(GetType().ToString() + "drop" + "---" + cellView.slot + ":" + equipment.equipmentType);

                if (CheckCanEquip(cellView.slot, equipment.equipmentType))
                {
                    Debug.LogError(GetType().ToString() + "Equip");
                    var equipCellData = new PlayerEquipmentCellData(equipment);
                    targetCell.Apply(equipCellData);
                    Debug.LogError(cellView.slot + "--" + inventoryCellData);
                    playerEquipmentViewData.InsertInventoryItem((int)cellView.slot, equipCellData);
                    //TODO 处理交换
                    return true;
                }
            }

            return false;
        }
        public override void OnDroped(bool isDroped)
        {
            if (!isDroped && originalId.HasValue)
            {
                // revert
                itemViews[originalId.Value].Apply(originalCellData);
                viewData.InsertInventoryItem(originalId.Value, originalCellData);
            }

            originalId = null;
            originalCellData = null;
        }
        public override void OnCellEnter(IInventoryCellView targetCell, IInventoryCellView effectCell) { }
        public override void OnCellExit(IInventoryCellView targetCell) { }
        #endregion

        private void InitMap()
        {
            m_CellViewMap.Clear();
            m_CellViewMap.Add((int)InventoryEquipSlot.Helmet, m_Head);
            m_CellViewMap.Add((int)InventoryEquipSlot.Torso, m_Torso);
        }

        private PlayerEquipmentCellView GetCellBySlot(int slot)
        {
            PlayerEquipmentCellView cellView;
            if (m_CellViewMap.TryGetValue(slot, out cellView))
            {
                return cellView;
            }
            return null;
        }


        private bool CheckCanEquip(InventoryEquipSlot slot, EquipmentType type)
        {
            switch (slot)
            {
                case InventoryEquipSlot.Helmet:
                    if (type == EquipmentType.Helmet)
                        return true;
                    break;

                case InventoryEquipSlot.Torso:
                    if (type == EquipmentType.Torso)
                        return true;
                    break;
            }
            return false;
        }
    }

}