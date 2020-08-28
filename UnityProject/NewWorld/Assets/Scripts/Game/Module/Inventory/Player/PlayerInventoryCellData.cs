/************************
	FileName:/Scripts/Game/Module/Inventory/Player/PlayerInventoryCellData.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 1:07:18 PM
	Tip:8/18/2020 1:07:18 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerInventoryCellData : AbstractInventoryCellData
    {
        public AbstractItem item { get; set; }
        public PlayerInventoryCellData(AbstractItem item) : base(item)
        {
            this.item = item;
        }
    }

}