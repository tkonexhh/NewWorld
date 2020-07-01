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
            EventSystem.S.Register(SetupEvent.ChangeHair, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeHead, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeEyebrows, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeTorso, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeArmUpperRight, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeArmUpperLeft, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeArmLowerRight, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeArmLowerLeft, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeHandRight, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeHandLeft, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeHips, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeLegRight, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeLegLeft, HandleEvent);
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
                case (int)SetupEvent.ChangeEyebrows:
                    appearance.SetEyebrows((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeTorso:
                    appearance.SetTorso((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeArmUpperRight:
                    appearance.SetArmUpperRight((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeArmUpperLeft:
                    appearance.SetArmUpperLeft((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeArmLowerRight:
                    appearance.SetArmLowerRight((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeArmLowerLeft:
                    appearance.SetArmLowerLeft((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeHandRight:
                    appearance.SetHandRight((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeHandLeft:
                    appearance.SetHandLeft((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeHips:
                    appearance.SetHips((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeLegRight:
                    appearance.SetLegRight((int)(args[0]));
                    break;
                case (int)SetupEvent.ChangeLegLeft:
                    appearance.SetLegLeft((int)(args[0]));
                    break;
            }
        }
    }

}