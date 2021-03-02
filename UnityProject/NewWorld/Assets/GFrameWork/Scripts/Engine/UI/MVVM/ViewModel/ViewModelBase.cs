/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/ViewModel/ViewModelBase.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 4:40:12 PM
	Tip:3/1/2021 4:40:12 PM
************************/

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class ViewModelBase : IViewModel
    {
        private readonly object _lock = new object();
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { lock (_lock) { this.propertyChanged += value; } }
            remove { lock (_lock) { this.propertyChanged -= value; } }
        }
        private PropertyChangedEventHandler propertyChanged;

        protected bool Set<T>(ref T field, T newValue, string propertyName)
        {
            if (object.Equals(field, newValue))
                return false;

            var oldValue = field;
            field = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected virtual void RaisePropertyChanged(string propertyName = null)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            try
            {
                if (propertyChanged != null)
                    propertyChanged(this, eventArgs);
            }
            catch (Exception e)
            {
                Log.w(e);
            }
        }
    }
}