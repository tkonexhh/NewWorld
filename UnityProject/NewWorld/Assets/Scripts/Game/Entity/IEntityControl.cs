/************************
	FileName:/Scripts/Game/Entity/IEntityControl.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:42:23 PM
	Tip:8/7/2020 5:42:23 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IEntityControl
    {
        void OnInit();
        void OnUpdate(float dt);
    }

}