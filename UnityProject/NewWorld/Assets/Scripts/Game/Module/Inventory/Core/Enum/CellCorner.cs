/************************
	FileName:/Scripts/Game/Module/Inventory/Core/Enum/CellCorner.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 12:38:16 PM
	Tip:8/25/2020 12:38:16 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public enum CellCorner
    {
        None = 0,
        Top = 1 << 1,
        Bottom = 1 << 2,
        Left = 1 << 3,
        Right = 1 << 4,
        TopLeft = Top | Left,
        TopRight = Top | Right,
        BottomLeft = Bottom | Left,
        BottomRight = Bottom | Right,
    }
}