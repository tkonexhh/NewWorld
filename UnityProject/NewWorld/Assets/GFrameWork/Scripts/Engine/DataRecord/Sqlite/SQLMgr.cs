/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/Sqlite/SqlManager.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 4:44:53 PM
	Tip:7/3/2020 4:44:53 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GFrame
{

    public class SQLMgr : TSingleton<SQLMgr>
    {
        private Dictionary<string, SqliteDatabase> m_DatabaseMap = new Dictionary<string, SqliteDatabase>();

        public override void OnSingletonInit()
        {
        }

        // public void Init()
        // {
        //     var reader = m_Database.LoadTable("Item");
        //     while (reader.Read())
        //     {
        //         for (int i = 0; i < reader.FieldCount; i++)
        //         {
        //             Debug.Log(reader[i].ToString());
        //         }
        //     }
        // }

        public SqliteDatabase Open(string dbName)
        {
            SqliteDatabase database;
            if (!m_DatabaseMap.TryGetValue(dbName, out database))
            {
                database = new SqliteDatabase(dbName);
                m_DatabaseMap.Add(dbName, database);
            }

            return database;
        }

        public SqliteDatabase GetDatabase(string dbName)
        {
            SqliteDatabase database;
            if (m_DatabaseMap.TryGetValue(dbName, out database))
            {
                return database;
            }

            return null;
        }

        public void Close()
        {
            var enumerator = m_DatabaseMap.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.Close();
            }
            enumerator.Dispose();
        }
    }

}