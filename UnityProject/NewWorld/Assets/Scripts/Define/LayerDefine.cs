/************************
	FileName:/Scripts/Define/LayerDefine.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 4:20:51 PM
	Tip:6/12/2020 4:20:51 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class LayerDefine
    {
        public const int Layer_Ground = 8;
        public const int Layer_Role = 9;
        public const int Layer_InventoryRole = 10;
        public const int Layer_Stairs = 11;
        public const int Layer_FootIK = 12;
        public const int Layer_HitCollider = 13;
    }


    public class TagDefine
    {
        public const string TAG_MAINLIGHT = "MainLight";
    }

}