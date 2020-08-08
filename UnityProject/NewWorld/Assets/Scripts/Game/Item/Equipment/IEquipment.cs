/************************
	FileName:/Scripts/Game/Equipment/IEquipment.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 7:42:54 PM
	Tip:7/2/2020 7:42:54 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public interface IEquipment
    {
        void Equip(Role character);
        void UnEquip(Role character);
    }

}