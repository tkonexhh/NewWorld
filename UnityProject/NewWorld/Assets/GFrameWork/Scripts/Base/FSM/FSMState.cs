using UnityEngine;
using System.Collections;

namespace GFrame
{
    public class FSMState<T>
    {
        public virtual string stateName
        {
            get { return this.GetType().Name; }
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
