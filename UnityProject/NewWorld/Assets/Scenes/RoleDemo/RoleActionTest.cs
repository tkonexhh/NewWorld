/************************
	FileName:/Scenes/RoleDemo/RoleActionTest.cs
	CreateAuthor:neo.xu
	CreateTime:11/12/2020 5:49:20 PM
	Tip:11/12/2020 5:49:20 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Logic
{
    public class RoleActionTest : MonoBehaviour
    {
        [SerializeField] private Button m_BtnTalking;
        [SerializeField] private Button m_BtnStopTalking;
        [SerializeField] private Button m_BtnDeath;
        [SerializeField] private Button m_BtnRevive;

        private RoleAnimTestPanel m_Panel;
        private RoleAnimTest role => m_Panel.role;
        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            m_BtnTalking.onClick.AddListener(OnClickTalking);
            m_BtnStopTalking.onClick.AddListener(OnClickStopTalking);
            m_BtnDeath.onClick.AddListener(OnClickDeath);
            m_BtnRevive.onClick.AddListener(OnClickRevive);
        }

        private void OnClickTalking()
        {
            role.controlComponent.StartTalking();
        }

        private void OnClickStopTalking()
        {
            role.controlComponent.EndTalking();
        }

        private void OnClickDeath()
        {
            role.controlComponent.Death();
        }

        private void OnClickRevive()
        {

        }
    }

}