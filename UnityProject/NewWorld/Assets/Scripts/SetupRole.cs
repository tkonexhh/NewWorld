/************************
	FileName:/Scripts/SetuoRole.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 3:29:15 PM
	Tip:6/23/2020 3:29:15 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class SetupRole : Character, IEventListener
    {
        // Start is called before the first frame update
        void Start()
        {
            EventSystem.S.Register(SetupEvent.ChangeAppearance, HandleEvent);
        }

        public void HandleEvent(int key, params object[] args)
        {
            AppearanceSlot slot = (AppearanceSlot)args[0];
            int id = (int)args[1];
            appearance.SetAppearance(slot, id);
            appearance.CombineMeshs();


        }
    }

}