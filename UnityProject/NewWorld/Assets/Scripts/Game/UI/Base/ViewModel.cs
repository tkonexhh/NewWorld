using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logic
{
    public class ViewModel : IViewModel
    {
        // public delegate void ValueChangeHandler();
        // private ValueChangeHandler m_ValueChangedHandler;
        // public event ValueChangeHandler ValueChanged
        // {
        //     add { this.m_ValueChangedHandler += value; }
        //     remove { this.m_ValueChangedHandler -= value; }
        // }

        // protected virtual void ValueChange()
        // {

        // }

        // protected bool Set<T>(ref T field, T newValue)
        // {
        //     if (object.Equals(field, newValue))
        //         return false;
        //     var oldValue = field;
        //     field = newValue;
        //     ValueChange();
        //     return true;
        // }



        #region IDisposable Support
        ~ViewModel()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }


    public class BindableProperty<T>
    {
        public delegate void ValueChangedHandler(T oldValue, T newValue);

        public ValueChangedHandler OnValueChanged;

        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!object.Equals(_value, value))
                {
                    T old = _value;
                    _value = value;
                    ValueChanged(old, _value);
                }
            }
        }

        private void ValueChanged(T oldValue, T newValue)
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(oldValue, newValue);
            }
        }
    }
}


