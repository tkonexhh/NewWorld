using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

namespace GFrame
{
    public class ReflectionHelper
    {
        public static Assembly GetAssembly()
        {
            Assembly[] AssbyCustmList = System.AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < AssbyCustmList.Length; i++)
            {
                string assbyName = AssbyCustmList[i].GetName().Name;
                if (assbyName == "Assembly-CSharp")
                {
                    return AssbyCustmList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 设置变量
        /// ReflectionHelper.BindMenber(typeof(GProgress), "m_ImgProgress", progress, progressImg);
        /// </summary>
        /// <param name="type">typeof(class)</param>
        /// <param name="attrName"></param>
        /// <param name="target">class</param>
        /// <param name="attr">new attr</param>
        public static void BindMenber(Type type, string attrName, object target, object attr)
        {
            type.InvokeMember(attrName,
                BindingFlags.SetField |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null, target,
                new object[] { attr }, null, null, null);
        }
    }

}