/************************
	FileName:/Scripts/Game/Equipment/EquipmentEnum.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 7:48:01 PM
	Tip:7/2/2020 7:48:01 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public enum EquipmentType
    {
        Helmet,//头盔
        Torso,//身体
        Shoulder,//护肩
        Arm,//手臂
        Hip,//臀部
        Leg,//腿
        Length,
    }

    public enum EquipmentQuality
    {
        Common,
        UnCommon,
        Rare,//稀有
        Lengend,//传说
    }

    public enum HelmetType
    {
        Normal,
        NoHead,//覆盖头部
        NoHair,
        NoFacialHair,

    }

}