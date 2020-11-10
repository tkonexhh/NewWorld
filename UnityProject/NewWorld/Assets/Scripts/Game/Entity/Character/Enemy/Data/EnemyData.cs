/************************
	FileName:/Scripts/Game/Entity/Enemy/EnemyData.cs
	CreateAuthor:neo.xu
	CreateTime:11/10/2020 10:46:10 AM
	Tip:11/10/2020 10:46:10 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class EnemyData : EntityData
    {
        private EnemyBaseData m_BaseData;
        private EnemyStatusData m_StatusData;


        public EnemyData(Entity owner) : base(owner)
        {
            m_BaseData = new EnemyBaseData();
            m_StatusData = new EnemyStatusData();
        }
    }

}