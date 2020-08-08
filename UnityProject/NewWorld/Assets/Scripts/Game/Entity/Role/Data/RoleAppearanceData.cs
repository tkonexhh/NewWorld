/************************
	FileName:/Scripts/Game/Character/Apperaance/CharacterAppearanceData.cs
	CreateAuthor:neo.xu
	CreateTime:7/13/2020 10:25:04 AM
	Tip:7/13/2020 10:25:04 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{

    [System.Serializable]
    public class BasicAppearance
    {
        public Sex sex = Sex.Male;
        public int hairID = 0;//发型
        public int faceID = 0;//面部
        public int facialHairID = 0;//胡子
        public int eyeBrows = 0;//眉毛
        public int ear = 0;
        //一些颜色
        public Color hairColor;
        public Color skinColor;
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
        public int shoulderRightID;
        public int shoulderLeftID;
        public int elbowRightID;
        public int elbowLeftID;
        public int kneeRightID;
        public int kneeLeftID;
        public int hipsAttachID;
        public int helmetWithHeadID;
        public int helmetWithoutHeadID;

        public Sex sex
        {
            get { return basicAppearance.sex; }
        }
    }

}