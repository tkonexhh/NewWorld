/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleEquipComponent.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:54:47 PM
	Tip:8/8/2020 9:54:47 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleEquipComponent : EntityComponennt
    {
        private Dictionary<int, Equipment> m_EquipmentMap = new Dictionary<int, Equipment>();

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
        }
    }

}