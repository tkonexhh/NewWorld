/************************
	FileName:/Scripts/Game/Module/OpenWorld/WorldDefine.cs
	CreateAuthor:neo.xu
	CreateTime:9/23/2020 5:14:57 PM
	Tip:9/23/2020 5:14:57 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class WorldDefine
    {
        public const string MaterialShaderName = "XHH/Terrain";

        public const int ChunkSize = 1000;
        public static Vector2Int WorldSize = new Vector2Int(500, 500);
        public static float ChunckMaxDistance = 1.41422f;//根号2的近似值 1.414214

        public const float CheckTime = 0.1f;
        public const float DelayReleaseTime = 1.0f;
    }


}