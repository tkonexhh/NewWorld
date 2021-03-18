/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/BehaviourBindingExtension.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 10:57:08 AM
	Tip:3/2/2021 10:57:08 AM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public static class BehaviourBindingExtension
    {
        private static IBinder binder;
        public static IBinder Binder
        {
            get
            {
                if (binder == null)
                {
                    SourceProxyFactory sourceFactory = new SourceProxyFactory();
                    TargetProxyFactory targetFactory = new TargetProxyFactory();
                    BindingFactory bindingFactory = new BindingFactory(sourceFactory, targetFactory);//BindingFactory(sourceFactory, targetFactory);
                    binder = new BinderBase(bindingFactory);
                }

                if (binder == null)
                    throw new Exception("Data binding service is not initialized,please create a BindingServiceBundle service before using it.");

                return binder;
            }
        }

        public static IBindingContext BindingContext(this Behaviour behaviour)
        {
            if (behaviour == null || behaviour.gameObject == null)
                return null;

            BindingContextLifecycle bindingContextLifecycle = behaviour.GetComponent<BindingContextLifecycle>();
            if (bindingContextLifecycle == null)
                bindingContextLifecycle = behaviour.gameObject.AddComponent<BindingContextLifecycle>();

            IBindingContext bindingContext = bindingContextLifecycle.BindingContext;
            if (bindingContext == null)
            {
                bindingContext = new BindingContext(behaviour, Binder);
                bindingContextLifecycle.BindingContext = bindingContext;
            }
            return bindingContext;
        }

        public static BindingSet<TBehaviour, TSource> CreateBindingSet<TBehaviour, TSource>(this TBehaviour behaviour) where TBehaviour : Behaviour
        {
            IBindingContext context = behaviour.BindingContext();
            return new BindingSet<TBehaviour, TSource>(context, behaviour);
        }

        public static BindingSet<TBehaviour, TSource> CreateBindingSet<TBehaviour, TSource>(this TBehaviour behaviour, TSource dataContext) where TBehaviour : Behaviour
        {
            IBindingContext context = behaviour.BindingContext();
            context.DataContext = dataContext;
            return new BindingSet<TBehaviour, TSource>(context, behaviour);
        }
    }

}