/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/INotifiable.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 2:57:26 PM
	Tip:3/3/2021 2:57:26 PM
************************/


using System;


namespace GFrame
{
    public interface INotifiable
    {
        event EventHandler ValueChanged;
    }

}