//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using GFrame;

namespace Game.Logic
{
    public static partial class TDEquipmentTable
    {
        private static TDSqlMetaData m_MetaData = new TDSqlMetaData(TDEquipmentTable.OnAddRow, "Game", "Equipment");

        public static TDSqlMetaData metaData
        {
            get { return m_MetaData; }
        }

        private static Dictionary<long, TDEquipment> m_DataCache = new Dictionary<long, TDEquipment>();
        private static List<TDEquipment> m_DataList = new List<TDEquipment>();

        public static void OnAddRow(SqliteDataReader reader)
        {
            TDEquipment data = new TDEquipment();
            data.ReadRow(reader);
            OnAddData(data);
            data.Reset();
            CompleteRowAdd(data);
        }

        private static void OnAddData(TDEquipment memberInstance)
        {
            long key = memberInstance.ID;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDEquipmentTable Id already exists {0}", key));
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

        public static List<TDEquipment> dataList
        {
            get
            {
                return m_DataList;
            }
        }

        public static TDEquipment GetData(long key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDEquipment", key));
                return null;
            }
        }
    }
}//namespace LR