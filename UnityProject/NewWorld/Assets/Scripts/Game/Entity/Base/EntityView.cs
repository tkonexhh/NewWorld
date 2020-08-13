/************************
	FileName:/Scripts/Game/Entity/EntityView.cs
	CreateAuthor:neo.xu
	CreateTime:8/7/2020 5:42:35 PM
	Tip:8/7/2020 5:42:35 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EntityView : MonoBehaviour
    {
        protected IEntityControl m_EntityControl = null;

        public virtual void Init(IEntityControl entityControl)
        {
            m_EntityControl = entityControl;
        }

        public virtual void OnUpdate(float dt)
        {

        }
    }

}