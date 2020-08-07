/************************
	FileName:/Scripts/Game/Entity/EntityModel.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:41:37 PM
	Tip:8/7/2020 5:41:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class EntityModel
    {
        protected IEntityControl m_EntityControl = null;
        public virtual void Init(IEntityControl entityControl)
        {
            m_EntityControl = entityControl;
        }
    }

}