/************************
	FileName:/Scripts/Table/Sql/Game/CharacterAppearance/TDCharacterAppearanceTable.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 11:09:35 AM
	Tip:7/7/2020 11:09:35 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using Mono.Data.Sqlite;

namespace GameWish.Game
{
    public class TDCharacterAppearanceTable
    {
        private static Dictionary<int, TDCharacterAppearance> m_DataCache = new Dictionary<int, TDCharacterAppearance>();
        private static List<TDCharacterAppearance> m_DataList = new List<TDCharacterAppearance>();

        public static void Parse(SqliteDataReader reader)
        {
            m_DataCache.Clear();
            m_DataList.Clear();

            TDCharacterAppearance data = new TDCharacterAppearance();
            data.id = (int)reader[0];
            data.sex = (int)reader[1];
            data.part = CharacterEnumHelper.GetSlotByName(reader[2].ToString());
            data.appearance = (int)reader[3];
            data.name = reader[4].ToString();

            m_DataList.Add(data);
            m_DataCache.Add(data.id, data);
        }

        public static int count
        {
            get
            {
                return m_DataCache.Count;
            }
        }

        public static List<TDCharacterAppearance> dataList
        {
            get
            {
                return m_DataList;
            }
        }

        public static TDCharacterAppearance GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDCharacterAppearance", key));
                return null;
            }
        }
    }

}