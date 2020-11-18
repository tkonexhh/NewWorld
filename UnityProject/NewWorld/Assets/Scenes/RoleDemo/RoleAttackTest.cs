/************************
	FileName:/Scenes/RoleDemo/RoleAttackTest.cs
	CreateAuthor:neo.xu
	CreateTime:11/18/2020 2:25:37 PM
	Tip:11/18/2020 2:25:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Logic
{
    public class RoleAttackTest : MonoBehaviour
    {
        [SerializeField] private Button m_BtnAttack1;

        private RoleAnimTestPanel m_Panel;
        private RoleAnimTest role => m_Panel.role;
        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            m_BtnAttack1.onClick.AddListener(OnClickAttack1);
        }

        private void OnClickAttack1()
        {
            role.controlComponent.Attack();
        }
    }

}