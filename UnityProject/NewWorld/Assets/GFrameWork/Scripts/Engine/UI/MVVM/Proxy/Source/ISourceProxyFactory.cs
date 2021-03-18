/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Source/ISourceProxyFactory.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 2:31:52 PM
	Tip:3/3/2021 2:31:52 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface ISourceProxyFactory
    {
        ISourceProxy CreateProxy(object source, SourceDescription description);
    }

}