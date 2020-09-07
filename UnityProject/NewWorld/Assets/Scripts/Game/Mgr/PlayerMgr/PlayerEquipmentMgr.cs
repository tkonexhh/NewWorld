/************************
	FileName:/Scripts/Game/Mgr/PlayerMgr/PlayerEquipmentMgr.cs
	CreateAuthor:neo.xu
	CreateTime:9/7/2020 12:26:17 PM
	Tip:9/7/2020 12:26:17 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerEquipmentMgr : MonoBehaviour, IPlayerMgr
    {
        #region IPlayerComponent
        public void OnInit()
        {

        }
        public void OnUpdate() { }
        public void OnDestroyed() { }
        #endregion


        public void Equip(Equipment equipment)
        {

        }
    }

}