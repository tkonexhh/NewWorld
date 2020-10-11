/************************
	FileName:/Scripts/Game/Scene/CreateCharacterScene/CreateCharacterCameraControl.cs
	CreateAuthor:neo.xu
	CreateTime:9/9/2020 12:46:59 PM
	Tip:9/9/2020 12:46:59 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using GFrame;

namespace Game.Logic
{
    public partial class CreateCharacterCameraControl : MonoBehaviour, IEventListener
    {
        [SerializeField] private CinemachineVirtualCamera m_CameraBody;
        [SerializeField] private CinemachineVirtualCamera m_CameraFace;

        private Role m_FocusRole;

        private CameraType m_CameraType;

        private void Awake()
        {
            m_CameraBody.Priority = 10;
            m_CameraFace.Priority = 1;
        }

        private void Start()
        {
            RegisterEvent();
        }

        private void OnDestroy()
        {
            UnRegisterEvent();
        }

        public void SetFocusRole(Role role)
        {
            m_FocusRole = role;

        }

        private void SetCameraType(CameraType type)
        {
            switch (type)
            {
                case CameraType.Body:
                    m_FocusRole?.SetFocus(null);
                    m_CameraBody.Priority = 10;
                    m_CameraFace.Priority = 1;

                    break;
                case CameraType.Face:
                    m_FocusRole?.SetFocus(transform);
                    m_CameraBody.Priority = 1;
                    m_CameraFace.Priority = 10;
                    break;
            }
        }

        #region  IEventListener
        public void RegisterEvent()
        {
            EventSystem.S.Register(SetupEvent.ChangeAppearance, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeColor, HandleEvent);
        }
        public void UnRegisterEvent()
        {
            EventSystem.S.UnRegister(SetupEvent.ChangeAppearance, HandleEvent);
            EventSystem.S.UnRegister(SetupEvent.ChangeColor, HandleEvent);
        }
        public void HandleEvent(int key, params object[] args)
        {
            switch (key)
            {
                case (int)SetupEvent.ChangeAppearance:
                    SetCameraType(CameraType.Face);
                    break;
                case (int)SetupEvent.ChangeColor:
                    AppearanceColor colorSlot = (AppearanceColor)args[0];
                    if (colorSlot == AppearanceColor.Hair || colorSlot == AppearanceColor.Eye)
                    {
                        SetCameraType(CameraType.Face);
                    }
                    else
                    {
                        SetCameraType(CameraType.Body);
                    }

                    break;
            }
        }

        #endregion

    }

    public partial class CreateCharacterCameraControl
    {
        public enum CameraType
        {
            Body,
            Face,
        }
    }

}