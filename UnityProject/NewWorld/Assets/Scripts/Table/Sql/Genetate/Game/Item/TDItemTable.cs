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
    public static partial class TDItemTable
    {
        private static TDSqlMetaData m_MetaData = new TDSqlMetaData(TDItemTable.OnAddRow, "Game", "Item");

        public static TDSqlMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<long, TDItem> m_DataCache = new Dictionary<long, TDItem>();
        private static List<TDItem> m_DataList = new List<TDItem >();
        
        public static void OnAddRow(SqliteDataReader reader)
        {
            TDItem data = new TDItem();
            data.ReadRow(reader);
            OnAddData(data);
            data.Reset();
            CompleteRowAdd(data);
        }

        private static void OnAddData(TDItem memberInstance)
        {
            long key = memberInstance.ID;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDItemTable Id already exists {0}", key));
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

        public static List<TDItem> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDItem GetData(long key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDItem", key));
                return null;
            }
        }
    }
}//namespace LR