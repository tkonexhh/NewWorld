/************************
	FileName:/GFrameWork/Scripts/Engine/ResSystem/ResFactory.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 5:45:04 PM
	Tip:7/7/2020 5:45:04 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class ResFactory
    {
        public delegate IRes ResCreater(string name);

        public interface IResCreater
        {
            bool CheckResType(string name);
            IRes CreateRes(string name);
        }

        class ResCreaterWrap : IResCreater
        {
            private string m_Key;
            private ResCreater m_Creater;

            public ResCreaterWrap(string key, ResCreater creater)
            {
                m_Key = key;
                m_Creater = creater;
            }

            public bool CheckResType(string name)
            {
                return name.StartsWith(m_Key);
            }

            public IRes CreateRes(string name)
            {
                return m_Creater(name);

            }
        }


        private static List<IResCreater> s_CreatorList;
        static ResFactory()
        {
            Log.i("#Init[ResFactory]");
            s_CreatorList = new List<IResCreater>();

            RegisterResCreater(InternalRes.KEY, InternalRes.Allocate);
        }

        public static void RegisterResCreater(string key, ResCreater creater)
        {
            if (string.IsNullOrEmpty(key) || creater == null)
            {
                Log.e("#Register Invalid Res Creater");
                return;
            }

            RegisterResCreater(new ResCreaterWrap(key, creater));
        }

        static void RegisterResCreater(IResCreater creater)
        {
            if (creater == null)
            {
                Log.e("#Register Invalid Res Creater");
                return;
            }

            s_CreatorList.Add(creater);
        }

        public static IRes Create(string name)
        {
            for (int i = 0; i < s_CreatorList.Count; i++)
            {
                if (s_CreatorList[i].CheckResType(name))
                {
                    return s_CreatorList[i].CreateRes(name);
                }
            }
            Log.e("#Not Find ResCreate For Res:" + name);
            return null;
        }


    }

}