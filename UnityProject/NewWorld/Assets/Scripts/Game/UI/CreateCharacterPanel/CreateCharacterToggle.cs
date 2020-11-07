/************************
	FileName:/Scripts/Game/UI/CreateCharacterPanel/CreateCharacterToggle.cs
	CreateAuthor:xuhonghua
	CreateTime:11/7/2020 12:13:19 PM
	Tip:11/7/2020 12:13:19 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Game.Logic
{
    public class CreateCharacterToggle : MonoBehaviour
    {
        [SerializeField] private Toggle m_Toggle;
        [SerializeField] private TextMeshProUGUI m_TMPTitle;
        [SerializeField] private Color m_ColorEnable;
        [SerializeField] private Color m_ColorDisable;

        private void Awake()
        {
            if (m_Toggle == null)
            {
                m_Toggle = GetComponent<Toggle>();
            }

            if (m_Toggle == null)
            {
                return;
            }

            m_Toggle.onValueChanged.AddListener(OnToggleValueChange);

            OnToggleValueChange(m_Toggle.isOn);
        }

        private void OnToggleValueChange(bool value)
        {
            m_TMPTitle.DOColor(value ? m_ColorEnable : m_ColorDisable, 0.4f);
        }
    }

}