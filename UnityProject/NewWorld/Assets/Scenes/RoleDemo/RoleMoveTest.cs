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

        float m_SpeedZ;
        float m_SpeedX;
        private RoleAnimTestPanel m_Panel;

        public void Init(RoleAnimTestPanel panel)
        {
            m_Panel = panel;
            OnClickReset();
            m_SliderVelZ.onValueChanged.AddListener(OnVelZChange);
            m_SliderVelX.onValueChanged.AddListener(OnVelXChange);
            OnVelZChange(0.5f);
            OnVelXChange(0.5f);

            m_BtnReset.onClick.AddListener(OnClickReset);
        }

        private void OnClickReset()
        {
            m_SliderVelX.value = 0.5f;
            m_SliderVelZ.value = 0.5f;
        }
        private void OnVelZChange(float v)
        {
            m_SpeedZ = (v - 0.5f) * 6 * 2;
            m_TMPVelZ.text = m_SpeedZ.ToString("N2");
            m_Panel.role.animComponent.SetMoving(m_SpeedZ != 0 || m_SpeedX != 0);
            m_Panel.role.animComponent.SetVelocityZ(m_SpeedZ);
        }

        private void OnVelXChange(float v)
        {
            m_SpeedX = (v - 0.5f) * 6 * 2;
            m_TMPVelX.text = m_SpeedX.ToString("N2");
            m_Panel.role.animComponent.SetMoving(m_SpeedZ != 0 || m_SpeedX != 0);
            m_Panel.role.animComponent.SetVelocityX(m_SpeedX);
        }

    }

}