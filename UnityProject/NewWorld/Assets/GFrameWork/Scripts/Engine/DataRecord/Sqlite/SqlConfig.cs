/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/Sqlite/SqlConfig.cs
	CreateAuthor:neo.xu
	CreateTime:7/16/2020 3:06:36 PM
	Tip:7/16/2020 3:06:36 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class SqlConfig
    {

    }

    public class TDSqlMetaData
    {
        private OnSqlParse m_OnParse;
        public OnSqlParse onParse => m_OnParse;

        public string databaseName { get; set; }
        public string tableName { get; set; }
        public TDSqlMetaData(OnSqlParse onParse, string databaseName, string tableName)
        {
            m_OnParse = onParse;
            this.databaseName = databaseName;
            this.tableName = tableName;
        }
    }

}