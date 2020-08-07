/************************
	FileName:/Scripts/Game/Entity/EntityControl.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:42:10 PM
	Tip:8/7/2020 5:42:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class EntityControl : IEntityControl
    {

        #region IEntityControl
        public virtual void OnInit() { }
        public virtual void OnUpdate(float dt) { }

        #endregion
    }

}