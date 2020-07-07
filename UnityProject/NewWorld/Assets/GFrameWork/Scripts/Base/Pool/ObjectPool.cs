/************************
	FileName:/GFrameWork/Scripts/Base/Pool/ObjectPool.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 2:30:18 PM
	Tip:6/12/2020 2:30:18 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IPoolAble
    {

    }


    public class ObjectPool<T> : TSingleton<ObjectPool<T>> where T : IPoolAble
    {

    }

}