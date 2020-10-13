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
            appearance.data.helmetWithoutHeadType = HelmetType.Normal;
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, -1);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, -1);
        }
    }

    public class EquipmentAppearance_Helmet_NoFacialHair : EquipmentAppearance_Helmet
    {
        private int m_OldFacialHairID;

        public EquipmentAppearance_Helmet_NoFacialHair(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.data.helmetWithoutHeadType = HelmetType.NoFacialHair;
            m_OldFacialHairID = appearance.data.basicAppearance.facialHairID;
            appearance.SetAppearance(AppearanceSlot.FacialHair, 0);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, -1);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.FacialHair, m_OldFacialHairID);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, -1);
        }
    }

    public class EquipmentAppearance_Helmet_NoHair : EquipmentAppearance_Helmet
    {
        private int m_OldHairID;
        public EquipmentAppearance_Helmet_NoHair(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            appearance.data.helmetWithoutHeadType = HelmetType.NoHair;
            m_OldHairID = appearance.data.basicAppearance.hairID;
            appearance.SetAppearance(AppearanceSlot.Hair, 0);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, -1);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.Hair, m_OldHairID);
            appearance.SetAppearance(AppearanceSlot.HelmetWithHead, -1);
        }
    }

    public class EquipmentAppearance_Helmet_NoHead : EquipmentAppearance_Helmet
    {
        private int m_OldHairID;
        private int m_OldEyeBrowsID;
        private int m_OldHeadID;
        private int m_OldFacialHairID;
        public EquipmentAppearance_Helmet_NoHead(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            m_OldHairID = appearance.data.basicAppearance.hairID;
            m_OldFacialHairID = appearance.data.basicAppearance.facialHairID;
            m_OldEyeBrowsID = appearance.data.basicAppearance.eyeBrows;
            m_OldHeadID = appearance.data.basicAppearance.headID;

            appearance.SetAppearance(AppearanceSlot.Hair, 0);
            appearance.SetAppearance(AppearanceSlot.EyeBrows, -1);
            appearance.SetAppearance(AppearanceSlot.Head, -1);
            appearance.SetAppearance(AppearanceSlot.FacialHair, 0);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, -1);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, id);
        }

        public override void Removeppearance(CharacterAppearance appearance)
        {
            appearance.SetAppearance(AppearanceSlot.Hair, m_OldHairID);
            appearance.SetAppearance(AppearanceSlot.EyeBrows, m_OldEyeBrowsID);
            appearance.SetAppearance(AppearanceSlot.Head, m_OldHeadID);
            appearance.SetAppearance(AppearanceSlot.FacialHair, m_OldFacialHairID);
            appearance.SetAppearance(AppearanceSlot.HelmetWithoutHead, -1);
        }
    }

}