/************************
	FileName:/Scripts/Game/Mgr/GameCameraMgr.cs
	CreateAuthor:neo.xu
	CreateTime:11/9/2020 5:18:42 PM
	Tip:11/9/2020 5:18:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using Cinemachine;

namespace Game.Logic
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[GameCameraMgr]")]

    public class GameCameraMgr : TMonoSingleton<GameCameraMgr>
    {
        private CinemachineFreeLook m_CameraPlayer;

        public Camera mainCamera
        {
            get => Camera.main;
            // set;
        }


        public override void OnSingletonInit()
        {
            CinemachineCore.GetInputAxis = GetAxisCustom;
        }

        public float GetAxisCustom(string axisName)
        {
            if (axisName == "Mouse X")
            {
                if (Input.GetMouseButton(1))
                {
                    return -UnityEngine.Input.GetAxis("Mouse X");
                }
                else
                {
                    return 0;
                }
            }
            else if (axisName == "Mouse Y")
            {
                if (Input.GetMouseButton(1))
                {
                    return -UnityEngine.Input.GetAxis("Mouse Y");
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public void InitFreeLook(CinemachineFreeLook cinemachineFreeLook)
        {
            m_CameraPlayer = cinemachineFreeLook;
            m_CameraPlayer.Follow = PlayerMgr.S.player.transform;
            // m_CameraPlayer.LookAt = PlayerMgr.S.player.monoReference.cameraLookPoint;
            m_CameraPlayer.LookAt = PlayerMgr.S.player.role.monoReference.headLook;
            //    m_CameraPlayer.
            // m_CameraPlayer.GetRig(0).LookAt = PlayerMgr.S.player.role.monoReference.headLook;
            // m_CameraPlayer.GetRig(2).LookAt = PlayerMgr.S.player.role.monoReference.headLook;
        }


    }

}