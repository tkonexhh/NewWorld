/************************
	FileName:/Scripts/Game/Entity/Base/Component/EntityMonoComponennt.cs
	CreateAuthor:neo.xu
	CreateTime:10/21/2020 5:12:21 PM
	Tip:10/21/2020 5:12:21 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EntityMonoComponennt : MonoBehaviour, IEntityComponennt
    {
        protected Entity m_Owwner;
        public virtual void Init(Entity ownner)
        {
            m_Owwner = ownner;
        }

        #region override funcs
        public virtual void Start() { }
        public virtual void Excute(float dt) { }
        public virtual void FixedExcute(float dt) { }
        public virtual void Destroy() { }

        #endregion
    }

}