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

            SQLMgr.S.Init();
        }

    }

}