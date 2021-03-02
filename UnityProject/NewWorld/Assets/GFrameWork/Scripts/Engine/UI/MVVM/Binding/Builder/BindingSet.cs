/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Builder/BindingSetBase.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 5:21:16 PM
	Tip:3/1/2021 5:21:16 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class BindingSetBase : IBindingBuilder
    {
        protected IBindingContext context;
        protected readonly List<IBindingBuilder> builders = new List<IBindingBuilder>();

        public BindingSetBase(IBindingContext context)
        {
            this.context = context;
        }

        public virtual void Build()
        {
            foreach (var builder in this.builders)
            {
                try
                {
                    builder.Build();
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }

            this.builders.Clear();
        }
    }

    public class BindingSet<TTarget, TSource> : BindingSetBase where TTarget : class
    {
        private TTarget target;

        public BindingSet(IBindingContext context, TTarget target) : base(context)
        {
            this.target = target;
        }

        public virtual BindingBuilder<TTarget, TSource> Bind()
        {
            var builder = new BindingBuilder<TTarget, TSource>(this.context, this.target);
            this.builders.Add(builder);
            return builder;
        }

        public virtual BindingBuilder<TChildTarget, TSource> Bind<TChildTarget>(TChildTarget target) where TChildTarget : class
        {
            var builder = new BindingBuilder<TChildTarget, TSource>(context, target);
            this.builders.Add(builder);
            return builder;
        }
    }

}