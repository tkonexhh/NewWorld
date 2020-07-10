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
    public partial class TDCharacterAppearanceTable
    {
        private static Dictionary<long, TDCharacterAppearance> m_DataCache = new Dictionary<long, TDCharacterAppearance>();
        private static List<TDCharacterAppearance> m_DataList = new List<TDCharacterAppearance>();

        private static List<TDCharacterAppearance> m_HairDataList = new List<TDCharacterAppearance>();
        private static Dictionary<long, TDCharacterAppearance> m_HairDataCache = new Dictionary<long, TDCharacterAppearance>();
        private static List<TDCharacterAppearance> m_HeadDataList = new List<TDCharacterAppearance>();
        private static Dictionary<long, TDCharacterAppearance> m_HeadDataCache = new Dictionary<long, TDCharacterAppearance>();

        public static void Parse(SqliteDataReader reader)
        {
            // m_DataCache.Clear();
            // m_DataList.Clear();

            // m_HairDataList.Clear();
            // m_HairDataCache.Clear();

            TDCharacterAppearance data = new TDCharacterAppearance();
            data.id = (long)reader[0];
            data.sex = GetSexType((long)reader[1]);

            data.part = CharacterEnumHelper.GetSlotByName((string)reader[2]);
            if (reader[3] != null)
                data.appearance = (long)reader[3];
            data.name = reader[4].ToString();

            m_DataList.Add(data);
            m_DataCache.Add(data.id, data);

            switch (data.part)
            {
                case AppearanceSlot.Hair:
                    {
                        m_HairDataCache.Add(m_HairDataList.Count, data);
                        m_HairDataList.Add(data);
                        break;
                    }
                case AppearanceSlot.Head:
                    {
                        m_HairDataCache.Add(m_HairDataList.Count, data);
                        m_HeadDataList.Add(data);
                        break;
                    }
            }
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

    public partial class TDCharacterAppearanceTable
    {
        public static SexType GetSexType(long sex)
        {
            switch (sex)
            {
                case 1:
                    return SexType.Male;
                case 2:
                    return SexType.Female;
                default:
                    return SexType.General;
            }
        }
        public static int GetAppearanceCount(AppearanceSlot slot, Sex sex)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return m_HairDataList.Count;
            }
            return 0;
        }

        public static TDCharacterAppearance GetAppearanceByIndex(AppearanceSlot slot, Sex sex, int index)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return m_HairDataList[index];
            }
            return null;
        }
    }

}