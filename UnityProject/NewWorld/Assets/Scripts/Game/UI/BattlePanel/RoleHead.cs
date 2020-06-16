/************************
	FileName:/Scripts/Game/UI/BattlePanel/RoleHead.cs
	CreateAuthor:neo.xu
	CreateTime:6/16/2020 8:19:58 PM
	Tip:6/16/2020 8:19:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameWish.Game
{
    public class RoleHead : MonoBehaviour
    {
        [SerializeField] private Button m_BtnBg;
        [SerializeField] private Text m_TxtRole;

        //private 
        private void Start()
        {
            m_BtnBg.onClick.AddListener(OnClickBg);
        }

        public void BindRole()
        {

        }

        private void OnClickBg()
        {

        }
    }

}