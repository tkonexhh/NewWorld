/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Path/PathParser.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 1:58:35 PM
	Tip:3/2/2021 1:58:35 PM
************************/

using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Binding.Paths
{
    public class PathParser : IPathParser
    {
        public Path Parse(LambdaExpression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            Path path = new Path();
            var body = expression.Body as MemberExpression;
            if (body != null)
            {
                this.Parse(body, path);
                return path;
            }
            throw new ArgumentException(string.Format("Invalid expression:{0}", expression));
        }
        public Path Parse(string pathText) { return null; }

        private MethodInfo GetDelegateMethodInfo(MethodCallExpression expression)
        {
            var target = expression.Object;
            var arguments = expression.Arguments;
            if (target == null)
            {
                foreach (var expr in arguments)
                {
                    if (!(expr is ConstantExpression))
                        continue;

                    var value = (expr as ConstantExpression).Value;
                    if (value is MethodInfo)
                        return (MethodInfo)value;
                }
                return null;
            }
            else if (target is ConstantExpression)
            {
                var value = (target as ConstantExpression).Value;
                if (value is MethodInfo)
                    return (MethodInfo)value;
            }
            return null;
        }


        private void Parse(Expression expression, Path path)
        {
            if (expression == null || !(expression is MemberExpression))
                return;
        }

        public string ParseMemberName(LambdaExpression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var method = expression.Body as MethodCallExpression;
            if (method != null)
                return method.Method.Name;

            //Delegate.CreateDelegate(Type type, object firstArgument, MethodInfo method)
            var unary = expression.Body as UnaryExpression;
            if (unary != null && unary.NodeType == ExpressionType.Convert)
            {
                MethodCallExpression methodCall = (MethodCallExpression)unary.Operand;
                if (methodCall.Method.Name.Equals("CreateDelegate"))
                {
                    var info = this.GetDelegateMethodInfo(methodCall);
                    if (info != null)
                        return info.Name;
                }

                throw new ArgumentException(string.Format("Invalid expression:{0}", expression));
            }

            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException(string.Format("Invalid expression:{0}", expression));

            if (!(body.Expression is ParameterExpression))
                throw new ArgumentException(string.Format("Invalid expression:{0}", expression));

            return body.Member.Name;
        }
    }

}