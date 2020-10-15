/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleTestComponent.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 11:28:04 AM
	Tip:10/15/2020 11:28:04 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleTestComponent : RoleBaseComponent
    {
        private WeaponModel_TwoHandAxe m_Model;
        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Model = role.gameObject.GetComponentInChildren<WeaponModel_TwoHandAxe>();

            Debug.LogError(m_Model);
        }
    }

}