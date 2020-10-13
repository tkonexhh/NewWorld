/************************
	FileName:/Scripts/Game/Character/Apperaance/CharacterAppearanceData.cs
	CreateAuthor:neo.xu
	CreateTime:7/13/2020 10:25:04 AM
	Tip:7/13/2020 10:25:04 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{

    [System.Serializable]
    public class BasicAppearance
    {
        public Sex sex = Sex.Male;
        public int hairID = 1;//发型
        public int headID = 0;//面部
        public int facialHairID = 1;//胡子
        public int eyeBrows = 0;//眉毛
        public int ear = -1;
        //一些颜色
        public Color hairColor;
        public Color skinColor;
        public Color bodyArtColor;
    }


    [System.Serializable]
    public class RoleAppearanceData
    {
        public BasicAppearance basicAppearance;
        public int torsoID;
        public int armUpperRightID;
        public int armUpperLeftID;
        public int armLowerRightID;
        public int armLowerLeftID;
        public int handRightID;
        public int handLeftID;
        public int hipsID;
        public int legRightID;
        public int legLeftID;
        public int shoulderRightID = -1;
        public int shoulderLeftID = -1;
        public int elbowRightID = -1;
        public int elbowLeftID = -1;
        public int kneeRightID = -1;
        public int kneeLeftID = -1;
        public int hipsAttachID;
        public int helmetWithHeadID = -1;
        public int helmetWithoutHeadID = -1;
        public HelmetType helmetWithoutHeadType = HelmetType.Normal;
        public int backAttachID = -1;

        public Sex sex
        {
            get { return basicAppearance.sex; }
        }
    }

}