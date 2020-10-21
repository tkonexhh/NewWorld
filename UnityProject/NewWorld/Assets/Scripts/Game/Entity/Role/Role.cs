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
        protected GameObject m_RootGameObject;
        protected Transform m_RootTransform;
        protected GameObject m_RoleGameObject;
        protected Transform m_RoleTransform;
        protected RoleData m_Data;

        public GameObject gameObject => m_RootGameObject;
        public Transform transform => m_RootTransform;
        public GameObject roleGameObject => m_RoleGameObject;
        public Transform roleTransform => m_RoleTransform;
        public RoleData data => m_Data;

        protected RoleAppearanceComponent m_AppearanceComponent;
        protected RoleEquipComponent m_EquipComponent;
        protected RoleAnimComponent m_AnimComponent;
        protected RoleIKComponent m_IKComponent;
        protected RoleMonoReference m_MonoReference;


        public RoleAppearanceComponent appearanceComponent => m_AppearanceComponent;
        public RoleEquipComponent equipComponent => m_EquipComponent;
        public RoleAnimComponent animComponent => m_AnimComponent;
        public RoleIKComponent iKComponent => m_IKComponent;
        public RoleMonoReference monoReference => m_MonoReference;


        public delegate void OnRoleCreated(Role role);
        public OnRoleCreated onRoleCreated;

        protected virtual string resName => "ModularCharacters_Male";
        public Role() : base()
        {
            m_Data = new RoleData(this);
            m_RootGameObject = new GameObject();
            m_RootTransform = m_RootGameObject.transform;
            //某些组件依赖此物体,需要等加载完成后才能添加组件
            AddressableResMgr.S.InstantiateAsync(resName, (target) =>
            {
                // target.name = "Player";
                m_RoleGameObject = target;
                m_RoleTransform = m_RoleGameObject.transform;
                m_RoleTransform.transform.SetParent(m_RootGameObject.transform);
                target.transform.localPosition = Vector3.zero;

                m_MonoReference = target.GetComponent<RoleMonoReference>();

                m_AppearanceComponent = AddComponent(new RoleAppearanceComponent());
                m_EquipComponent = AddComponent(new RoleEquipComponent());
                m_AnimComponent = AddComponent(new RoleAnimComponent());
                m_IKComponent = AddComponent(new RoleIKComponent());
                AddComponent(new RoleTestComponent());

                m_AppearanceComponent.appearance.SetAppearanceData(m_Data.appearanceData);
                OnResLoaded(target);

                if (onRoleCreated != null)
                {
                    onRoleCreated(this);
                }

            });
            EntityMgr.S.RegisterEntity(this);

        }

        protected virtual void OnResLoaded(GameObject obj)
        {
        }

        public void SetFocus(Transform focus)
        {
            m_IKComponent.SetFocusTarget(focus);
        }


    }

}