/************************
	FileName:/Scripts/Game/Item/AbstractItem.cs
	CreateAuthor:neo.xu
	CreateTime:7/15/2020 3:49:52 PM
	Tip:7/15/2020 3:49:52 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public abstract class AbstractItem
    {
        public virtual ItemType type
        {
            get { return ItemType.Other; }
        }
        public long id { get; private set; }
        public float weight { get; private set; }
        public string name { get; private set; }


        protected TDItem m_Conf;
        public TDItem Conf
        {
            get
            {
                if (m_Conf == null)
                {
                    m_Conf = TDItemTable.GetData(id);
                }
                return m_Conf;
            }
            set
            {
                m_Conf = value;
            }
        }

        public AbstractItem(long id)
        {
            this.id = id;
            name = Conf.Name;
        }


    }

}