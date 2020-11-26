/************************
	FileName:/GFrameWork/Scripts/Base/Helper/MathHelper.cs
	CreateAuthor:neo.xu
	CreateTime:11/26/2020 2:17:25 PM
	Tip:11/26/2020 2:17:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public static class MathHelper
    {
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }

}