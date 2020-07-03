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


        public SqliteDatabase(string dbName)
        {
            try
            {
                Debug.LogError(GetDataPath() + "/" + dbName);
                m_SqlConnection = new SqliteConnection(GetDataPath() + "/" + dbName);
                m_SqlConnection.Open();
                m_SqlCommand = m_SqlConnection.CreateCommand();
            }
            catch (System.Exception e)
            {
                Log.e(e.ToString());
            }
        }

        void Open()
        {

        }

        public void Close()
        {
            if (m_SqlCommand != null)
            {
                m_SqlCommand.Dispose();
                m_SqlCommand = null;
            }


            if (m_SqlConnection != null)
            {
                m_SqlConnection.Close();
                m_SqlConnection = null;
            }
        }

        public string GetDataPath()
        {
            return StringHelper.Concat("data source=", Application.dataPath, ProjectPathConfig.DBPath);
        }
    }

}