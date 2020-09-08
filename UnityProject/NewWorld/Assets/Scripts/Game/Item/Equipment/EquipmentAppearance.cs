/************************
	FileName:/Scripts/Game/Equipment/EquipmentAppearance.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 7:24:04 PM
	Tip:7/2/2020 7:24:04 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    /// <summary>
    /// 装备外观数据(可以用来做幻化)
    /// </summary>
    public class EquipmentAppearance
    {
        public int id;

        public List<EquipmentAppearancePair> showSlot = new List<EquipmentAppearancePair>();
        public List<AppearanceSlot> hideSlot = new List<AppearanceSlot>();

        public EquipmentAppearance(int id)
        {
            this.id = id;
        }

        public void ApplyAppearance(CharacterAppearance appearance)
        {
            SetAppearance(appearance);
            appearance.CombineMeshs();
        }

        public virtual void Removeppearance(CharacterAppearance appearance) { }
        public virtual void SetAppearance(CharacterAppearance appearance) { }



    }

    public class EquipmentAppearancePair
    {
        public AppearanceSlot slot;
        public int id;

        public EquipmentAppearancePair(AppearanceSlot slot, int id)
        {
            this.slot = slot;
            this.id = id;
        }
    }



}