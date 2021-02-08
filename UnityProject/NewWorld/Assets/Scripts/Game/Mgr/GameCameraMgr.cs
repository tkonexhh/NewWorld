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
        private PostEffect m_CameraPostEffect;

        public Camera mainCamera
        {
            get => Camera.main;
        }

        public PostEffect postEffect
        {
            get
            {
                if (m_CameraPostEffect == null)
                {
                    m_CameraPostEffect = mainCamera.GetComponent<PostEffect>();
                }
                return m_CameraPostEffect;
            }
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
            // m_CameraPlayer.Follow = PlayerMgr.S.player.transform;
            m_CameraPlayer.Follow = GamePlayMgr.S.playerMgr.player.transform;
            m_CameraPlayer.LookAt = GamePlayMgr.S.playerMgr.player.role.monoReference.headLook;
        }


    }

}