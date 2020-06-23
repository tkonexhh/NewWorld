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
    public class SetuoRole : Character, IEventListener
    {
        // Start is called before the first frame update
        void Start()
        {
            EventSystem.S.Register(SetupEvent.ChangeHair, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeHead, HandleEvent);
        }



        public void HandleEvent(int key, params object[] args)
        {
            switch (key)
            {
                case (int)SetupEvent.ChangeHair:
                    appearance.SetHair((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeHead:
                    appearance.SetHead((int)(args[0]));
                    break;
            }
        }
    }

}