/************************
	FileName:/Scripts/Test/WorldTest/WorldTest.cs
	CreateAuthor:neo.xu
	CreateTime:9/23/2020 11:19:10 AM
	Tip:9/23/2020 11:19:10 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class WorldTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            WorldMgr.S.Init();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}