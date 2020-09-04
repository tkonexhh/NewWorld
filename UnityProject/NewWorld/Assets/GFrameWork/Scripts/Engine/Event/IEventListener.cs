/************************
	FileName:/GFrameWork/Scripts/Engine/Event/IEventListener.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 3:41:08 PM
	Tip:6/23/2020 3:41:08 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IEventListener
    {
        void RegisterEvent();
        void UnRegisterEvent();
        void HandleEvent(int key, params object[] args);
    }



}