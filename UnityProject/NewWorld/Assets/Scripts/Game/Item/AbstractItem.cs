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
        public long id;
        public int num;
        public float weight;//重量

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
        }


        public string GetName()
        {
            return Conf.name;
        }

    }

}