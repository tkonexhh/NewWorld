/************************
	FileName:/Scripts/Game/UI/InventoryPanel/InventoryEnum.cs
	CreateAuthor:neo.xu
	CreateTime:7/14/2020 3:52:28 PM
	Tip:7/14/2020 3:52:28 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{


    public enum InventoryToggleType
    {
        Equipment,
        Supplies,
    }

    public enum InventoryEquipSlot
    {
        Helmet,
        Torso,
        Hands,
        Legs,
        Hips,
        Shoulders,
        Back,
        Weapon,
        Length
    }

}