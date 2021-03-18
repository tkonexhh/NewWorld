/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Targets/ITargetProxyFactory.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 3:20:53 PM
	Tip:3/3/2021 3:20:53 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface ITargetProxyFactory
    {
        ITargetProxy CreateProxy(object target, BindingDescription description);
    }

}