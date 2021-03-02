/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Builder/BindingBuilder.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 10:36:50 AM
	Tip:3/2/2021 10:36:50 AM
************************/

using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class BindingBuilder<TTarget, TSource> : BindingBuilderBase where TTarget : class
    {
        public BindingBuilder(IBindingContext context, TTarget target) : base(context, target)
        {
        }

        public BindingBuilder<TTarget, TSource> For(string targetName)
        {
            this.description.TargetName = targetName;
            this.description.UpdateTrigger = null;
            return this;
        }

        public BindingBuilder<TTarget, TSource> For(string targetName, string updateTrigger)
        {
            this.description.TargetName = targetName;
            this.description.UpdateTrigger = updateTrigger;
            return this;
        }

        public BindingBuilder<TTarget, TSource> For<TResult>(Expression<Func<TTarget, TResult>> memberExpression)
        {
            string targetName = this.PathParser.ParseMemberName(memberExpression);
            this.description.TargetName = targetName;
            this.description.UpdateTrigger = null;
            return this;
        }

        public BindingBuilder<TTarget, TSource> For<TResult, TEvent>(Expression<Func<TTarget, TResult>> memberExpression, Expression<Func<TTarget, TEvent>> updateTriggerExpression)
        {
            string targetName = this.PathParser.ParseMemberName(memberExpression);
            string updateTrigger = this.PathParser.ParseMemberName(updateTriggerExpression);
            this.description.TargetName = targetName;
            this.description.UpdateTrigger = updateTrigger;
            return this;
        }


        public BindingBuilder<TTarget, TSource> To(string path)
        {
            this.SetMemberPath(path);
            return this;
        }

        public BindingBuilder<TTarget, TSource> To()
        {
            return this;
        }

        public BindingBuilder<TTarget, TSource> To<TResult>(Expression<Func<TSource, TResult>> path)
        {
            this.SetMemberPath(this.PathParser.Parse(path));
            return this;
        }

        public BindingBuilder<TTarget, TSource> To<TParameter>(Expression<Func<TSource, Action<TParameter>>> path)
        {
            this.SetMemberPath(this.PathParser.Parse(path));
            return this;
        }
    }

}