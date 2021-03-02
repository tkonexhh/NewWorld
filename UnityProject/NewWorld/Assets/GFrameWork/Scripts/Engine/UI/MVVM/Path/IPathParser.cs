/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Path/IPathParser.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 1:57:04 PM
	Tip:3/2/2021 1:57:04 PM
************************/

using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Binding.Paths
{
    public interface IPathParser
    {
        Path Parse(LambdaExpression expression);
        Path Parse(string pathText);

        string ParseMemberName(LambdaExpression expression);
    }

}