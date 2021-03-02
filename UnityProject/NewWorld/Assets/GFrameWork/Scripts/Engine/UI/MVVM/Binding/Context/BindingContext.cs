/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Context/BindingContext.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 10:26:40 AM
	Tip:3/2/2021 10:26:40 AM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class BindingContext : IBindingContext
    {
        private readonly string DEFAULT_KEY = "_KEY_";
        private readonly Dictionary<object, List<IBinding>> bindings = new Dictionary<object, List<IBinding>>();

        private object owner;
        private object dataContext;
        private IBinder binder;

        private readonly object _lock = new object();
        private EventHandler dataContextChanged;
        public event EventHandler DataContextChanged
        {
            add { lock (_lock) { this.dataContextChanged += value; } }
            remove { lock (_lock) { this.dataContextChanged -= value; } }
        }

        public BindingContext(object owner, IBinder binder) : this(owner, binder, (object)null)
        {
        }

        public BindingContext(object owner, IBinder binder, object dataContext)
        {
            this.owner = owner;
            this.binder = binder;
            this.DataContext = dataContext;
        }

        public object Owner { get => this.owner; }
        public object DataContext
        {
            get => this.dataContext;
            set
            {
                if (this.dataContext == value)
                    return;
                this.dataContext = value;
                this.OnDataContextChanged();
                this.RaiseDataContextChanged();
            }
        }

        protected void RaiseDataContextChanged()
        {
            try
            {
                var handler = this.dataContextChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                Log.w(e);
            }
        }

        protected virtual void OnDataContextChanged()
        {
            try
            {
                foreach (var kv in this.bindings)
                {
                    foreach (var binding in kv.Value)
                    {
                        binding.DataContext = this.DataContext;
                    }
                }
            }
            catch (Exception e)
            {
                Log.w(e);
            }
        }

        protected List<IBinding> GetOrCreateList(object key)
        {
            if (key == null)
                key = DEFAULT_KEY;

            List<IBinding> list;
            if (this.bindings.TryGetValue(key, out list))
                return list;

            list = new List<IBinding>();
            this.bindings.Add(key, list);
            return list;
        }

        public void Add(IBinding binding, object key = null)
        {
            if (binding == null)
                return;

            List<IBinding> list = this.GetOrCreateList(key);
            binding.BindingContext = this;
            list.Add(binding);
        }

        public virtual void Add(IEnumerable<IBinding> bindings, object key = null)
        {
            if (bindings == null)
                return;

            List<IBinding> list = this.GetOrCreateList(key);
            foreach (IBinding binding in bindings)
            {
                binding.BindingContext = this;
                list.Add(binding);
            }
        }

        public void Add(object target, BindingDescription description, object key = null)
        {
            IBinding binding = this.binder.Bind(this, this.dataContext, target, description);
            this.Add(binding, key);
        }
        public void Add(object target, IEnumerable<BindingDescription> descriptions, object key = null)
        {
            IEnumerable<IBinding> bindings = this.binder.Bind(this, this.dataContext, target, descriptions);
            this.Add(bindings, key);
        }
        public void Clear(object key) { }
        public void Clear() { }


        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.Clear();
                    // this.owner = null;
                    // this.binder = null;
                }
                disposed = true;
            }
        }

        ~BindingContext()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}