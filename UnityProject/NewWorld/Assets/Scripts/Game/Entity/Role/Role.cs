/************************
	FileName:/Scripts/Game/Character/Character.cs
	CreateAuthor:neo.xu
	CreateTime:6/16/2020 8:24:27 PM
	Tip:6/16/2020 8:24:27 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    [RequireComponent(typeof(CharacterAppearance))]
    public partial class Role : Entity
    {
        protected GameObject m_GameObject;
        protected Transform m_Transform;
        protected RoleData m_Data;

        public GameObject gameObject => m_GameObject;
        public Transform transform => m_Transform;
        public RoleData data => m_Data;

        private RoleAppearanceComponent m_AppearanceComponent;
        private RoleEquipComponent m_RoleEquipComponent;
        private RoleAnimComponent m_AnimComponent;
        private RoleIKComponent m_IKComponent;
        private RoleMonoReference m_MonoReference;


        public RoleAppearanceComponent appearanceComponent => m_AppearanceComponent;
        public RoleAnimComponent animComponent => m_AnimComponent;
        public RoleIKComponent iKComponent => m_IKComponent;
        public RoleMonoReference monoReference => m_MonoReference;


        public delegate void OnRoleCreated(Role role);
        public OnRoleCreated onRoleCreated;

        protected virtual string resName => "ModularCharacters_Male";
        public Role() : base()
        {
            m_Data = new RoleData(this);

            //某些组件依赖此物体,需要等加载完成后才能添加组件
            AddressableResMgr.S.InstantiateAsync(resName, (target) =>
            {
                // target.name = "Player";
                m_GameObject = target;
                m_Transform = m_GameObject.transform;
                target.transform.localPosition = Vector3.zero;

                m_MonoReference = target.GetComponent<RoleMonoReference>();
                m_AppearanceComponent = AddComponent(new RoleAppearanceComponent());
                m_AnimComponent = AddComponent(new RoleAnimComponent());
                m_IKComponent = AddComponent(new RoleIKComponent());

                m_AppearanceComponent.appearance.SetAppearanceData(m_Data.appearanceData);
                OnResLoaded(target);

                if (onRoleCreated != null)
                {
                    onRoleCreated(this);
                }

            });
            EntityMgr.S.RegisterEntity(this);
            m_RoleEquipComponent = AddComponent(new RoleEquipComponent());
        }

        protected virtual void OnResLoaded(GameObject obj)
        {
        }

        protected void ApplyEquipment()
        {
            var helmet = new Equipment_Helmet(m_Data.equipmentData.helmetID);
            var torso = new Equipment_Torso(m_Data.equipmentData.torsoID);
            var hands = new Equipment_Hands(m_Data.equipmentData.handsID);
            var legs = new Equipment_Legs(m_Data.equipmentData.legsID);
            var hips = new Equipment_Hips(m_Data.equipmentData.hipsID);
            var shoulders = new Equipment_Shoulders(m_Data.equipmentData.shouldersID);
            var back = new Equipment_Back(m_Data.equipmentData.backID);
            Equip(helmet);
            Equip(torso);
            Equip(hands);
            Equip(legs);
            Equip(hips);
            Equip(shoulders);
            Equip(back);
        }

        public void Equip(Equipment equipment)
        {
            //处理属性
            //处理外貌
            equipment.Equip(this);
            m_Data.equipmentData.SetData(equipment.equipmentType, (int)equipment.id);
        }

        public void UnEquip(Equipment equipment)
        {
            equipment.UnEquip(this);
            m_Data.equipmentData.SetData(equipment.equipmentType, -1);
        }

        public void SetFocus(Transform focus)
        {
            m_IKComponent.SetFocusTarget(focus);
        }


    }

}