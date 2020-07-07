/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/Sqlite/SqliteDatabase.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 8:34:16 PM
	Tip:7/2/2020 8:34:16 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

namespace GFrame
{
    public class SqliteDatabase
    {
        private SqliteConnection m_SqlConnection;
        private SqliteCommand m_SqlCommand;
        private SqliteDataReader m_SqlDataReader;

        //private Dictionary<string, SqliteDataTable> m_Tables = new Dictionary<string, SqliteDataTable>();
        public SqliteDatabase(string dbName)
        {
            try
            {
                m_SqlConnection = new SqliteConnection(GetDataPath() + dbName + ".db");
                m_SqlConnection.Open();
            }
            catch (System.Exception e)
            {
                Log.e(e.ToString());
            }
        }

        public void Close()
        {
            if (m_SqlCommand != null)
            {
                m_SqlCommand.Dispose();
                m_SqlCommand = null;
            }

            if (m_SqlDataReader != null)
            {
                m_SqlDataReader.Dispose();
                m_SqlDataReader = null;
            }

            if (m_SqlConnection != null)
            {
                m_SqlConnection.Close();
                m_SqlConnection = null;
            }
        }

        public SqliteDataReader ExecuteQuery(string sql)
        {
            m_SqlCommand = m_SqlConnection.CreateCommand();
            m_SqlCommand.CommandText = sql;
            m_SqlDataReader = m_SqlCommand.ExecuteReader();
            return m_SqlDataReader;

        }

        public SqliteDataReader LoadTable(string tableName)
        {
            // m_SqlCommand.
            string sql = "SELECT * FROM " + tableName;
            return ExecuteQuery(sql);
        }

        public SqliteDataReader LoadTable(string tableName, string selectkey, string selectvalue)
        {
            string query = "SELECT * FROM " + tableName + " where " + selectkey + " = " + selectvalue + " ";
            return ExecuteQuery(query);
        }

        public void CreateTable()
        {

        }




        public string GetDataPath()
        {
            return StringHelper.Concat("data source=", Application.dataPath, "/", ProjectPathConfig.DataBasePath);
        }
    }

}