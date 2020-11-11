/************************
	FileName:/GFrameWork/Scripts/Engine/Define/DelegleteDefine.cs
	CreateAuthor:neo.xu
	CreateTime:7/16/2020 3:08:59 PM
	Tip:7/16/2020 3:08:59 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

namespace GFrame
{

    public delegate void OnSqlParse(SqliteDataReader reader);
    public delegate void Run<T>(T v);
    public delegate void Run();

}