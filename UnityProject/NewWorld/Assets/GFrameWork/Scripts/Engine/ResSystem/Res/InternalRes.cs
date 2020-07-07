/************************
	FileName:/GFrameWork/Scripts/Engine/ResSystem/Res/InternalRes.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 5:38:08 PM
	Tip:7/7/2020 5:38:08 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class InternalRes : BaseRes
    {
        public const string KEY = "Resources/";

        public static string Name2Path(string name)
        {
            return name.Substring(KEY.Length);
        }

        public static InternalRes Allocate(string name)
        {
            InternalRes res = new InternalRes();
            if (res != null)
            {
                res.name = name;
                res.Load();
            }
            return res;
        }

        public override bool Load()
        {
            asset = Resources.Load(Name2Path(name));

            if (asset != null)
            {
                return true;
            }
            Log.e("#Failed To Load:" + name);
            return false;
        }

    }

}