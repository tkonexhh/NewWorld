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


namespace GameWish.Game
{
    [RequireComponent(typeof(CharacterAppearance))]
    public partial class Role : Entity
    {
        protected GameObject m_GameObject;
        protected RoleData m_Data;

        public GameObject gameObject { get => m_GameObject; }
        public RoleData data { get => m_Data; }

        [SerializeField] public CharacterAppearance appearance;

        public Role() : base()
        {
            m_Data = new RoleData(this);

            m_GameObject = new GameObject("Role");
            //TODO 加载物体
            //某些组件依赖此物体,需要等加载完成后才能添加组件
            AddressableResMgr.S.InstantiateAsync("ModularCharacters_Male", (target) =>
            {
                target.transform.SetParent(m_GameObject.transform);
                AddComponent(new RoleAppearanceComponent());
            });


            AddComponent(new RoleEquipComponent());
        }


        public void Equip(Equipment equipment)
        {
            //处理属性
            //处理外貌
            equipment.Equip(this);
        }

    }

}