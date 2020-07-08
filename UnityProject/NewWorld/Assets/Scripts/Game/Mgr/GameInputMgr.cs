/************************
	FileName:/Scripts/Game/Mgr/GameInputMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/8/2020 5:32:43 PM
	Tip:7/8/2020 5:32:43 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class GameInputMgr : TSingleton<GameInputMgr>
    {
        private GameInput m_Input;

        public GameInput.MainActions mainActionMap
        {
            get { return m_Input.Main; }
        }

        public override void OnSingletonInit()
        {
            m_Input = new GameInput();
            Debug.LogError(m_Input.Main);
        }


    }

}