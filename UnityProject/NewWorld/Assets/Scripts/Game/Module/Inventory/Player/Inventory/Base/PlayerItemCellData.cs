/************************
	FileName:/Scripts/Game/Module/Inventory/Player/Inventory/Base/PlayerInventoryItemData.cs
	CreateAuthor:neo.xu
	CreateTime:9/2/2020 2:04:58 PM
	Tip:9/2/2020 2:04:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerInventoryItemData : AbstractInventoryCellData
    {
        public AbstractItem item { get; private set; }
        public PlayerInventoryItemData(AbstractItem item) : base(item.width, item.height)
        {
            this.item = item;
        }
    }

}