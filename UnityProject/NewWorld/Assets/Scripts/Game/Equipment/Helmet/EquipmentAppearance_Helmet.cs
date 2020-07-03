/************************
	FileName:/Scripts/Game/Equipment/Helmet/EquipmentAppearance_Helmet.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 1:43:19 PM
	Tip:7/3/2020 1:43:19 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class EquipmentAppearance_Helmet : EquipmentAppearance
    {
        public EquipmentAppearance_Helmet(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {

        }
    }

    public class EquipmentAppearance_Helmet_Normal : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_Normal(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.HideSlot(AppearanceSlot.HelmetWithoutHead);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }
    }

    public class EquipmentAppearance_Helmet_NoFacialHair : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_NoFacialHair(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.HideSlot(AppearanceSlot.FacialHair);
        }
    }

    public class EquipmentAppearance_Helmet_NoHair : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_NoHair(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.HideSlot(AppearanceSlot.Hair);
        }
    }

    public class EquipmentAppearance_Helmet_NoHead : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_NoHead(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.HideSlot(AppearanceSlot.Hair);
            appearance.HideSlot(AppearanceSlot.EyeBrows);
            appearance.HideSlot(AppearanceSlot.Head);
            appearance.HideSlot(AppearanceSlot.FacialHair);
            appearance.HideSlot(AppearanceSlot.EyeBrows);
            appearance.HideSlot(AppearanceSlot.HelmetWithHead);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, id);
        }
    }

}