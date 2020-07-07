/************************
	FileName:/Scripts/Game/Character/CharacterEnum.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 11:00:08 AM
	Tip:7/7/2020 11:00:08 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class CharacterEnumHelper
    {
        public static AppearanceSlot GetSlotByName(string name)
        {
            switch (name)
            {
                case "Hair":
                    return AppearanceSlot.Hair;
            }
            return AppearanceSlot.Length;
        }
    }

    public enum AppearanceSlot
    {
        Hair,
        Head,
        FacialHair,//胡子
        EyeBrows,
        Torso,
        ArmUpperRight,
        ArmUpperLeft,
        ArmLowerRight,
        ArmLowerLeft,
        HandRight,
        HandLeft,
        Hips,
        LegRight,
        LegLeft,

        ShoulderRight,
        ShoulderLeft,
        ElbowRight,
        ElbowLeft,
        KneeRight,
        KneeLeft,
        Ear,
        HipsAttach,
        HelmetWithoutHead,
        HelmetWithHead,
        Length,
    }

}