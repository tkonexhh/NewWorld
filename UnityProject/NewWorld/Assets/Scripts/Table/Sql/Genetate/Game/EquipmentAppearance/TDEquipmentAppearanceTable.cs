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
    public static partial class TDEquipmentAppearanceTable
    {
        private static TDSqlMetaData m_MetaData = new TDSqlMetaData(TDEquipmentAppearanceTable.OnAddRow, "Game", "EquipmentAppearance");

        public static TDSqlMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<long, TDEquipmentAppearance> m_DataCache = new Dictionary<long, TDEquipmentAppearance>();
        private static List<TDEquipmentAppearance> m_DataList = new List<TDEquipmentAppearance >();
        
        public static void OnAddRow(SqliteDataReader reader)
        {
            TDEquipmentAppearance data = new TDEquipmentAppearance();
            data.ReadRow(reader);
            OnAddData(data);
            data.Reset();
            CompleteRowAdd(data);
        }

        private static void OnAddData(TDEquipmentAppearance memberInstance)
        {
            long key = memberInstance.ID;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDEquipmentAppearanceTable Id already exists {0}", key));
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

        public static List<TDEquipmentAppearance> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDEquipmentAppearance GetData(long key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDEquipmentAppearance", key));
                return null;
            }
        }
    }
}//namespace LR