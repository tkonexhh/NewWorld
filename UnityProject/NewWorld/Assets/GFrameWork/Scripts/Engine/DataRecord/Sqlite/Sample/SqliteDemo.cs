/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/Sqlite/Sample/SqliteDemo.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 5:03:39 PM
	Tip:7/3/2020 5:03:39 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Sample
{
    public class SqliteDemo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

            SQLMgr.S.Open("Game");
            var gameDB = SQLMgr.S.GetDatabase("Game");
            var reader = gameDB.LoadTable("Item");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Debug.Log(reader[i].ToString());
                }
            }
        }

    }

}