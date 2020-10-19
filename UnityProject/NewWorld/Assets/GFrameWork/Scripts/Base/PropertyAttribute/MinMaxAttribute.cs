/************************
	FileName:/GFrameWork/Scripts/Base/PropertyAttribute/MinMax.cs
	CreateAuthor:neo.xu
	CreateTime:10/19/2020 4:58:58 PM
	Tip:10/19/2020 4:58:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{
    public class MinMaxAttribute : PropertyAttribute
    {
        public float minLimit = 0;
        public float maxLimit = 1;

        public MinMaxAttribute(int min, int max)
        {
            minLimit = min;
            maxLimit = max;
        }
    }
}