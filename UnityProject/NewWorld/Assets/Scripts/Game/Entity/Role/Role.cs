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
        private RoleAnimComponent m_RoleAnimComponent;


        public RoleAppearanceComponent appearanceComponent => m_AppearanceComponent;
        public RoleAnimComponent animComponent => m_RoleAnimComponent;

        public Role() : base()
        {
            m_Data = new RoleData(this);
            m_GameObject = new GameObject("Role");
            m_Transform = m_GameObject.transform;

            //某些组件依赖此物体,需要等加载完成后才能添加组件
            AddressableResMgr.S.InstantiateAsync("ModularCharacters_Male", (target) =>
            {
                target.transform.SetParent(m_GameObject.transform);
                target.transform.localPosition = Vector3.zero;
                m_AppearanceComponent = AddComponent(new RoleAppearanceComponent());
                m_RoleAnimComponent = AddComponent(new RoleAnimComponent());

                Timer.S.Post2Scale(i =>
                {
                    m_AppearanceComponent.appearance.SetAppearance(AppearanceSlot.BackAttach, Random.Range(1, 10));
                }, 2.0f, 30);
            });

            m_RoleEquipComponent = AddComponent(new RoleEquipComponent());
        }


        public void Equip(Equipment equipment)
        {
            //处理属性
            //处理外貌
            equipment.Equip(this);
        }

        public void UnEquip(Equipment equipment)
        {
            equipment.UnEquip(this);
        }


    }

}