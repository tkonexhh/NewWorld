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

    /// <summary>
    /// 枚举数据库Sqlite支持的几种类型
    /// </summary>
    public enum ColType
    {
        INTEGER,
        TEXT,
        REAL,
        BLOB
    }

    public class SQLMgr : TSingleton<SQLMgr>
    {
        private Dictionary<string, SqliteDatabase> m_DatabaseMap = new Dictionary<string, SqliteDatabase>();

        public override void OnSingletonInit()
        {
        }

        #region static
        public static ColType GetColType(string type)
        {
            switch (type)
            {
                case "INTEGER":
                    return ColType.INTEGER;
                case "TEXT":
                    return ColType.TEXT;
                case "REAL":
                    return ColType.REAL;
                case "BLOB":
                    return ColType.BLOB;
            }
            return ColType.TEXT;
        }

        public static System.Type GetType(string type)
        {
            switch (type)
            {
                case "INTEGER":
                    return typeof(long);
                case "TEXT":
                    return typeof(string);
                case "REAL":
                    return typeof(float);
                case "BLOB":
                    return typeof(byte[]);
            }
            return typeof(string);
        }

        public static string GetTypeStr(string type)
        {
            switch (type)
            {
                case "INTEGER":
                    return "long";
                case "TEXT":
                    return "string";
                case "REAL":
                    return "float";
                case "BLOB":
                    return "byte[]";
            }
            return "string";
        }

        #endregion

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