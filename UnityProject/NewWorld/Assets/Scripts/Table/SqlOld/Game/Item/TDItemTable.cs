/************************
	FileName:/Scripts/Table/Sql/Game/Item/TDItemTable.cs
	CreateAuthor:neo.xu
	CreateTime:7/15/2020 4:00:31 PM
	Tip:7/15/2020 4:00:31 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using GFrame;

namespace GameWish.Game
{
    public partial class TDItemTable
    {
        private static Dictionary<long, TDItem> s_ItemMap = new Dictionary<long, TDItem>();

        public static void Parse(SqliteDataReader reader)
        {
            TDItem data = new TDItem();
            data.id = (long)reader[0];
            data.subId = (long)reader[1];
            data.name = (string)reader[2];
            data.type = (string)reader[3];
            data.iconName = (string)reader[4];

            if (reader[5] != null)
            {
                data.weight = (float)reader[5];
            }
            s_ItemMap.Add(data.id, data);
        }

        public static TDItem GetData(long id)
        {
            TDItem item = null;
            if (s_ItemMap.TryGetValue(id, out item))
            {
                return item;
            }
            Log.w("Not Find Data By:" + id);
            return null;
        }
    }

}