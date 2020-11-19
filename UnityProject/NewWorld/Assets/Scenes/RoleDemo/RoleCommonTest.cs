/************************
	FileName:/Scenes/RoleDemo/RoleCommonTest.cs
	CreateAuthor:neo.xu
	CreateTime:11/19/2020 10:16:28 AM
	Tip:11/19/2020 10:16:28 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Logic
{
    public class RoleCommonTest : MonoBehaviour
    {
        [SerializeField] private Slider m_SliderSpeed;

        private RoleAnimTestPanel m_Panel;
        private RoleAnimTest role => m_Panel.role;
        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            m_SliderSpeed.onValueChanged.AddListener(OnAnimSpeedChaned);
            m_SliderSpeed.value = 0.5f;
        }

        private void OnAnimSpeedChaned(float value)
        {
            role.animComponent.animator.speed = value * 2;
        }
    }

}