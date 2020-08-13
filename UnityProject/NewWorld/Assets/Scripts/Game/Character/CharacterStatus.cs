/************************
	FileName:/Scripts/Game/Player/CharacterStatus.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 4:50:48 PM
	Tip:6/12/2020 4:50:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    [System.Serializable]
    public class CharacterStatus
    {
        public int strength;

        public float moveSpeed = 10;



        [Header("In Battle")]
        [SerializeField] protected int max_Action;//最大行动力
        [SerializeField] protected int action;//行动力
    }

}