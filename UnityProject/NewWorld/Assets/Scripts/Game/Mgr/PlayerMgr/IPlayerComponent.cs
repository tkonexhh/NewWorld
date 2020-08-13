/************************
	FileName:/Scripts/Game/Player/IPlayerComponent.cs
	CreateAuthor:neo.xu
	CreateTime:8/13/2020 7:53:16 PM
	Tip:8/13/2020 7:53:16 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IPlayerComponent
    {
        void OnInit();
        void OnUpdate();
        void OnDestroyed();
    }

}