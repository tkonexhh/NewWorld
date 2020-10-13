/************************
	FileName:/Scripts/Game/Equipment/Helmet/EquipmentAppearance_Helmet.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 1:43:19 PM
	Tip:7/3/2020 1:43:19 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
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
            Debug.LogError("EquipmentAppearance_Helmet_Normal SetAppearance");
            // appearance.IsHideSlot(AppearanceSlot.HelmetWithoutHead, true);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, -1);
        }
    }

    public class EquipmentAppearance_Helmet_NoFacialHair : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_NoFacialHair(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            Debug.LogError("EquipmentAppearance_Helmet_NoFacialHair SetAppearance");
            // appearance.IsHideSlot(AppearanceSlot.FacialHair, true);
            appearance.SetAppearance(AppearanceSlot.FacialHair, 0);
            // appearance.IsHideSlot(AppearanceSlot.HelmetWithoutHead, true);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            // appearance.IsHideSlot(AppearanceSlot.FacialHair, false);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, -1);
        }
    }

    public class EquipmentAppearance_Helmet_NoHair : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_NoHair(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            Debug.LogError("EquipmentAppearance_Helmet_NoHair SetAppearance");
            appearance.IsHideSlot(AppearanceSlot.Hair, true);
            // appearance.IsHideSlot(AppearanceSlot.HelmetWithoutHead, true);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.IsHideSlot(AppearanceSlot.Hair, false);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, -1);
        }
    }

    public class EquipmentAppearance_Helmet_NoHead : EquipmentAppearance_Helmet
    {
        public EquipmentAppearance_Helmet_NoHead(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.IsHideSlot(AppearanceSlot.Hair, true);
            appearance.IsHideSlot(AppearanceSlot.EyeBrows, true);
            appearance.IsHideSlot(AppearanceSlot.Head, true);
            appearance.IsHideSlot(AppearanceSlot.FacialHair, true);
            // appearance.IsHideSlot(AppearanceSlot.HelmetWithHead, true);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.IsHideSlot(AppearanceSlot.Hair, false);
            appearance.IsHideSlot(AppearanceSlot.EyeBrows, false);
            appearance.IsHideSlot(AppearanceSlot.Head, false);
            appearance.IsHideSlot(AppearanceSlot.FacialHair, false);
            appearance.IsHideSlot(AppearanceSlot.HelmetWithHead, false);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, -1);
        }
    }

}