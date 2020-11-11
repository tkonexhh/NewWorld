/************************
	FileName:/Scripts/Game/Item/Equipment/Weapon/WeaponAppearance.cs
	CreateAuthor:neo.xu
	CreateTime:10/15/2020 10:46:47 AM
	Tip:10/15/2020 10:46:47 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class WeaponAppearance : EquipmentAppearance
    {
        protected WeaponModel m_WeaponModel;
        public WeaponModel weaponModel => m_WeaponModel;
        public Run<WeaponModel> onWeaponLoaded;
        protected virtual string weaponResName => "";
        private GameObject m_ObjWeapon;
        public WeaponAppearance(int id) : base(id)
        {

        }

        public override void SetAppearance(CharacterAppearance appearance)
        {
            AddressableResMgr.S.InstantiateAsync(weaponResName, weapon =>
            {
                m_ObjWeapon = weapon;
                m_ObjWeapon.transform.SetParent(appearance.weaponBackAttachment);
                m_ObjWeapon.transform.ResetLocal();

                m_WeaponModel = m_ObjWeapon.GetComponent<WeaponModel>();
                m_WeaponModel.Init();
                m_WeaponModel.AttachWeapon();

                if (onWeaponLoaded != null)
                {
                    onWeaponLoaded(m_WeaponModel);
                }
            });
        }
        public override void Removeppearance(CharacterAppearance appearance)
        {
            m_WeaponModel = null;
            AddressableResMgr.S.ReleaseInstance(m_ObjWeapon);
        }
    }

}