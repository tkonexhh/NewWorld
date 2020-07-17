//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using GFrame;

namespace GameWish.Game
{
    public static partial class TDCharacterAppearanceTable
    {
        private static TDSqlMetaData m_MetaData = new TDSqlMetaData(TDCharacterAppearanceTable.OnAddRow, "Game", "CharacterAppearance");

        public static TDSqlMetaData metaData
        {
            get { return m_MetaData; }
        }

        private static Dictionary<long, TDCharacterAppearance> m_DataCache = new Dictionary<long, TDCharacterAppearance>();
        private static List<TDCharacterAppearance> m_DataList = new List<TDCharacterAppearance>();

        public static void OnAddRow(SqliteDataReader reader)
        {
            TDCharacterAppearance data = new TDCharacterAppearance();
            data.ReadRow(reader);
            OnAddData(data);
            CompleteRowAdd(data);
        }

        private static void OnAddData(TDCharacterAppearance memberInstance)
        {
            long key = memberInstance.ID;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDCharacterAppearanceTable Id already exists {0}", key));
            }
            else
            {
                m_DataCache.Add(key, memberInstance);
                m_DataList.Add(memberInstance);
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

        public static TDCharacterAppearance GetData(long key)
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
}//namespace LR