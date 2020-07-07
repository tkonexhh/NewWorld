/************************
	FileName:/GFrameWork/Scripts/Engine/Component/AbstractModule.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 2:03:35 PM
	Tip:7/7/2020 2:03:35 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AbstractModule : MonoBehaviour
    {
        [SerializeField] private List<IAbstractComponent> m_ComponentLst = new List<IAbstractComponent>();
        private bool m_HasAwake = false;
        private bool m_HasStart = false;

        public void AddComponent(IAbstractComponent component)
        {
            if (component == null) return;
            if (m_ComponentLst.Contains(component))
            {
                Log.w("#Already Add Component:" + component.GetType().ToString());
                return;
            }
            m_ComponentLst.Add(component);

            if (m_HasAwake)
            {
                component.Awake();
            }

            if (m_HasStart)
            {
                component.Start();
            }
        }



        #region MonoBehaviour
        private void Awake()
        {
            OnModuleAwake();
            for (int i = 0; i < m_ComponentLst.Count; i++)
            {
                m_ComponentLst[i].Awake();
            }
            m_HasAwake = true;
        }

        private void Start()
        {
            OnModuleStart();
            for (int i = 0; i < m_ComponentLst.Count; i++)
            {
                m_ComponentLst[i].Start();
            }
            m_HasStart = true;
        }

        private void OnDestroy()
        {
            for (int i = 0; i < m_ComponentLst.Count; i++)
            {
                m_ComponentLst[i].Destory();
            }

            m_ComponentLst.Clear();

            OnModuleDestory();
        }
        #endregion



        protected virtual void OnModuleAwake() { }
        protected virtual void OnModuleStart() { }
        protected virtual void OnModuleDestory() { }
    }

}