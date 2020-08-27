/************************
	FileName:/Scripts/Game/Module/Inventory/Core/IInventoryCellActions.cs
	CreateAuthor:neo.xu
	CreateTime:8/19/2020 12:49:31 PM
	Tip:8/19/2020 12:49:31 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IInventoryCellActions
    {
        void SetActive(bool value);
        void SetCallback(
            Action onPointerClick,//鼠标左键  
            Action onPointerClickOption,//鼠标右键
            Action onPointerEnter,
            Action onPointerExit,
            Action onPointerDown,
            Action onPointerUp);
    }

}