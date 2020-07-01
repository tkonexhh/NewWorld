/************************
	FileName:/Scripts/UIScripts/SetupPanel/SetupPanel.cs
	CreateAuthor:neo.xu
	CreateTime:6/23/2020 3:21:15 PM
	Tip:6/23/2020 3:21:15 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GFrame;


namespace GameWish.Game
{
    public enum SetupEvent
    {
        ChangeHair = 101001,
        ChangeHead,
        ChangeEyebrows,
        ChangeTorso,
        ChangeArmUpperRight,
        ChangeArmUpperLeft,
        ChangeArmLowerRight,
        ChangeArmLowerLeft,
        ChangeHandRight,
        ChangeHandLeft,
        ChangeHips,
        ChangeLegRight,
        ChangeLegLeft,
    }
    public class SetupPanel : AbstractPanel
    {
        [SerializeField] Setup_ArrowChange m_Hair;
        [SerializeField] Setup_ArrowChange m_Head;
        [SerializeField] Setup_ArrowChange m_Eyebrows;
        [SerializeField] Setup_ArrowChange m_Torso;
        [SerializeField] Setup_ArrowChange m_ArmUpperRight;
        [SerializeField] Setup_ArrowChange m_ArmUpperLeft;
        [SerializeField] Setup_ArrowChange m_ArmLowerRight;
        [SerializeField] Setup_ArrowChange m_ArmLowerLeft;
        [SerializeField] Setup_ArrowChange m_HandRight;
        [SerializeField] Setup_ArrowChange m_HandLeft;
        [SerializeField] Setup_ArrowChange m_Hips;
        [SerializeField] Setup_ArrowChange m_LeftRight;
        [SerializeField] Setup_ArrowChange m_LeftLeft;

        protected override void OnUIInit()
        {
            m_Hair.RegisterAction(ChangeHair);
            m_Head.RegisterAction(ChangeHead);
            m_Eyebrows.RegisterAction(ChangeEyebrows);
            m_Torso.RegisterAction(ChangeTorso);
            m_ArmUpperRight.RegisterAction(ChangeArmUpperRight);
            m_ArmUpperLeft.RegisterAction(ChangeArmUpperLeft);
            m_ArmLowerRight.RegisterAction(ChangeArmLowerRight);
            m_ArmLowerLeft.RegisterAction(ChangeArmLowerLeft);
            m_HandRight.RegisterAction(ChangeHandRight);
            m_HandLeft.RegisterAction(ChangeHandLeft);
            m_Hips.RegisterAction(ChangeHips);
            m_LeftRight.RegisterAction(ChangeLegRight);
            m_LeftLeft.RegisterAction(ChangeLegLeft);
        }

        private void ChangeHair(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeHair, index);
        }

        private void ChangeHead(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeHead, index);
        }

        private void ChangeEyebrows(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeEyebrows, index);
        }

        private void ChangeTorso(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeTorso, index);
        }

        private void ChangeArmUpperRight(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeArmUpperRight, index);
        }

        private void ChangeArmUpperLeft(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeArmUpperLeft, index);
        }

        private void ChangeArmLowerRight(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeArmLowerRight, index);
        }

        private void ChangeArmLowerLeft(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeArmLowerLeft, index);
        }

        private void ChangeHandRight(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeHandRight, index);
        }

        private void ChangeHandLeft(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeHandLeft, index);
        }

        private void ChangeHips(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeHips, index);
        }

        private void ChangeLegRight(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeLegRight, index);
        }

        private void ChangeLegLeft(int index)
        {
            EventSystem.S.Send(SetupEvent.ChangeLegLeft, index);
        }
    }

}