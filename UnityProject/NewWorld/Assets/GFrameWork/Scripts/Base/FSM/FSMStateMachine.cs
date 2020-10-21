﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GFrame
{
    public class FSMStateMachine<T>
    {
        private T m_Entity;
        private FSMState<T> m_CurrentState;
        private FSMState<T> m_PreviousState;
        private FSMState<T> m_GlobalState;
        private FSMStateFactory<T> m_StateFactory;
        private bool m_IsRunning = true;
        #region 属性

        public FSMState<T> currentState => m_CurrentState;
        public FSMState<T> globalState => m_GlobalState;
        public FSMState<T> previousState => m_PreviousState;

        public FSMStateFactory<T> stateFactory
        {
            get { return m_StateFactory; }
            set { m_StateFactory = value; }
        }

        public bool isRunning
        {
            get { return m_IsRunning; }
            set { m_IsRunning = false; }
        }

        #endregion

        public FSMStateMachine(T entity)
        {
            m_Entity = entity;
            m_CurrentState = m_PreviousState = m_GlobalState = null;
        }

        public void ResetStateMachine(T entity, FSMStateFactory<T> factory)
        {
            m_Entity = entity;
            m_StateFactory = factory;
            m_CurrentState = m_PreviousState = m_GlobalState = null;
        }

        #region 状态控制

        public void SetGlobalStateByID<K>(K key, params object[] args) where K : IConvertible
        {
            FSMState<T> state = GetStateFromFactory(key, false);
            if (state == null)
            {
                return;
            }
            SetGlobalState(state, args);
        }

        public void SetGlobalState(FSMState<T> state, params object[] args)
        {
            if (m_GlobalState != null)
            {
                m_GlobalState.Exit(m_Entity);
            }

            m_GlobalState = state;

            if (m_GlobalState != null)
            {
                m_GlobalState.Enter(m_Entity, args);
            }

            //#if UNITY_EDITOR
            OnGlobalStateChange();
            //#endif
        }

        public void UpdateState(float dt)
        {
            if (!m_IsRunning)
            {
                return;
            }

            if (m_GlobalState != null)
            {
                m_GlobalState.Update(m_Entity, dt);
            }

            if (m_CurrentState != null)
            {
                m_CurrentState.Update(m_Entity, dt);
            }
        }

        public void FixedUpdateState(float dt)
        {
            if (!m_IsRunning)
            {
                return;
            }

            if (m_GlobalState != null)
            {
                m_GlobalState.FixedUpdate(m_Entity, dt);
            }

            if (m_CurrentState != null)
            {
                m_CurrentState.FixedUpdate(m_Entity, dt);
            }
        }

        public void SetCurrentStateByID<K>(K key, params object[] args) where K : IConvertible
        {
            FSMState<T> state = GetStateFromFactory(key, false);
            if (state == null)
            {
                Log.w("Not Find State By ID:" + key);
                return;
            }
            SetCurrentState(state, args);
        }

        public void SetCurrentState(FSMState<T> state, params object[] args)
        {
            if (state == m_CurrentState)
            {
                Log.i("Change To SameState!");
                return;
            }

            if (m_CurrentState != null)
            {
                m_CurrentState.Exit(m_Entity);
                m_PreviousState = m_CurrentState;
            }

            m_CurrentState = state;

#if UNITY_EDITOR
            if (m_CurrentState != null)
            {
                if (m_PreviousState == null)
                {
                    Log.i("State:{0}", m_CurrentState.stateName);
                }
                else
                {
                    Log.i("State:{0}->{1}", m_PreviousState.stateName, m_CurrentState.stateName);
                }
            }
#endif

            if (m_CurrentState != null)
            {
                m_CurrentState.Enter(m_Entity, args);
            }

            //#if UNITY_EDITOR
            OnCurrentStateChange();
            OnPreviousStateChange();
            //#endif
        }

        public void RevertToPreviousState()
        {
            SetCurrentState(m_PreviousState);
        }

        #endregion

        public virtual void SendMsg(int key, params object[] args)
        {

        }

        #region 子类实现接口方便实时监控 [PS:泛型类不好直接序列化显示在监视面板]
        protected virtual void OnGlobalStateChange()
        {

        }

        protected virtual void OnCurrentStateChange()
        {

        }

        protected virtual void OnPreviousStateChange()
        {

        }

        #endregion

        private FSMState<T> GetStateFromFactory<K>(K key, bool forceCreate) where K : IConvertible
        {
            if (m_StateFactory == null)
            {
                return null;
            }

            FSMState<T> state = m_StateFactory.GetState(key, forceCreate);
            return state;
        }
    }
}































