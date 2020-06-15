/************************
	FileName:/Scripts/Game/Map/BattleMapBlock.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 4:03:14 PM
	Tip:6/15/2020 4:03:14 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GameWish.Game
{
    public class BattleMapBlock : MonoBehaviour
    {
        [SerializeField] private Text m_Txt;

        public void SetText(string name)
        {
            m_Txt.text = name;
        }
    }

}