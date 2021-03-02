/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/Builder/BindingBuilderBase.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 10:40:23 AM
	Tip:3/2/2021 10:40:23 AM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame.Binding.Paths;

namespace GFrame
{
    public class BindingBuilderBase : IBindingBuilder
    {
        private bool builded = false;
        private IBindingContext context;
        private object target;
        protected BindingDescription description;

        private IPathParser pathParser;
        protected IPathParser PathParser { get { return this.pathParser ?? (this.pathParser = new PathParser()); } }

        public BindingBuilderBase(IBindingContext context, object target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (context == null)
                throw new ArgumentNullException("context");

            this.context = context;
            this.target = target;

            this.description = new BindingDescription();
        }

        protected void SetMemberPath(string pathText)
        {
            Path path = this.PathParser.Parse(pathText);
            this.SetMemberPath(path);
        }

        protected void SetMemberPath(Path path)
        {
            if (path == null)
                throw new ArgumentException("the path is null");

            // this.description.
        }

        public void Build()
        {
            try
            {
                if (this.builded)
                    return;
                this.context.Add(this.target, this.description);
                this.builded = true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}