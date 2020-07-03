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
    public enum SqlType
    {
        Common,
    }
    public class SQLMgr : TSingleton<SQLMgr>
    {

        private Dictionary<SqlType, SqliteDatabase> sqlDatas = new Dictionary<SqlType, SqliteDatabase>();
        public override void OnSingletonInit()
        {
            //加载数据库
            sqlDatas.Clear();
            sqlDatas.Add(SqlType.Common, new SqliteDatabase("Demo"));
        }

        public void Init()
        {

        }
    }

}