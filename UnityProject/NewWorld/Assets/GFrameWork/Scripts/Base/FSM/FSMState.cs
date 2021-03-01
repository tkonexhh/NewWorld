using UnityEngine;
using System.Collections;

namespace GFrame
{
    public class FSMState<T>
    {
        private bool m_HasInit = false;
        public virtual string stateName
        {
            get { return this.GetType().Name; }
        }

        public void DoEnter(T entity, params object[] args)
        {
            if (!m_HasInit)
            {
                m_HasInit = true;
                Init(entity);
            }

            Enter(entity, args);
        }


        public virtual void Init(T entity)
        {
        }

        public virtual void Enter(T entity, params object[] args)
        {
        }

        public virtual void Update(T entity, float dt)
        {

        }

        public virtual void FixedUpdate(T entity, float dt)
        {

        }

        public virtual void Exit(T entity)
        {
        }

        public virtual void OnMsg(T entity, int key, params object[] args)
        {

        }
    }

}
