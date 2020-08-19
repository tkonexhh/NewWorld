/************************
	FileName:/Scripts/Game/Module/Inventory/Standard/StandardCellBtn.cs
	CreateAuthor:neo.xu
	CreateTime:8/19/2020 12:52:22 PM
	Tip:8/19/2020 12:52:22 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Logic
{
    public class InventoryCellButton : Button, IInventoryCellActions
    {
        public void SetCallback(
             Action onPointerClick,
             Action onPointerClickOption,
             Action onPointerEnter,
             Action onPointerExit,
             Action onPointerDown,
             Action onPointerUp)
        {

        }
    }

}