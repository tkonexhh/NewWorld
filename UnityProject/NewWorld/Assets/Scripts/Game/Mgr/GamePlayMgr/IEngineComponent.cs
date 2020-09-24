/************************
	FileName:/Scripts/Game/GamePlay/IengineComponent.cs
	CreateAuthor:neo.xu
	CreateTime:8/13/2020 7:46:46 PM
	Tip:8/13/2020 7:46:46 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IEngineComponent
    {

        void Start();
        void Update(float dt);
    }

}