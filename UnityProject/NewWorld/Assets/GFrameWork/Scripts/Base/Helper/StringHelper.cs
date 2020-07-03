/************************
	FileName:/GFrameWork/Scripts/Base/Helper/StringHelper.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 5:29:29 PM
	Tip:7/3/2020 5:29:29 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class StringHelper
    {
        public static string Concat(params string[] args)
        {
            string str = "";
            for (int i = 0; i < args.Length; i++)
            {
                str += args[i];
            }
            return str;
        }
    }

}