/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Targets/ITargetProxy.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 3:20:32 PM
	Tip:3/3/2021 3:20:32 PM
************************/


using System;


namespace GFrame
{
    public interface ITargetProxy : IBindingProxy
    {
        Type Type { get; }
        TypeCode TypeCode { get; }
        object Target { get; }

    }

}