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
        [SerializeField] private Button m_BtnAttack2;
        [SerializeField] private Button m_BtnSpecialStart;
        [SerializeField] private Button m_BtnSpecialEnd;

        private RoleAnimTestPanel m_Panel;
        private RoleAnimTest role => m_Panel.role;
        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            m_BtnAttack1.onClick.AddListener(OnClickAttack1);
            m_BtnAttack2.onClick.AddListener(OnClickAttack2);
            m_BtnSpecialStart.onClick.AddListener(OnClickSpecialStart);
            m_BtnSpecialEnd.onClick.AddListener(OnClickSpecialEnd);
        }

        private void OnClickAttack1()
        {
            role.controlComponent.Attack();
        }

        private void OnClickAttack2()
        {
            role.controlComponent.Attack2();
        }

        private void OnClickSpecialStart()
        {
            role.controlComponent.SpecialAttackStart();
        }

        private void OnClickSpecialEnd()
        {
            role.controlComponent.SpecialAttackEnd();
        }
    }

}