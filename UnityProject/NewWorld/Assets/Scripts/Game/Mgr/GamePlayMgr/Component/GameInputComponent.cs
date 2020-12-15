/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr/Component/GameInputComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/25/2020 2:00:32 PM
	Tip:9/25/2020 2:00:32 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GFrame;


namespace Game.Logic
{
    public class GameInputComponent : GameEngineComponent
    {
        public override void Init()
        {
            GameInputMgr.S.shortcutActions.Inventory.started += OnInventoryPerformed;
        }

        private void OnInventoryPerformed(InputAction.CallbackContext callback)
        {
            //交换显示
            UIMgr.S.ToggleShowPanel(UIID.Inventorypanel);
            // UIMgr.S.OpenPanel(UIID.Inventorypanel);
        }

    }

}