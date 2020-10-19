/************************
	FileName:/GFrameWork/Scripts/Base/Helper/Extensions/UnityComponentExtention.cs
	CreateAuthor:neo.xu
	CreateTime:10/19/2020 4:43:32 PM
	Tip:10/19/2020 4:43:32 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public static class UnityComponentExtention
    {
        /// <summary>
        /// get / add component to target GameObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this GameObject go) where T : Component
        {
            T comp = go.GetComponent<T>();
            if (comp == null)
            {
                comp = go.AddComponent<T>();
            }
            return comp;
        }
        /// <summary>
        /// get / add component to target Transform
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this Transform trans) where T : Component
        {
            return RequireComponent<T>(trans.gameObject);
        }

        /// <summary>
        /// get / add component to target GameObject, ref tips if is add
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="isAddNew"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this GameObject go, ref bool isAddNewComp) where T : Component
        {
            T comp = go.GetComponent<T>();
            if (isAddNewComp = (comp == null))
            {
                comp = go.AddComponent<T>();
            }
            return comp;
        }
        /// <summary>
        /// get / add component to target Transform
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this Transform trans, ref bool isAddNewComp) where T : Component
        {
            return RequireComponent<T>(trans.gameObject, ref isAddNewComp);
        }

    }

}