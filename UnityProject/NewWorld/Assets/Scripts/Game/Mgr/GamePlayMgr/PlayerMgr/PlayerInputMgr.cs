/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr/PlayerMgr/PlayerInputMgr.cs
	CreateAuthor:neo.xu
	CreateTime:2/25/2021 5:37:57 PM
	Tip:2/25/2021 5:37:57 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class PlayerInputMgr : IPlayerMgr
    {
        public void OnInit()
        {
            GameInputMgr.S.openInventoryEvent += OnInventoryPerformed;
        }
        public void OnUpdate() { }
        public void OnDestroyed() { }


        private void OnInventoryPerformed()
        {
            //交换显示
            UIMgr.S.ToggleShowPanel(UIID.Inventorypanel);
        }
    }

}