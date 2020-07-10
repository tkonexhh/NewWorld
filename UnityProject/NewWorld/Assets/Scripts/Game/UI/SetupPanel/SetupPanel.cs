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
        ChangeAppearance = 101001,
        ChangeColor,
    }
    public class SetupPanel : AbstractPanel
    {
        [SerializeField] Setup_ArrowChange m_Hair;
        [SerializeField] Setup_ArrowChange m_Head;
        [SerializeField] Setup_ArrowChange m_FacialHair;
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

        }


    }

}