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
using GFrame;

namespace Game.Logic
{

    public class PlayerEquipmentView : AbstractInventoryView, IEventListener
    {
        [SerializeField] private PlayerEquipmentCellView m_Head;
        [SerializeField] private PlayerEquipmentCellView m_Torso;
        [SerializeField] private PlayerEquipmentCellView m_Hands;
        [SerializeField] private PlayerEquipmentCellView m_Legs;

        public int CellCount => (int)InventoryEquipSlot.Length;
        private Dictionary<int, PlayerEquipmentCellView> m_CellViewMap = new Dictionary<int, PlayerEquipmentCellView>();
        int? originalId;
        IInventoryCellData originalCellData;

        public PlayerEquipmentViewData playerEquipmentViewData;

        #region IEventListener
        public void RegisterEvent()
        {
            GFrame.EventSystem.S.Register(EventID.OnEquipInventroy, HandleEvent);
        }
        public void UnRegisterEvent()
        {
            GFrame.EventSystem.S.UnRegister(EventID.OnEquipInventroy, HandleEvent);
        }
        public void HandleEvent(int key, params object[] args)
        {
            switch (key)
            {
                case (int)EventID.OnEquipInventroy:
                    PlayerInventoryCellData cellData = (PlayerInventoryCellData)args[0];
                    if (cellData.item is Equipment equipment)
                    {
                        PlayerEquipmentCellView equipmentCellView = GetCellByEquipmentType(equipment.equipmentType);
                        Equip(equipmentCellView, equipment);
                    }
                    break;
            }
        }
        #endregion

        #region IInventoryView
        public override void Init()
        {
            RegisterEvent();
        }

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

                ApplyCell(itemViews[id.Value], id.Value, null);
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
                //Debug.LogError(GetType().ToString() + "drop" + "---" + cellView.slot + ":" + equipment.equipmentType);

                if (CheckCanEquip(cellView.slot, equipment.equipmentType))
                {
                    Equip(cellView, equipment);
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
                ApplyCell(itemViews[originalId.Value], originalId.Value, originalCellData);
            }

            originalId = null;
            originalCellData = null;
        }

        public override void OnCellClick(IInventoryCellView targetCell)
        {
            //Debug.LogError(this.GetType().ToString() + "OnCellClick");
        }
        public override void OnCellOptionClick(IInventoryCellView targetCell)
        {
            if (!itemViews.Any(item => item == targetCell))
            {
                return;
            }

            //  右键脱下装备
            if (targetCell.CellData is PlayerEquipmentCellData equipmentCellData)
            {
                if (equipmentCellData.item is Equipment) { Equip(targetCell as PlayerEquipmentCellView, null); }
            }
        }

        public override void OnCellEnter(IInventoryCellView targetCell, IInventoryCellView effectCell) { }
        public override void OnCellExit(IInventoryCellView targetCell) { }
        #endregion

        private void InitMap()
        {
            m_CellViewMap.Clear();
            m_CellViewMap.Add((int)InventoryEquipSlot.Helmet, m_Head);
            m_CellViewMap.Add((int)InventoryEquipSlot.Torso, m_Torso);
            m_CellViewMap.Add((int)InventoryEquipSlot.Hands, m_Hands);
            m_CellViewMap.Add((int)InventoryEquipSlot.Legs, m_Legs);
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

        private PlayerEquipmentCellView GetCellByEquipmentType(EquipmentType type)
        {
            //TODO 暂时把EquipmentType 和SlotType一一对应起来，后续有可能出现不对应的情况
            return GetCellBySlot((int)type);
            //return null;
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
                case InventoryEquipSlot.Hands:
                    if (type == EquipmentType.Hands)
                        return true;
                    break;
                case InventoryEquipSlot.Legs:
                    if (type == EquipmentType.Legs)
                        return true;
                    break;
            }
            return false;
        }


        private void Equip(PlayerEquipmentCellView cellView, Equipment equipment)
        {
            var nowEquipment = cellView.CellData as PlayerEquipmentCellData;
            if (nowEquipment != null)
            {
                GFrame.EventSystem.S.Send(EventID.OnAddInventory, new PlayerInventoryCellData(nowEquipment.item));
            }

            if (equipment == null)
            {
                ApplyCell(cellView, (int)cellView.slot, null);
            }
            else
            {
                var equipCellData = new PlayerEquipmentCellData(equipment);
                ApplyCell(cellView, (int)cellView.slot, equipCellData);
                GFrame.EventSystem.S.Send(EventID.OnRefeshAppearance, equipment);
            }
            //Debug.LogError(equipment.equipmentAppearance);


        }
    }

}