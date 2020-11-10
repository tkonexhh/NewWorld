/************************
	FileName:/Scripts/Game/Entity/Enemy/Enemy.cs
	CreateAuthor:neo.xu
	CreateTime:11/10/2020 10:45:44 AM
	Tip:11/10/2020 10:45:44 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class Enemy : Entity
    {
        private EnemyData m_Data;


        public EnemyData data => m_Data;
        public Enemy() : base()
        {
            m_Data = new EnemyData(this);
            EntityMgr.S.RegisterEntity(this);
        }
    }

}