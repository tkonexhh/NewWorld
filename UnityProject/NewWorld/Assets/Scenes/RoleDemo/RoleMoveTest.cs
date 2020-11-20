using System;
/************************
	FileName:/Scenes/RoleDemo/RoleMoveTest.cs
	CreateAuthor:neo.xu
	CreateTime:11/11/2020 3:43:00 PM
	Tip:11/11/2020 3:43:00 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.Logic
{
    public class RoleMoveTest : MonoBehaviour
    {
        [SerializeField] private Button m_BtnReset;
        [SerializeField] private Slider m_SliderVelZ;
        [SerializeField] private Slider m_SliderVelX;
        [SerializeField] private TextMeshProUGUI m_TMPVelZ;
        [SerializeField] private TextMeshProUGUI m_TMPVelX;
        [SerializeField] private Button m_BtnRoll;

        float m_SpeedZ;
        float m_SpeedX;
        float m_LastSpeedX;
        float m_LastSpeedZ;
        private RoleAnimTestPanel m_Panel;

        private RoleAnimTest role => m_Panel.role;

        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            OnClickReset();
            m_SliderVelZ.onValueChanged.AddListener(OnVelZChange);
            m_SliderVelX.onValueChanged.AddListener(OnVelXChange);
            OnVelZChange(0.5f);
            OnVelXChange(0.5f);

            m_BtnReset.onClick.AddListener(OnClickReset);
            m_BtnRoll.onClick.AddListener(OnClickRoll);
        }

        private void OnClickReset()
        {
            m_SliderVelX.value = 0.5f;
            m_SliderVelZ.value = 0.5f;
            UpdateText();
        }
        private void OnVelZChange(float v)
        {
            m_LastSpeedZ = m_SpeedZ;
            m_SpeedZ = (v - 0.5f) * 6 * 2;
            Check();
        }

        private void OnVelXChange(float v)
        {
            m_LastSpeedX = m_SpeedX;
            m_SpeedX = (v - 0.5f) * 6 * 2;
            Check();
        }


        private void Check()
        {
            if (m_SpeedZ == 0 && (m_LastSpeedZ > 3.0f) && !m_Panel.role.controlComponent.armed)
            {
                RunToStop();
            }
            else
            {
                SetVel();
            }

        }
        private void UpdateText()
        {
            m_TMPVelZ.text = m_SpeedZ.ToString("N2");
            m_TMPVelX.text = m_SpeedX.ToString("N2");
        }

        private void SetVel()
        {
            UpdateText();
            role.animComponent.SetMoving(m_SpeedZ != 0 || m_SpeedX != 0);
            role.animComponent.SetVelocityX(m_SpeedX);
            role.animComponent.SetVelocityZ(m_SpeedZ);
        }

        private void RunToStop()
        {
            role.controlComponent.RunToStop();
        }

        private void OnClickRoll()
        {
            role.controlComponent.Roll();
        }
    }

}