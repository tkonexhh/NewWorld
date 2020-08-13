/************************
	FileName:/Scripts/Game/Entity/EnntityComponennt.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:16:52 PM
	Tip:8/8/2020 9:16:52 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EntityComponennt
    {
        protected Entity m_Owwner;
        public virtual void Init(Entity ownner)
        {
            m_Owwner = ownner;
        }

        #region override funcs
        public virtual void Start()
        {

        }
        #endregion
    }

}